using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        private static string conString;
        private static List<String> _varNameList;
        private static List<String> _onlyWritableVarNameList;
        private static List<Variable> _varList;
        private static List<CheckBox> cboxGviewList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;

                string theme = null;
                string language = null;

                if (Session["theme"] != null)
                    theme = (string)Session["theme"];

                if (Session["language"] != null)
                    language = (string)Session["language"];

                div_ChangeData.Attributes["class"] = "rectanguloBlanco";
                div_ChangeVariable.Attributes["class"] = "rectanguloBlanco";
                div_Options.Attributes["class"] = "rectanguloBlanco";
                div_Table.Attributes["class"] = "rectanguloBlanco";
                div_Chart.Attributes["class"] = "rectanguloBlanco";

                if (Session["connectionString"] != null)
                {
                    txtIn_ConnString.Text = (string)Session["connectionString"];
                    this.btn_ConnString_Click(sender, e);
                }

                if (theme != null)
                {
                    if (theme.Equals("Light"))
                        ddlist_theme.SelectedIndex = 0;
                    else if (theme.Equals("Dark"))
                        ddlist_theme.SelectedIndex = 1;
                    this.ddlist_theme_SelectedIndexChanged(sender, e);
                }

                if (language != null)
                {
                    if (language.Equals("English"))
                        ddlist_lang.SelectedIndex = 1;
                    else if (language.Equals("Spanish"))
                        ddlist_lang.SelectedIndex = 0;
                    this.ddlist_lang_SelectedIndexChanged(sender, e);
                }
            }
        }

        protected void btn_ConnString_Click(object sender, EventArgs e)
        {
            try
            {
                conString = txtIn_ConnString.Text;
                loadInitialValues();

                if (_db.CheckDBExists(_proyect))
                {
                    lbl_ConnectionStatus.Text = "true";
                    lbl_ConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(52, 178, 60);
                    ddList_ChangeVar.DataSource = _onlyWritableVarNameList;
                    ddList_ChangeVar.DataBind();

                    Session["connectionString"] = conString;
                    Session["proyect"] = _proyect;

                    if (Session["dataAmount"] != null)
                        txtIn_ChangeData.Text = Session["dataAmount"].ToString();
                    else
                    {
                        txtIn_ChangeData.Text = "100";
                        Session["dataAmount"] = 100;
                    }

                    this.loadOptions();
                    this.setTagsVisible();
                    this.loadGridView();
                    this.LoadChart(sender, e);
                    this.ddlist_lang_SelectedIndexChanged(sender, e);
                    this.ddlist_theme_SelectedIndexChanged(sender, e);
                    Timer1.Enabled = true;
                    lbl_err_ConString.Visible = false;
                }
                else
                {
                    lbl_ConnectionStatus.Text = "false";
                    lbl_ConnectionStatus.ForeColor = System.Drawing.Color.Red;
                }

            }catch (Exception ex)
            {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_ConString.Text = SpanishText.lbl_err_ConStringEx1 + ex.Message + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_ConString.Text = EnglishText.lbl_err_ConStringEx1;
                lbl_err_ConString.Visible = true;
            }
        }

        private void loadInitialValues()
        {
            Proyect proyect = loadProyect();
            DB_services db = new DB_services(proyect.Cul, conString);

            if (db.CheckDBExists(proyect))
            {
                _proyect = proyect;
                _db = db;

                _varNameList = new List<string>();
                _onlyWritableVarNameList = new List<string>();
                _varList = new List<Variable>();

                lbl_ProjectName.Text = _proyect.Name;

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
            linkButtonFullDB.Visible = true;

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

            languages.Add("Spanish");
            languages.Add("English");
            themes.Add("Light");
            themes.Add("Dark");

            ddlist_lang.DataSource = languages;
            ddlist_lang.DataBind();
            ddlist_theme.DataSource = themes;
            ddlist_theme.DataBind();
        }

        private Proyect loadProyect()
        {
            Proyect _proyect = new Proyect();
            Variable _variable;

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
                lbl_err_ConString.Visible = false;
            }
            catch (Exception ex)
            {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_ConString.Text = SpanishText.lbl_err_ConStringEx2 + ex.Message + " " + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_ConString.Text = EnglishText.lbl_err_ConStringEx2 + ex.Message + " " + ex.StackTrace;
                lbl_err_ConString.Visible = true;
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
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_table.Text = SpanishText.lbl_err_tableEx1 + ex.Message + " " + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_table.Text = EnglishText.lbl_err_tableEx1 + ex.Message + " " + ex.StackTrace;
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
            try
            {
                List<List<Variable>> _sqlData = new List<List<Variable>>();
                List<Variable> _variables = checkedVariables();

                int _chartAmount = (int) Session["dataAmount"];
                List<float> _sqlTime = new List<float>();
                ResourceManager _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);

                chart_Var.Series.Clear();
                chart_Var.Legends.Clear();
                //Se recogen los valores de las variables seleccionadas
                foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
                {
                    _sqlData.Add(_db.GetVarValue(_proyect, v, _chartAmount));
                    chart_Var.Legends.Add(v.Name);
                    chart_Var.Legends[chart_Var.Legends.Count - 1].Font = new System.Drawing.Font("Helvetica", 10);
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

                    chart_Var.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Helvetica", 20);
                    chart_Var.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Helvetica", 20);

                    chart_Var.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Helvetica", 10);
                    chart_Var.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Helvetica", 10);


                    if (Session["theme"] != null)
                    {
                        string theme = (string)Session["theme"];

                        if (theme.Equals("Light"))
                        {
                            chart_Var.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
                            chart_Var.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
                            chart_Var.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
                            chart_Var.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
                        }
                        else if (theme.Equals("Dark"))
                        {
                            chart_Var.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.FromArgb(196, 194, 194);
                            chart_Var.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(196, 194, 194);
                            chart_Var.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.FromArgb(196, 194, 194);
                            chart_Var.ChartAreas[0].AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(196, 194, 194);
                        }
                    }
                }
                updateGridView(sender, e);
                lbl_err_Chart.Visible = false;
            }
            catch (Exception ex) {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_Chart.Text = SpanishText.lbl_err_ChartEx1 + ex.Message + " " + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_Chart.Text = EnglishText.lbl_err_ChartEx1 + ex.Message + " " + ex.StackTrace;
                lbl_err_Chart.Visible = false;
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
                lbl_err_Chart.Visible = false;
            }
            catch (Exception ex)
            {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_Chart.Text = SpanishText.lbl_err_ChartEx2 + ex.Message + " " + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_Chart.Text = EnglishText.lbl_err_ChartEx2 + ex.Message + " " + ex.StackTrace;
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

        protected void updateGridView(object sender, EventArgs e)
        {
            try
            {
                // Recogemos los valores actuales de las variables de la base de datos
                String _lastValues = _db.GetLastRowValue(_proyect, _varNameList);
                string[] values = _lastValues.Split(';');

                for (int i = 0; i < gview1.Rows.Count; i++)
                {
                    gview1.Rows[i].Cells[2].Text = values[i + 1].ToString();

                    lbl_err_table.Visible = true;
                }
                lbl_err_table.Visible = false;
            }
            catch (Exception ex)
            {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_table.Text = SpanishText.lbl_err_tableEx2 + ex.Message + " " + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_table.Text = EnglishText.lbl_err_tableEx2 + ex.Message + " " + ex.StackTrace;
                lbl_err_table.Visible = true;
            }
        }

        protected void btn_ChangeData_Click(object sender, EventArgs e)
        {
            int dataAmount = -1;
            bool isNumber = int.TryParse(txtIn_ChangeData.Text, out dataAmount);

            if (!isNumber || dataAmount < 0)
            {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_ChangeData.Text = SpanishText.lbl_err_ChangeDataEx1;
                else if (this.getLanugage().EndsWith("English"))
                    lbl_err_ChangeData.Text = EnglishText.lbl_err_ChangeDataEx1;
                lbl_err_ChangeData.Visible = true;
            }
            else
            {
                lbl_err_ChangeData.Visible = false;
                Session["dataAmount"] = dataAmount;
            }

        }

        protected void hlink_fulldb_DataBinding(object sender, EventArgs e)
        {
            //Server.Transfer("FullDB.aspx");
            Response.Redirect("FullDB.aspx");
        }

        protected void btn_ChangeVar_Click(object sender, EventArgs e)
        {
            try
            {
                string variable = ddList_ChangeVar.SelectedValue;
                string value = txtIn_ChangeVar.Text;
                value = value.Replace(',', '.');
                value = value.Trim();
                bool illegalChar = false;

                lbl_err_ChangeVar.Visible = false;

                foreach (Char c in value)
                    if (!char.IsDigit(c) && !c.Equals('.'))
                        illegalChar = true;

                if (!illegalChar)
                    _db.InsertModifyValue(_proyect, variable, value);
                else
                {
                    if (this.getLanugage().Equals("Spanish"))
                        lbl_err_ChangeVar.Text = SpanishText.lbl_err_ChangeVarEx1;
                    else if (this.getLanugage().Equals("English"))
                        lbl_err_ChangeVar.Text = EnglishText.lbl_err_ChangeVarEx1;
                    lbl_err_ChangeVar.Visible = true;
                }
            }catch(Exception ex)
            {
                if (this.getLanugage().Equals("Spanish"))
                    lbl_err_ChangeVar.Text = SpanishText.lbl_err_ChangeVarEx2 + ex.Message + " " + ex.StackTrace;
                else if (this.getLanugage().Equals("English"))
                    lbl_err_ChangeVar.Text = EnglishText.lbl_err_ChangeVarEx2 + ex.Message + " " + ex.StackTrace;
                lbl_err_table.Visible = true;
            }
        }

        protected void ddlist_lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlist_lang.SelectedValue.Equals("Español") || ddlist_lang.SelectedValue.Equals("Spanish"))
            {
                lbl_ConString.Text = SpanishText.lbl_ConString;
                lbl_Connection.Text = SpanishText.lbl_Connection;
                btn_ConnString.Text = SpanishText.btn_ConnString;
                linkButtonFullDB.Text = SpanishText.linkButtonFullDB;
                lbl_Project.Text = SpanishText.lbl_Project;
                gview1.HeaderRow.Cells[1].Text = SpanishText.gview1Col1;
                gview1.HeaderRow.Cells[2].Text = SpanishText.gview1Col2;
                lbl_ChangeVariable.Text = SpanishText.lbl_ChangeVariable;
                btn_ChangeVar.Text = SpanishText.btn_ChangeVar;
                lbl_ChangeData.Text = SpanishText.lbl_ChangeData;
                btn_ChangeData.Text = SpanishText.btn_ChangeData;
                lbl_Options.Text = SpanishText.lbl_Options;
                lbl_Language.Text = SpanishText.lbl_Language;
                lbl_Theme.Text = SpanishText.lbl_Theme;
                ddlist_lang.Items[0].Text = SpanishText.ddlist_langLang1;
                ddlist_lang.Items[1].Text = SpanishText.ddlist_langLang2;
                ddlist_theme.Items[0].Text = SpanishText.ddlist_themeTheme1;
                ddlist_theme.Items[1].Text = SpanishText.ddlist_themeTheme2;

                Session["language"] = "Spanish";
            }
            else if (ddlist_lang.SelectedValue.Equals("Inglés") || ddlist_lang.SelectedValue.Equals("English"))
            {
                lbl_ConString.Text = EnglishText.lbl_ConString;
                lbl_Connection.Text = EnglishText.lbl_Connection;
                btn_ConnString.Text = EnglishText.btn_ConnString;
                linkButtonFullDB.Text = EnglishText.linkButtonFullDB;
                lbl_Project.Text = EnglishText.lbl_Project;
                gview1.HeaderRow.Cells[1].Text = EnglishText.gview1Col1;
                gview1.HeaderRow.Cells[2].Text = EnglishText.gview1Col2;
                lbl_ChangeVariable.Text = EnglishText.lbl_ChangeVariable;
                btn_ChangeVar.Text = EnglishText.btn_ChangeVar;
                lbl_ChangeData.Text = EnglishText.lbl_ChangeData;
                btn_ChangeData.Text = EnglishText.btn_ChangeData;
                lbl_Options.Text = EnglishText.lbl_Options;
                lbl_Language.Text = EnglishText.lbl_Language;
                lbl_Theme.Text = EnglishText.lbl_Theme;
                ddlist_lang.Items[0].Text = EnglishText.ddlist_langLang1;
                ddlist_lang.Items[1].Text = EnglishText.ddlist_langLang2;
                ddlist_theme.Items[0].Text = EnglishText.ddlist_themeTheme1;
                ddlist_theme.Items[1].Text = EnglishText.ddlist_themeTheme2;

                Session["language"] = "English";
            }
        }

        private string getLanugage()
        {
            if (ddlist_lang.SelectedValue.Equals("Español") || ddlist_lang.SelectedValue.Equals("Spanish"))
                return "Spanish";
            if (ddlist_lang.SelectedValue.Equals("Inglés") || ddlist_lang.SelectedValue.Equals("English"))
                return "English";

            return "";
        }

        protected void ddlist_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlist_theme.SelectedValue.Equals("Light") || ddlist_theme.SelectedValue.Equals("Claro"))
            {
                div_ConnString.Attributes["class"] = "rectanguloRedondeado";
                div_Table.Attributes["class"] = "rectanguloRedondeado";
                div_ChangeVariable.Attributes["class"] = "rectanguloRedondeado";
                div_ChangeData.Attributes["class"] = "rectanguloRedondeado";
                div_Options.Attributes["class"] = "rectanguloRedondeado";
                div_Chart.Attributes["class"] = "rectanguloRedondeado";

                bodyTag.Attributes.Clear();
                bodyTag.Attributes.Add("bgcolor", "white");

                chart_Var.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);

                gview1.ForeColor = System.Drawing.Color.Black;
                Session["theme"] = "Light";
            }
            else if (ddlist_theme.SelectedValue.Equals("Dark") || ddlist_theme.SelectedValue.Equals("Oscuro"))
            {
                div_ConnString.Attributes["class"] = "rectanguloRedondeadoOscuro";
                div_Table.Attributes["class"] = "rectanguloRedondeadoOscuro";
                div_ChangeVariable.Attributes["class"] = "rectanguloRedondeadoOscuro";
                div_ChangeData.Attributes["class"] = "rectanguloRedondeadoOscuro";
                div_Options.Attributes["class"] = "rectanguloRedondeadoOscuro";
                div_Chart.Attributes["class"] = "rectanguloRedondeadoOscuro";

                bodyTag.Attributes.Clear();
                bodyTag.Attributes.Add("bgcolor", "#2C2C2C");

                chart_Var.ForeColor = System.Drawing.Color.FromArgb(196, 194, 194);

                gview1.ForeColor = System.Drawing.Color.Black;
                Session["theme"] = "Dark";
            }
        }
    }
}