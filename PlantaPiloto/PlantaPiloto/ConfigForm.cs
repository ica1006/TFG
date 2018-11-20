using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public partial class ConfigForm : Form
    {
        private MainForm _mainForm;
        private ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;            // declare culture info
        private string _path;
        private FileStream _file;
        private Proyect _proyect;

        public ConfigForm()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _path = @"../../pruebaTFG.txt";
            _proyect = new Proyect();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.switch_language();
        }

        public void switch_language()
        {
            //Cambio de idioma de las cadenas
            #region Actualización de cadenas

            this.Text = _res_man.GetString("ConfigForm_txt", _cul);
            this.lblConfigProName.Text = _res_man.GetString("lblConfigProName_txt", _cul);
            this.lblConfigProDesc.Text = _res_man.GetString("lblConfigProDesc_txt", _cul);
            this.lblVarAccess.Text = _res_man.GetString("lblVarAccess_txt", _cul);
            this.lblVarBoardUnits.Text = _res_man.GetString("lblVarBoardUnits_txt", _cul);
            this.lblVarCommunicationType.Text = _res_man.GetString("lblVarCommunicationType_txt", _cul);
            this.lblVarDesc.Text = _res_man.GetString("lblVarDesc_txt", _cul);
            this.lblVarInterfaceUnits.Text = _res_man.GetString("lblVarInterfaceUnits_txt", _cul);
            this.lblVarLinearAdjust.Text = _res_man.GetString("lblVarLinearAdjust_txt", _cul);
            this.lblVarName.Text = _res_man.GetString("lblVarName_txt", _cul);
            this.lblVarRange.Text = _res_man.GetString("lblVarRange_txt", _cul);
            this.lblVarType.Text = _res_man.GetString("lblVarType_txt", _cul);
            this.lblVectFile.Text = _res_man.GetString("lblVectFile_txt", _cul);
            this.gbNewVar.Text = _res_man.GetString("gbNewVar_txt", _cul);
            this.gbProyectDetails.Text = _res_man.GetString("gbProyectDetails_txt", _cul);
            this.btnAddVar.Text = _res_man.GetString("btnAddVar_txt", _cul);
            this.btnSaveConfig.Text = _res_man.GetString("btnSaveConfig_txt", _cul);
            this.btnLoadImage.Text = _res_man.GetString("btnLoadImage_txt", _cul);

            #endregion
        }

        internal void SetCulture(CultureInfo cultureInfo)
        {
            _cul = cultureInfo;
        }

        private void addNewVar_Click(object sender, EventArgs e)
        {
            Variable _variable = new Variable();
            _variable.Name = this.txtVarName.Text; 
            _variable.Type = this.cbVarType.Text; 
            _variable.Description = this.txtVarDesc.Text;
            _variable.Access = this.cbVarAccess.Text;
            _variable.BoardUnits = this.txtVarBoardUnits.Text; 
            _variable.InterfaceUnits = this.txtVarInterfaceUnits.Text;                 
            _variable.LinearAdjustA = float.Parse(this.txtVarLinearAdjA.Text, CultureInfo.InvariantCulture.NumberFormat);                 
            _variable.LinearAdjustB = float.Parse(this.txtVarLinearAdjB.Text, CultureInfo.InvariantCulture.NumberFormat);                
            _variable.RangeLow = float.Parse(this.txtVarRangeLow.Text, CultureInfo.InvariantCulture.NumberFormat);                
            _variable.RangeHigh= float.Parse(this.txtVarRangeHigh.Text, CultureInfo.InvariantCulture.NumberFormat);                
            _variable.ConnectionType = this.cbVarCommunicationType.Text;               
            _variable.Cul = _cul;

            //Comprobar el número de variables mínimas (no nulas) que hacen falta
            if (_variable.IsAValidVariable())
                _proyect.Variables.Add(_variable);
            else
                MessageBox.Show(_variable.Error);
        }

        private void saveConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                _proyect.Name = this.txtProName.Text;
                _proyect.Description = this.txtProDesc.Text;

                if (_proyect.IsAValidProyect())
                {
                    _file = new FileStream(_path, FileMode.Create);

                    using (TextWriter tw = new StreamWriter(_file))
                    {
                        //Hace falta añadir validaciones
                        tw.WriteLine(DateTime.Now);
                        tw.WriteLine(_proyect.Name);
                        tw.WriteLine(_proyect.Description);
                        foreach (Variable v in _proyect.Variables)
                        {
                            tw.WriteLine("****************************************");
                            tw.WriteLine(v.Name);
                            tw.WriteLine(v.Type);
                            tw.WriteLine(v.Description);
                            tw.WriteLine(v.Access);
                            if (v.Type != "string")
                            {
                                tw.WriteLine(v.BoardUnits);
                                tw.WriteLine(v.InterfaceUnits);
                                tw.WriteLine(v.LinearAdjustA);
                                tw.WriteLine(v.LinearAdjustB);
                                tw.WriteLine(v.RangeLow);
                                tw.WriteLine(v.RangeHigh);
                            }
                            tw.WriteLine(v.ConnectionType);

                        }
                        tw.WriteLine("****************************************");
                        tw.WriteLine("****************************************");
                    }
                }
                else
                {
                    MessageBox.Show(_proyect.Error);
                }
                

                _file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Método que se ejecuta al cerrar el formulario, antes de que este se cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que cambia la disponibilidad de los textbox de ajuste lineal y rango cuando la 
        /// el tipo de variable es una cadena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbVarType_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbVarType.SelectedItem.ToString() == "string")
            {
                txtVarLinearAdjB.Enabled = false;
                txtVarLinearAdjA.Enabled = false;
                txtVarRangeHigh.Enabled = false;
                txtVarRangeLow.Enabled = false;
            }
            else
            {
                txtVarLinearAdjB.Enabled = true;
                txtVarLinearAdjA.Enabled = true;
                txtVarRangeHigh.Enabled = true;
                txtVarRangeLow.Enabled = true;
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            //_proyect.ImagePath = Image.FromFile();
        }
    }
}
