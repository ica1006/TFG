using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.IO;
using PlantaPiloto.Enums;

namespace PlantaPiloto
{
    public partial class MainForm : Form
    {
        ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;

        public MainForm()
        {
            InitializeComponent();

            toolStripMenuItemSpanish.Checked = true;
            toolStripMenuItemEnglish.Checked = false;//default language is spanish
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _variable = new Variable();
            Switch_language();
        }

        /// <summary>
        /// Método que carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            //cboPort.SelectedIndex = 0;
            btnClose.Enabled = false;
        }

        /// <summary>
        /// Método encargado de abrir una conexión con el puerto serie elegido en el comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            try
            {
                serialPort2.PortName = cboPort.Text;
                serialPort2.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método encargado de enviar un mensaje a través del puerto serie con el que se tiene conexión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort2.IsOpen)
                {
                    serialPort2.WriteLine(txtMessage.Text);
                    txtMessage.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que cierra la conexión con el puerto serie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            try
            {
                serialPort2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que recibe por el puerto serie y lo muestra en el txtBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            ;
            try
            {
                txtReceive.Clear();
                if (serialPort2.IsOpen)
                {
                    txtReceive.Text = serialPort2.ReadExisting() + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }
        }

        /// <summary>
        /// Método que se encarga de actualizar todas las etiquetas del form a la cultura correspondiente
        /// </summary>
        public void Switch_language()
        {
            if (toolStripMenuItemSpanish.Checked == true)
            {
                _cul = CultureInfo.CreateSpecificCulture("es");    //create culture for spanish
            }
            else                                                //in english
            {
                _cul = CultureInfo.CreateSpecificCulture("en");     //create culture for english
            }

            //Cambio de idioma de las cadenas
            #region Actualización de cadenas

            this.Text = _res_man.GetString("MainForm_txt", _cul);
            this.toolStripMenuItemAbout.Text = _res_man.GetString("toolStripMenuItemAbout_txt", _cul);
            this.toolStripMenuItemCommunication.Text = _res_man.GetString("toolStripMenuItemCommunication_txt", _cul);
            this.toolStripMenuItemConfig.Text = _res_man.GetString("toolStripMenuItemConfig_txt", _cul);
            this.toolStripMenuItemEnglish.Text = _res_man.GetString("toolStripMenuItemEnglish_txt", _cul);
            this.toolStripMenuItemHelp.Text = _res_man.GetString("toolStripMenuItemHelp_txt", _cul);
            this.toolStripMenuItemHelpHelp.Text = _res_man.GetString("toolStripMenuItemHelpHelp_txt", _cul);
            this.toolStripMenuItemLanguage.Text = _res_man.GetString("toolStripMenuItemLanguage_txt", _cul);
            this.toolStripMenuItemLoadConfig.Text = _res_man.GetString("toolStripMenuItemLoadConfig_txt", _cul);
            this.toolStripMenuItemCreateConfig.Text = _res_man.GetString("toolStripMenuItemCreateConfig_txt", _cul);
            this.toolStripMenuItemModifyConfig.Text = _res_man.GetString("toolStripMenuItemModifyConfig_txt", _cul);
            this.toolStripMenuItemOthers.Text = _res_man.GetString("toolStripMenuItemOthers_txt", _cul);
            this.toolStripMenuItemSerie.Text = _res_man.GetString("toolStripMenuItemSerie_txt", _cul);
            this.toolStripMenuItemSpanish.Text = _res_man.GetString("toolStripMenuItemSpanish_txt", _cul);
            this.lblPorts.Text = _res_man.GetString("lblPorts_txt", _cul);
            this.lblReceive.Text = _res_man.GetString("lblReceive_txt", _cul);
            this.lblSend.Text = _res_man.GetString("lblSend_txt", _cul);
            this.btnClose.Text = _res_man.GetString("btnClose_txt", _cul);
            this.btnOpen.Text = _res_man.GetString("btnOpen_txt", _cul);
            this.btnReceive.Text = _res_man.GetString("btnReceive_txt", _cul);
            this.btnSend.Text = _res_man.GetString("btnSend_txt", _cul);
            this.btnStart.Text = _res_man.GetString("btnStart_txt", _cul);
            this.btnFinish.Text = _res_man.GetString("btnFinish_txt", _cul);
            this.btnChart.Text = _res_man.GetString("btnChart_txt", _cul);
            this.btnVar.Text = _res_man.GetString("btnVar_txt", _cul);
            this.btnFile.Text = _res_man.GetString("btnFile_txt", _cul);
            this.lblProDesc.Text = _res_man.GetString("lblProDesc_txt", _cul);
            this.lblProName.Text = _res_man.GetString("lblProName_txt", _cul);
            this.gBoxControls.Text = _res_man.GetString("gBoxControls_txt", _cul);
            this.gBoxProyect.Text = _res_man.GetString("gBoxProyect_txt", _cul);

            #endregion
        }

        /// <summary>
        /// Método que cambia el idioma a inglés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItemSpanish.Checked = false;
            toolStripMenuItemEnglish.Checked = true;
            Switch_language();
        }

        /// <summary>
        /// Método que cambia el idioma a español
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSpanish_Click(object sender, EventArgs e)
        {
            toolStripMenuItemSpanish.Checked = true;
            toolStripMenuItemEnglish.Checked = false;
            Switch_language();
        }

        /// <summary>
        /// Método que devuelve el idioma seleccionado
        /// </summary>
        /// <returns></returns>
        public CultureInfo getCulture()
        {
            return this._cul;
        }

        /// <summary>
        /// Método que abre la ventana para introducir una nueva configuración
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCreateConfig_Click(object sender, EventArgs e)
        {
            ConfigForm _createConfig = new ConfigForm();
            _createConfig.MdiParent = this.MdiParent;
            _createConfig.SetCulture(this.getCulture());
            _createConfig.Show();
        }

        private void toolStripMenuItemLoadConfig_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = _res_man.GetString("showDialogFilter", _cul);
            openFileDialog1.Title = _res_man.GetString("showDialogTitle", _cul);
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
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
                    MessageBox.Show(_res_man.GetString("ErrorFileNoValid", _cul) + "\n" + ex.Message.ToString(),
                        _res_man.GetString("ErrorFileNoValid", _cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }
    }
}
