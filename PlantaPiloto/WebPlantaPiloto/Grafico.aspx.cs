using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using PlantaPiloto;
using PlantaPiloto.Enums;

namespace WebPlantaPiloto
{
    public partial class Grafico : System.Web.UI.Page
    {
        static Proyect _proyect;
        static DB_services _db;
        static List<Variable> _variables;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _proyect = (Proyect)Application["proyect"];
                _db = (DB_services)Application["db"];
                _variables = new List<Variable>();
                cbl_1.ClearSelection();

                foreach (Variable v in _proyect.Variables)
                {
                    _variables.Add(v);
                    ListItem li = new ListItem(v.Name, v.Name);
                    li.Selected = true;
                    cbl_1.Items.Add(li);
                }

                Chart1.Visible = true;
                lbl_error.Visible = false;
                Session["DatosMostrados"] = 100;
                LoadCharts(_variables, _db, _proyect);
                loadTable();
                txtIn_1.Text = "100";
                //btn_variables_Click(sender, e);
                //Thread hiloGrafico = new Thread(() => LoadCharts(_variables, _db, _proyect));
                //Application["hiloGrafico"] = hiloGrafico;
                //hiloGrafico.Start();
            }
        }
            

        private void LoadCharts(List<Variable> _variables, DB_services _db_services, Proyect _proyect)
        {
                List<List<Variable>> _sqlData = new List<List<Variable>>();
                int _chartAmount = (int) Session["DatosMostrados"];
                List<float> _sqlTime = new List<float>();
                ResourceManager _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);

                try
                {
                    Chart1.Series.Clear();
                    Chart1.Legends.Clear();
                    //Se recogen los valores de las variables seleccionadas
                    foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
                    {
                        _sqlData.Add(_db_services.GetVarValue(_proyect, v, _chartAmount));
                        Chart1.Legends.Add(v.Name);
                    }

                    //Se obtienen los valores de tiempo
                    _sqlTime.Clear();
                    _sqlTime = _db_services.GetTime(_proyect, _chartAmount);

                    for (int i = 0; i < _sqlData.Count(); i++)
                    {
                        Series series = new Series(_sqlData[i].First().Name);
                        series.Points.DataBindXY(_sqlTime, "Time", _sqlData[i].Select(p => Double.Parse(p.Value)).ToList(), "Value");
                        series.ChartType = SeriesChartType.Line;
                        series.BorderWidth = 3;
                        Chart1.Series.Add(series);
                        Chart1.ChartAreas[0].AxisX.Interval = 10;
                        Chart1.ChartAreas[0].AxisX.Title = _res_man.GetString("chartXAxisLabel", _proyect.Cul);
                        Chart1.ChartAreas[0].AxisY.Title = _res_man.GetString("chartYAxisLabel", _proyect.Cul);
                        Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "#.##";
                    }
                    //Chart1.Visible = true;
                }
                catch (Exception ex)
                {
                    lbl_error.Text = "Excepcion cargando grafico \n" + ex.Message + "\n" + ex.StackTrace;
                    lbl_error.Visible = false;
                }
            

        }

        protected void btn_variables_Click(object sender, EventArgs e)
        {
            try
            {
                    List<String> selected = new List<String>();
                    List<Variable> varsSelected = new List<Variable>();

                    foreach (ListItem i in cbl_1.Items)
                    {
                        if (i.Selected)
                        {
                            selected.Add(i.Text);
                        }
                    }

                    foreach (String s in selected)
                    {
                        foreach (Variable v in _variables)
                        {
                            if (v.Name.Equals(s))
                            {
                                varsSelected.Add(v);
                            }
                        }
                    }

                    LoadCharts(varsSelected, _db, _proyect);
                    loadTable();

            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error al actualizar el grafico \n" + ex.Message + "\n" + ex.StackTrace;
                lbl_error.Visible = true;
            }
        }

        protected void loadTable()
        {
            TableRowCollection tRows = Table1.Rows;

            foreach (TableRow t in tRows)
            {
                Table1.Rows.Remove(t);
            }

            TableRow row1 = new TableRow();
            TableCell cell1_1 = new TableCell();
            TableCell cell1_2 = new TableCell();
            cell1_1.Text = "Variables";
            cell1_1.Font.Bold = true;
            cell1_2.Text = "Valores";
            cell1_2.Font.Bold = true;
            row1.Cells.Add(cell1_1);
            row1.Cells.Add(cell1_2);
            Table1.Rows.Add(row1);

            List<String> _v = new List<string>();

            foreach (Variable v in _variables)
                    _v.Add(v.Name);

            String _lastValues = _db.GetLastRowValue(_proyect, _v);

            string[] values = _lastValues.Split(';');

            for (int i = 0; i < _v.Count; i++)
            {
                TableRow nRow = new TableRow();
                TableCell nCell1 = new TableCell();
                TableCell nCell2 = new TableCell();

                nCell1.Text = _v[i];
                nCell2.Text = values[i + 1];

                nRow.Cells.Add(nCell1);
                nRow.Cells.Add(nCell2);
                Table1.Rows.Add(nRow);
            }

        }

        protected void btn_datos_Click(object sender, EventArgs e)
        {
            try
            {
                int datos = int.Parse(txtIn_1.Text);
                Session["DatosMostrados"] = datos;
                lbl_error.Visible = false;
            }
            catch(Exception ex)
            {
                lbl_error.Text = "Entrada no válida";
                lbl_error.Visible = true;
            }
        }
    }
}