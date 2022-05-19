using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
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
    public partial class _Default : Page
    {
        private static SP_services _sp;
        private static Proyect _proyect;
        private static String conString;
        private static DB_services _db;
        private static List<String> _varList;
        private static List<Variable> _variables;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_error.Visible = false;
                Table1.Visible = false;
                GridView1.Visible = false;
                ddList_1.Visible = false;
                ddList_2.Visible = false;
                txtIn_2.Visible = false;
                lbl_5.Visible = false;
                btn_actualizar.Visible = false;
                btn_grafico.Visible = false;
            }
        }

        protected void btn_Conectar_Click(object sender, EventArgs e)
        {
            _proyect = loadProyect();
            Application["proyect"] = _proyect;
            conString = txtIn_1.Text;
            _db = new DB_services(_proyect.Cul, conString);

            Application["db"] = _db;

            if (_db.CheckDBExists(_proyect))
            {
                lbl_3.Text = "true";
                /*
                cbl_1.Visible = true;*/

                /*using (SqlConnection con = new SqlConnection(txtIn_1.Text))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM " + _proyect.Name))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }*/

                _sp = new SP_services().getInstance();

                _varList = new List<string>();
                _variables = new List<Variable>();

                foreach (Variable v in _proyect.Variables)
                {
                    if (v.Name != "y")
                    {
                        _varList.Add(v.Name);
                        _variables.Add(v);
                    }
                    else
                    {
                        _variables.Add(v);
                    }
                }

                ddList_1.DataSource = _varList;
                ddList_1.DataBind();
                ddList_2.DataSource = _sp.Ports;
                ddList_2.DataBind();

                ddList_1.Visible = true;
                ddList_2.Visible = true;
                txtIn_2.Visible = true;
                lbl_5.Visible = true;
                btn_actualizar.Visible = true;

                this.loadTable(_proyect, _varList, _db);
                Table1.Visible = true;
                btn_grafico.Visible = true;
                //cbl_1.DataSource = _variables;
                //cbl_1.DataBind();


                //LoadCharts(_variables, _db, _proyect);
            }

        }

        protected Proyect loadProyect()
        {
            Proyect _proyect = new Proyect();
            Variable _variable;
            lbl_error.Enabled = false;

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
                //this.LoadProyect();
            }
            catch (Exception ex)
            {
                lbl_error.Visible = true;
                lbl_error.Text = "Ha saltado una excepción en loadProyect\n" + ex.Message + "\n" + ex.StackTrace;
            }

            return _proyect;
        }
    
        protected void loadTable(Proyect _p, List<String> _v, DB_services _db)
        {
            TableRowCollection tRows = Table1.Rows;

            foreach(TableRow t in tRows)
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

            String _lastValues = _db.GetLastRowValue(_p, _v);

            string[] values = _lastValues.Split(';');

            for(int i = 0; i < _v.Count; i++)
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

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            try { 
                //SerialPort _port = new SerialPort();
                //_port.PortName = ddList_2.SelectedValue;
                //_sp.SerialPort = _port;
                
                //_sp.SerialPort.Open();
                _sp.SerialPort.WriteLine(ddList_1.SelectedValue + ';' + txtIn_2.Text);
                //_sp.SerialPort.Close();
            }catch(Exception ex)
            {
                lbl_error.Text = "Excepción al actualiar " + ex.Message + "\n" + ex.StackTrace;
                lbl_error.Visible = true;
            }
        }

        protected void btn_grafico_Click(object sender, EventArgs e)
        {
            Server.Transfer("Grafico.aspx", true);
        }
    }

}