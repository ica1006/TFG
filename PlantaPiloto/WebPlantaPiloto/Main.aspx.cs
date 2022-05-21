using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using PlantaPiloto;
using PlantaPiloto.Enums;

namespace WebPlantaPiloto
{
    public partial class Main : System.Web.UI.Page
    {
        private static Proyect _proyect;
        private static String conString;
        private static DB_services _db;
        private static List<String> _varNameList;
        private static List<String> _onlyWritableVarNameList;
        private static List<Variable> _varList;
        private static CheckBoxList cbl_vars;
        private static TableRowCollection tableRows;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;
                //Timer2.Enabled = false;
            }
        }

        protected void btn_ConnString_Click(object sender, EventArgs e)
        {
            Session["conString"] = txtIn_ConnString.Text;
            lbl_err_ConString.Visible = false;

            try
            {
                loadInitialValues();

                if (_db.CheckDBExists(_proyect))
                {
                    ddList_ChangeVar.DataSource = _onlyWritableVarNameList;
                    ddList_ChangeVar.DataBind();

                    this.loadOptions();
                    this.setTagsVisible();
                    Timer1.Enabled = true;
                    //Timer2.Enabled = true;
                    this.loadTable();
                    tableRows = tbl_vars.Rows;
                    this.LoadChart(sender, e);
                }

            }catch (Exception)
            {
                lbl_err_ConString.Text = "Error, por favor introduce un connection string válido";
                lbl_err_ConString.Visible = true;
            }
        }

        private void loadInitialValues()
        {
            Proyect proyect = loadProyect();
            DB_services db = new DB_services(proyect.Cul, (string) Session["conString"]);

            if (db.CheckDBExists(proyect))
            {
                _proyect = proyect;
                _db = db;

                _varNameList = new List<string>();
                _onlyWritableVarNameList = new List<string>();
                _varList = new List<Variable>();

                conString = txtIn_ConnString.Text;
                lbl_ProjectName.Text = _proyect.Name;
                lbl_ConnectionStatus.Text = "true";
                lbl_ConnectionStatus.ForeColor = System.Drawing.Color.Green;

                foreach (Variable v in _proyect.Variables)
                {
                    _varNameList.Add(v.Name);
                    _varList.Add(v);

                    if (v.Access is EnumVarAccess.Escritura)
                        _onlyWritableVarNameList.Add(v.Name);
                }
            }
        }

        private void setTagsVisible()
        {
            //hlink full db
            hlink_fulldb.Visible = true;

            //div variable table
            lbl_Project.Visible = true;
            lbl_ProjectName.Visible = true;
            tbl_vars.Visible = true;

            //div change variable
            lbl_ChangeVariable.Visible = true;
            ddList_ChangeVar.Visible = true;
            txtIn_ChangeVar.Visible = true;
            btn_ChangeVar.Visible = true;

            //div change data amount
            lbl_ChangeData.Visible = true;
            txtIn_ChangeData.Visible = true;
            btn_ChangeData.Visible = true;

            //options
            lbl_Options.Visible = true;
            lbl_Language.Visible = true;
            ddlist_lang.Visible = true;
            lbl_Theme.Visible = true;
            ddlist_theme.Visible = true;

            //Chart
            chart_Var.Visible = true;
        }

        private void loadOptions()
        {
            List<String> languages = new List<string>();
            List<String> themes = new List<string>();

            languages.Add("Español");
            languages.Add("English");
            themes.Add("Claro");
            themes.Add("Oscuro");

            ddlist_lang.DataSource = languages;
            ddlist_lang.DataBind();
            ddlist_theme.DataSource = themes;
            ddlist_theme.DataBind();
        }

        private Proyect loadProyect()
        {
            Proyect _proyect = new Proyect();
            Variable _variable;
            lbl_err_ConString.Visible = false;

            try
            {
                StreamReader sr = new StreamReader("motor_caudal_tfg.txt");
                _proyect = new Proyect();
                sr.ReadLine();
                _proyect.Name = sr.ReadLine();
                _proyect.Description = sr.ReadLine();
                _proyect.ImagePath = sr.ReadLine();
                do
                {
                    if (sr.ReadLine() == "****************************************")
                    {
                        _variable = new Variable();
                        string fL = sr.ReadLine();
                        if (fL == "****************************************")
                            break;
                        _variable.Name = fL;
                        _variable.Type = (EnumVarType)Enum.Parse(typeof(EnumVarType), sr.ReadLine());
                        _variable.Description = sr.ReadLine();
                        _variable.Access = (EnumVarAccess)Enum.Parse(typeof(EnumVarAccess), sr.ReadLine());
                        if (_variable.Type != EnumVarType.String)
                        {
                            _variable.BoardUnits = sr.ReadLine();
                            _variable.InterfaceUnits = sr.ReadLine();
                            _variable.LinearAdjustA = float.Parse(sr.ReadLine());
                            _variable.LinearAdjustB = float.Parse(sr.ReadLine());
                            _variable.RangeLow = float.Parse(sr.ReadLine());
                            _variable.RangeHigh = float.Parse(sr.ReadLine());
                        }
                        _variable.CommunicationType = (EnumVarCommunicationType)Enum.Parse(typeof(EnumVarCommunicationType), sr.ReadLine());
                        _proyect.Variables.Add(_variable);
                    }
                } while (true);
                sr.Close();
            }
            catch (Exception ex)
            {
                lbl_err_ConString.Visible = true;
                lbl_err_ConString.Text = "Ha saltado una excepción en loadProyect\n" + ex.Message + "\n" + ex.StackTrace;
            }

            return _proyect;
        }

        private void loadTable()
        {
            cbl_vars = new CheckBoxList();
            List<CheckBox> cb_list = new List<CheckBox>();
            TableRowCollection tRows = tbl_vars.Rows;

            // Si la tabla está llena, la vaciamos
            foreach (TableRow t in tRows)
                tbl_vars.Rows.Remove(t);

            // Introducimos la primera fila, el encabezado
            TableRow row1 = new TableRow();
            TableCell cell1_2 = new TableCell();
            TableCell cell1_3 = new TableCell();

            cell1_2.Text = "Variables";
            cell1_2.BackColor = System.Drawing.Color.FromArgb(227,227,227);
            cell1_2.Font.Bold = true;
            cell1_3.Text = "Valores";
            cell1_3.BackColor = System.Drawing.Color.FromArgb(227, 227, 227);
            cell1_3.Font.Bold = true;

            row1.Cells.Add(new TableCell());
            row1.Cells.Add(cell1_2);
            row1.Cells.Add(cell1_3);
            tbl_vars.Rows.Add(row1);

            // Recogemos los valores actuales de las variables de la base de datos
            String _lastValues = _db.GetLastRowValue(_proyect, _varNameList);
            string[] values = _lastValues.Split(';');

            for (int i = 0; i < _varNameList.Count; i++)
            {
                TableRow nRow = new TableRow();
                TableCell nCell1 = new TableCell();
                TableCell nCell2 = new TableCell();
                TableCell nCell3 = new TableCell();

                CheckBox cbox = new CheckBox();
                cbox.Checked = true;
                cb_list.Add(cbox);
                nCell1.Controls.Add(cbox);
                nCell1.BackColor = System.Drawing.Color.FromArgb(227, 227, 227);

                if (_varList[i].Access.Equals(EnumVarAccess.Escritura))
                {
                    nCell2.BackColor = System.Drawing.Color.White;
                    nCell3.BackColor = System.Drawing.Color.White;
                }
                else
                {
                    nCell2.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    nCell3.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                }

                nCell2.Text = _varNameList[i];
                nCell3.Text = values[i + 1];

                nRow.Cells.Add(nCell1);
                nRow.Cells.Add(nCell2);
                nRow.Cells.Add(nCell3);
                tbl_vars.Rows.Add(nRow);
            }

            foreach (TableRow row in tbl_vars.Rows)
                foreach(TableCell cell in row.Cells)
                {
                    cell.Font.Name = "helvetica";
                    cell.Font.Size = 14;
                    cell.HorizontalAlign = HorizontalAlign.Center;
                }

            cbl_vars.DataSource = cb_list;
            cbl_vars.DataBind();
        }

        protected void LoadChart(object sender, EventArgs e)
        {
            if (_db == null)
            {
                lbl_err_Chart.Text = "Entra load chart";
                lbl_err_Chart.Visible = true;
                loadInitialValues();
                //return;
            }

            //DB_services db = (DB_services) Session["_db"];
            //Proyect proyect = (Proyect) Session["_proyect"];
            chart_Var.Visible = true;
            List<List<Variable>> _sqlData = new List<List<Variable>>();
            List<Variable> _variables = checkedVariables();

            int _chartAmount = 100;
            List<float> _sqlTime = new List<float>();
            ResourceManager _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);

            try
            {
                chart_Var.Series.Clear();
                chart_Var.Legends.Clear();
                //Se recogen los valores de las variables seleccionadas
                foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
                {
                    _sqlData.Add(_db.GetVarValue(_proyect, v, _chartAmount));
                    chart_Var.Legends.Add(v.Name);
                }

                //Se obtienen los valores de tiempo
                _sqlTime.Clear();
                _sqlTime = _db.GetTime(_proyect, _chartAmount);

                for (int i = 0; i < _sqlData.Count(); i++)
                {
                    Series series = new Series(_sqlData[i].First().Name);
                    series.Points.DataBindXY(_sqlTime, "Time", _sqlData[i].Select(p => Double.Parse(p.Value)).ToList(), "Value");
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 3;
                    chart_Var.Series.Add(series);
                    chart_Var.ChartAreas[0].AxisX.Interval = 10;
                    chart_Var.ChartAreas[0].AxisX.Title = _res_man.GetString("chartXAxisLabel", _proyect.Cul);
                    chart_Var.ChartAreas[0].AxisY.Title = _res_man.GetString("chartYAxisLabel", _proyect.Cul);
                    chart_Var.ChartAreas[0].AxisX.LabelStyle.Format = "#.##";
                }
            }catch (Exception ex) {
                lbl_err_ChangeData.Text = "Excepcion cargando grafico " + ex.Message + ex.StackTrace;
                lbl_err_ChangeData.Visible = true;
            }
        }

        private List<Variable> checkedVariables()
        {
            List<Variable> checkedList = new List<Variable>();
            //int i = 0;
            try
            {
                for (int i = 1; i < tableRows.Count; i++)
                {
                    CheckBox cbox = (CheckBox)tableRows[i].Cells[0].Controls[0];

                    if (cbox.Checked)
                    {
                        checkedList.Add(_varList[i - 1]);
                    }
                }
            }catch(Exception ex)
            {

            }

           /* foreach (ListItem cbox in cbl_vars.Items)
            {
                if (cbox.Selected)
                {
                    checkedList.Add(_varList[i]);
                }
                i++;
            }*/

            return checkedList;
        }

        protected void refreshTable(object sender, EventArgs e)
        {
            try
            {
                if (_db == null)
                {
                    lbl_Options.Text = "Entra refresh table";
                    lbl_Options.Visible = true;
                    loadInitialValues();
                    //return;
                }
                tbl_vars.Visible = true;
                //DB_services db = (DB_services) Session["_db"];
                //Proyect proyect = (Proyect) Session["_proyect"];
                string[] values = _db.GetLastRowValue(_proyect, _varNameList).Split(';');
                int i = 1;

                foreach (TableRow row in tbl_vars.Rows)
                {
                    row.Cells[2].Text = values[i];
                    i++;
                }
            }catch(Exception ex)
            {
                lbl_err_table.Text = "Excepción al refrescar la tabla " + ex.Message + ex.StackTrace;
                lbl_err_table.Visible = true;
            }
        }
    }
}