using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PlantaPiloto.MainForm;

namespace PlantaPiloto
{
    public partial class ConfigForm : Form
    {
        readonly ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;
        readonly DB_services _db_services;
        readonly int _eagerLoading;
        private string _lastVariable;
        private bool _secondLap;
        readonly HelpProvider _helpProvider;
        public event LoadProyectDelegate LoadProyect;

        #region Constructor

        public ConfigForm()
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _db_services = new DB_services();
            _eagerLoading = 0;
            _helpProvider = new HelpProvider();
            _helpProvider.HelpNamespace = Path.Combine(Application.StartupPath, "../../files/helpProyect.chm");
        }

        public ConfigForm(Proyect proyect)
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect
            {
                Name = proyect.Name,
                Description = proyect.Description,
                ImagePath = proyect.ImagePath,
                Cul = proyect.Cul,
            };
            proyect.Variables.ToList().ForEach(p => _proyect.Variables.Add(new Variable()
            {
                Name = p.Name,
                Type = p.Type,
                Description = p.Description,
                Access = p.Access,
                BoardUnits = p.BoardUnits,
                InterfaceUnits = p.InterfaceUnits,
                LinearAdjustA = p.LinearAdjustA,
                LinearAdjustB = p.LinearAdjustB,
                RangeLow = p.RangeLow,
                RangeHigh = p.RangeHigh,
                CommunicationType = p.CommunicationType,
                Value = p.Value,
                Time = p.Time,
                Cul = p.Cul
            }));
            _db_services = new DB_services();
            _eagerLoading = 1;
            _lastVariable = "";
            _secondLap = false;
            _helpProvider = new HelpProvider();
            _helpProvider.HelpNamespace = Path.Combine(Application.StartupPath, "../../files/helpProyect.chm");
        }

        #endregion

        #region Methods

        #region Form Methods

        /// <summary>
        /// Carga de los elementos del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_Load(object sender, EventArgs e)
        {
            switch (_eagerLoading)
            {
                case 0:
                    cbVarType.DataSource = Enum.GetValues(typeof(EnumVarType));
                    cbVarAccess.DataSource = Enum.GetValues(typeof(EnumVarAccess));
                    cbVarCommunicationType.DataSource = Enum.GetValues(typeof(EnumVarCommunicationType));
                    this.lblSelectVar.Visible = false;
                    this.cbSelectVar.Visible = false;
                    this.Switch_language();
                    break;
                case 1:
                    this.cbVarType.DataSource = Enum.GetValues(typeof(EnumVarType));
                    this.cbVarAccess.DataSource = Enum.GetValues(typeof(EnumVarAccess));
                    this.cbVarCommunicationType.DataSource = Enum.GetValues(typeof(EnumVarCommunicationType));
                    this.txtProName.Text = _proyect.Name;
                    this.txtProDesc.Text = _proyect.Description;
                    this.cbSelectVar.DataSource = _proyect.Variables.Select(p => p.Name).ToList();
                    this.btnAddVar.Visible = false;
                    this.Switch_language();
                    break;
                default:
                    cbVarType.DataSource = Enum.GetValues(typeof(EnumVarType));
                    cbVarAccess.DataSource = Enum.GetValues(typeof(EnumVarAccess));
                    cbVarCommunicationType.DataSource = Enum.GetValues(typeof(EnumVarCommunicationType));
                    this.lblSelectVar.Visible = false;
                    this.cbSelectVar.Visible = false;
                    this.Switch_language();
                    break;
            }
        }

        /// <summary>
        /// Método que limpia los campos del formulario
        /// </summary>
        internal void CleanForm(int eagerLoading)
        {
            switch (eagerLoading)
            {
                case 0:
                    foreach (Control c in this.gbNewVar.Controls)
                    {
                        if (c is TextBox || c is RichTextBox)
                        {
                            c.Text = "";
                        }
                    }
                    _variable = new Variable();
                    break;
                case 1:
                    foreach (Control c in this.gbNewVar.Controls)
                    {
                        if (c is TextBox || c is RichTextBox)
                        {
                            c.Text = "";
                        }
                    }
                    _variable = new Variable();

                    foreach (Control c in this.gbProyectDetails.Controls)
                    {
                        if (c is TextBox || c is RichTextBox)
                        {
                            c.Text = "";
                        }
                    }
                    _proyect = new Proyect();
                    break;
                default:
                    foreach (Control c in this.gbNewVar.Controls)
                    {
                        if (c is TextBox || c is RichTextBox)
                        {
                            c.Text = "";
                        }
                    }
                    _variable = new Variable();
                    break;
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

        #endregion

        /// <summary>
        /// Método que actualiza las cadenas según idioma
        /// </summary>
        public void Switch_language()
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
            this.lblSelectVar.Text = _res_man.GetString("lblSelectVar_txt", _cul);
            this.gbNewVar.Text = _res_man.GetString("gbNewVar_txt", _cul);
            this.gbProyectDetails.Text = _res_man.GetString("gbProyectDetails_txt", _cul);
            this.btnAddVar.Text = _res_man.GetString("btnAddVar_txt", _cul);
            this.btnSaveConfig.Text = _res_man.GetString("btnSaveConfig_txt", _cul);
            this.btnLoadImage.Text = _res_man.GetString("btnLoadImage_txt", _cul);
            this.btnExit.Text = _res_man.GetString("btnExit_txt", _cul);

            #endregion
        }

        /// <summary>
        /// Método que establece al form el idioma del MainForm
        /// </summary>
        /// <param name="cultureInfo"></param>
        internal void SetCulture(CultureInfo cultureInfo)
        {
            _cul = cultureInfo;
        }

        /// <summary>
        /// Método que rellena el formulario con los valores de una variable
        /// </summary>
        /// <param name="v">Variable que se va a mostrar</param>
        public void LoadVar(Variable v)
        {
            this.txtVarName.Text = v.Name;
            this.txtVarDesc.Text = v.Description;
            this.cbVarType.SelectedItem = v.Type;
            this.cbVarAccess.SelectedItem = v.Access;
            this.txtVarBoardUnits.Text = v.BoardUnits;
            this.txtVarInterfaceUnits.Text = v.InterfaceUnits;
            this.txtVarLinearAdjA.Text = v.LinearAdjustA.ToString();
            this.txtVarLinearAdjB.Text = v.LinearAdjustB.ToString();
            this.txtVarRangeLow.Text = v.RangeLow.ToString();
            this.txtVarRangeHigh.Text = v.RangeLow.ToString();
            this.cbVarCommunicationType.SelectedItem = v.CommunicationType;
        }

        /// <summary>
        /// Método que actualiza los valores de las propiedades de una variable.
        /// </summary>
        /// <param name="v"></param>
        public void UpdateVar(Variable v)
        {
            try
            {
                _proyect.Variables.Remove(v);
                if (ValidateVar())
                {
                    _variable = new Variable();
                    _variable.Name = this.txtVarName.Text;
                    _variable.Type = (EnumVarType)this.cbVarType.SelectedItem;
                    _variable.Description = this.txtVarDesc.Text;
                    _variable.Access = (EnumVarAccess)this.cbVarAccess.SelectedItem;
                    if (_variable.Type != EnumVarType.String)
                    {
                        _variable.BoardUnits = this.txtVarBoardUnits.Text;
                        _variable.InterfaceUnits = this.txtVarInterfaceUnits.Text;
                        _variable.LinearAdjustA = float.Parse(this.txtVarLinearAdjA.Text, CultureInfo.InvariantCulture.NumberFormat);
                        _variable.LinearAdjustB = float.Parse(this.txtVarLinearAdjB.Text, CultureInfo.InvariantCulture.NumberFormat);
                        _variable.RangeLow = float.Parse(this.txtVarRangeLow.Text, CultureInfo.InvariantCulture.NumberFormat);
                        _variable.RangeHigh = float.Parse(this.txtVarRangeHigh.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    else
                    {
                        _variable.BoardUnits = "";
                        _variable.InterfaceUnits = "";
                        _variable.LinearAdjustA = new float();
                        _variable.LinearAdjustB = new float();
                        _variable.RangeLow = new float();
                        _variable.RangeHigh = new float();
                    }
                    _variable.CommunicationType = (EnumVarCommunicationType)this.cbVarCommunicationType.SelectedItem;
                    _variable.Cul = _cul;

                    _proyect.Variables.Add(_variable);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Validaciones

        /// <summary>
        /// Método que valida que la variable debe tener un nombre y ha de ser único
        /// </summary>
        /// <returns>Devuelve falso si las condiciones no se cumplen</returns>
        internal bool ValidateVar()
        {
            try
            {
                if (this.txtVarName.Text == ""
                    || this._proyect.Variables.Any(p => p.Name == this.txtVarName.Text))
                {
                    if (this.txtVarName.Text == "")
                    {
                        MessageBox.Show(_res_man.GetString("ErrorNoVarName", _cul), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (this._proyect.Variables.Any(p => p.Name == this.txtVarName.Text))
                    {
                        MessageBox.Show(_res_man.GetString("ErrorVarRepeated", _cul), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Método que valida que el nombre del proyecto no esté vacío
        /// </summary>
        /// <returns>Falso si la condición es falsa</returns>
        internal bool ValidateProyect()
        {
            if (this.txtProName.Text == "")
            {
                MessageBox.Show(_res_man.GetString("ErrorNoProyectName", _cul), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (this._proyect.Variables.Count == 0)
            {
                MessageBox.Show(_res_man.GetString("ErrorNoProVars", _cul), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Método que controla que el caracter introducido sea un número o ".".
        /// </summary>
        /// <param name="sender">Elemento que en el que ocurre la acción</param>
        /// <param name="e">Evento que desencadena la acción</param>
        internal void ValidateNumberInput(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // If you want, you can allow decimal (float) numbers
                if ((e.KeyChar == '.') && ((sender as RichTextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        #endregion

        #region Eventos 

        /// <summary>
        /// Método que guarda una nueva variable y la añade a la lista de variables del proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewVar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateVar())
                {
                    _variable = new Variable();
                    _variable.Name = this.txtVarName.Text;
                    _variable.Type = (EnumVarType)this.cbVarType.SelectedItem;
                    _variable.Description = this.txtVarDesc.Text;
                    _variable.Access = (EnumVarAccess)this.cbVarAccess.SelectedItem;
                    if (_variable.Type != EnumVarType.String)
                    {
                        _variable.BoardUnits = this.txtVarBoardUnits.Text;
                        _variable.InterfaceUnits = this.txtVarInterfaceUnits.Text;
                        _variable.LinearAdjustA = float.Parse(this.txtVarLinearAdjA.Text, CultureInfo.InvariantCulture.NumberFormat);
                        _variable.LinearAdjustB = float.Parse(this.txtVarLinearAdjB.Text, CultureInfo.InvariantCulture.NumberFormat);
                        _variable.RangeLow = float.Parse(this.txtVarRangeLow.Text, CultureInfo.InvariantCulture.NumberFormat);
                        _variable.RangeHigh = float.Parse(this.txtVarRangeHigh.Text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    _variable.CommunicationType = (EnumVarCommunicationType)this.cbVarCommunicationType.SelectedItem;
                    _variable.Cul = _cul;

                    _proyect.Variables.Add(_variable);
                    this.CleanForm(0);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que crea y guarda en un archivo txt un nuevo proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                //Actualiza la última variable cargada si el formulario está modificando un proyecto.
                if(_eagerLoading == 1)
                {
                    this.UpdateVar(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
                }
                if (ValidateProyect())
                {
                    _proyect.Name = this.txtProName.Text;
                    _proyect.Description = this.txtProDesc.Text;
                    _proyect.Cul = _cul;
                    saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.FileName = _proyect.Name.ToString() + ".txt";
                    saveFileDialog1.Filter = _res_man.GetString("showDialogFilter", _cul);
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter tw = new StreamWriter(saveFileDialog1.OpenFile());
                        tw.WriteLine(DateTime.Now);
                        tw.WriteLine(_proyect.Name);
                        tw.WriteLine(_proyect.Description);
                        tw.WriteLine(_proyect.ImagePath);
                        foreach (Variable v in _proyect.Variables)
                        {
                            tw.WriteLine("****************************************");
                            tw.WriteLine(v.Name);
                            tw.WriteLine(v.Type);
                            tw.WriteLine(v.Description);
                            tw.WriteLine(v.Access);
                            if (v.Type != EnumVarType.String)
                            {
                                tw.WriteLine(v.BoardUnits);
                                tw.WriteLine(v.InterfaceUnits);
                                tw.WriteLine(v.LinearAdjustA);
                                tw.WriteLine(v.LinearAdjustB);
                                tw.WriteLine(v.RangeLow);
                                tw.WriteLine(v.RangeHigh);
                            }
                            tw.WriteLine(v.CommunicationType);

                        }
                        tw.WriteLine("****************************************");
                        tw.WriteLine("****************************************");
                        tw.Dispose();
                        tw.Close();
                        this.LoadProyect(_proyect);
                        this.CleanForm(1);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que carga la ruta de una imagen e informa que esta ha sido cargada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = _res_man.GetString("showLoadImageDialogTitle", _cul);
            openFileDialog1.Filter = _res_man.GetString("showLoadImageDialogFilter", _cul);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _proyect.ImagePath = openFileDialog1.FileName;
                this.btnLoadImage.BackColor = Color.LightGreen;
            }
        }

        /// <summary>
        /// Evento que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.CleanForm(1);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((EnumVarType)cbVarType.SelectedItem == EnumVarType.String)
            {
                txtVarLinearAdjB.Enabled = false;
                txtVarLinearAdjA.Enabled = false;
                txtVarRangeHigh.Enabled = false;
                txtVarRangeLow.Enabled = false;
                txtVarBoardUnits.Enabled = false;
                txtVarInterfaceUnits.Enabled = false;
            }
            else
            {
                txtVarLinearAdjB.Enabled = true;
                txtVarLinearAdjA.Enabled = true;
                txtVarRangeHigh.Enabled = true;
                txtVarRangeLow.Enabled = true;
                txtVarBoardUnits.Enabled = true;
                txtVarInterfaceUnits.Enabled = true;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar el valor del comboBox que contiene las variables del proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSelectVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_secondLap)
                {
                    if (_lastVariable != "")
                        this.UpdateVar(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
                    _lastVariable = (sender as ComboBox).SelectedValue.ToString();
                    this.LoadVar(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
                }
                _secondLap = true;
                this.cbSelectVar.DataSource = _proyect.Variables.Select(p => p.Name).ToList();
                _secondLap = false;
                this.cbSelectVar.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Evento que abre la ayuda para el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "Formulario Configuración");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #endregion
    }
}
