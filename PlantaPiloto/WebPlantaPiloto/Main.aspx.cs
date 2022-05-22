﻿using System;
using System.Collections.Generic;
using System.Data;
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
        private static DB_services _db;
        private static List<String> _varNameList;
        private static List<String> _onlyWritableVarNameList;
        private static List<Variable> _varList;
        private static List<CheckBox> cboxGviewList;

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
                    this.loadGridView();
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
            gview1.Visible = true;

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


        private void loadGridView()
        {
            try
            {
                DataTable dtTable = new DataTable();
                dtTable.Columns.Add("Variable");
                dtTable.Columns.Add("Value");

                // Recogemos los valores actuales de las variables de la base de datos
                String _lastValues = _db.GetLastRowValue(_proyect, _varNameList);
                string[] values = _lastValues.Split(';');

                for (int i = 0; i < _varNameList.Count; i++)
                {
                    DataRow dRow = dtTable.NewRow();
                    dRow[0] = _varNameList[i];
                    dRow[1] = values[i + 1];
                    dtTable.Rows.Add(dRow);

                }

                gview1.DataSource = dtTable;
                gview1.DataBind();

                cboxGviewList = new List<CheckBox>();
                foreach (GridViewRow row in gview1.Rows)
                {
                    CheckBox cbox = (CheckBox)row.FindControl("cboxGV");
                    if (cbox != null)
                    {
                        cbox.Checked = true;
                        cboxGviewList.Add(cbox);
                    }
                }
                gridViewAesthetics();
                lbl_err_table.Visible = false;
            }catch(Exception ex)
            {
                lbl_err_table.Text = "Error al cargar la tabla. " + ex.Message + ex.StackTrace;
                lbl_err_table.Visible = true;
            }
        }

        private void gridViewAesthetics()
        {
            gview1.HeaderRow.Cells[1].BackColor = System.Drawing.Color.FromArgb(227, 227, 227);
            gview1.HeaderRow.Cells[2].BackColor = System.Drawing.Color.FromArgb(227, 227, 227);

            gview1.HeaderRow.Cells[0].BorderWidth = 0;
            gview1.HeaderRow.Cells[1].BorderWidth = 0;
            gview1.HeaderRow.Cells[2].BorderWidth = 0;

            foreach (GridViewRow row in gview1.Rows)
            {
                if (_onlyWritableVarNameList.Contains(row.Cells[1].Text))
                {
                    row.Cells[1].BackColor = System.Drawing.Color.White;
                    row.Cells[2].BackColor = System.Drawing.Color.White;
                }
                else
                {
                    row.Cells[1].BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                    row.Cells[2].BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                }
                row.Cells[0].BackColor = System.Drawing.Color.FromArgb(227, 227, 227);

                row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                row.Cells[2].HorizontalAlign = HorizontalAlign.Center;

                row.Cells[0].BorderWidth = 0;
                row.Cells[1].BorderWidth = 0;
                row.Cells[2].BorderWidth = 0;
            }
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
            try
            {
                for (int i = 0; i < cboxGviewList.Count; i++)
                {
                    if (cboxGviewList[i].Checked)
                        checkedList.Add(_varList[i]);
                }
            }
            catch (Exception ex)
            {
                lbl_err_Chart.Text = "Error intentando obtener las casillas marcadas " + ex.Message + ex.StackTrace;
                lbl_err_Chart.Visible = true;
            }
            return checkedList;
        }

        protected void cboxGV_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbox = (CheckBox)sender;
            GridViewRow grow = (GridViewRow)cbox.NamingContainer;
            int rIndex = grow.RowIndex;
            cboxGviewList[rIndex].Checked = cbox.Checked;
        }
    }
}