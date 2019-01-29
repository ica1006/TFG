using PlantaPiloto.Classes;
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
        readonly CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;
        readonly DB_services _db_services;
        readonly int _eagerLoading;
        private string _lastVariable;
        readonly HelpProvider _helpProvider;
        public event LoadProyectDelegate LoadProyect;
        readonly ExceptionManagement _exMg;
        readonly FileSaver _fileSaver;
        readonly string _filesPath;
        readonly string _configsPath;

        #region Constructor

        public ConfigForm(CultureInfo cul)
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _db_services = new DB_services(_cul);
            _eagerLoading = 0;
            _helpProvider = new HelpProvider();
            _filesPath = GlobalParameters.FilesPath;
            _configsPath = GlobalParameters.ConfigsPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _cul = cul;
            _exMg = new ExceptionManagement(_cul);
            _fileSaver = new FileSaver();
        }

        public ConfigForm(Proyect proyect, CultureInfo cul)
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = proyect;
            _cul = cul;
            _db_services = new DB_services(_cul);
            _exMg = new ExceptionManagement(_cul);
            _eagerLoading = 1;
            _lastVariable = "";
            _filesPath = GlobalParameters.FilesPath;
            _helpProvider = new HelpProvider();
            _configsPath = GlobalParameters.ConfigsPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _fileSaver = new FileSaver();
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
            cbVarType.DataSource = Enum.GetValues(typeof(EnumVarType));
            cbVarAccess.DataSource = Enum.GetValues(typeof(EnumVarAccess));
            cbVarCommunicationType.DataSource = Enum.GetValues(typeof(EnumVarCommunicationType));

            //Modificar configuración
            if (_eagerLoading == 1)
            {
                this.txtProName.Text = _proyect.Name;
                this.txtProDesc.Text = _proyect.Description;
                this.cbSelectVar.DataSource = _proyect.Variables.Select(p => p.Name).ToList();
            }
            //Crear configuración
            else
            {
                this.lblSelectVar.Visible = false;
                this.cbSelectVar.Visible = false;
            }
            this.Switch_language();
        }

        /// <summary>
        /// Método que limpia los campos del formulario
        /// </summary>
        internal void CleanForm(int eagerLoading)
        {
            CleanVarForm();
            if (eagerLoading == 1)
            {
                foreach (Control c in this.gbProyectDetails.Controls)
                {
                    if (c is TextBox || c is RichTextBox)
                    {
                        c.Text = "";
                    }
                }
                _proyect = new Proyect();
            }
        }

        /// <summary>
        /// Método que limpia los cuadros de texto correspondientes a variable 
        /// y crea una nueva variable interna.
        /// </summary>
        private void CleanVarForm()
        {
            foreach (Control c in this.gbNewVar.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            _variable = new Variable();
        }

        #endregion

        /// <summary>
        /// Método que actualiza las cadenas según idioma
        /// </summary>
        public void Switch_language()
        {
            //Cambio de idioma de las cadenas
            #region Actualización de cadenas

            if (_eagerLoading == 1)
            {
                this.Text = _res_man.GetString("ConfigFormModify_txt", _cul);
                this.btnAddVar.Text = _res_man.GetString("btnAddVarModify_txt", _cul);
            }
            if (_eagerLoading == 0)
            {
                this.Text = _res_man.GetString("ConfigFormCreate_txt", _cul);
                this.btnAddVar.Text = _res_man.GetString("btnAddVar_txt", _cul);
            }
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
            this.btnSaveConfig.Text = _res_man.GetString("btnSaveConfig_txt", _cul);
            this.btnLoadImage.Text = _res_man.GetString("btnLoadImage_txt", _cul);
            this.btnExit.Text = _res_man.GetString("btnExit_txt", _cul);

            #endregion
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
            this.txtVarRangeHigh.Text = v.RangeHigh.ToString();
            this.cbVarCommunicationType.SelectedItem = v.CommunicationType;
            _variable = v;
        }

        /// <summary>
        /// Método que actualiza los valores de las propiedades de una variable.
        /// </summary>
        /// <param name="v"></param>
        public void UpdateVar(String varOldName)
        {
            try
            {
                varOldName = _variable.Name;
                _proyect.Variables.Add(_variable);
                this.cbSelectVar.DataSource = _proyect.Variables.Select(p => p.Name).ToList();
                this.cbSelectVar.SelectedIndex = _proyect.Variables.Count - 1;

            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que recibe una las propiedades de una variable y las cargas en la propiedad de la clase principal.
        /// </summary>
        public void LoadVariableFromForm()
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
                _variable.LinearAdjustA = null;
                _variable.LinearAdjustB = null;
                _variable.RangeLow = null;
                _variable.RangeHigh = null;
            }
            _variable.CommunicationType = (EnumVarCommunicationType)this.cbVarCommunicationType.SelectedItem;
            _variable.Cul = _cul;
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
                    || this._proyect.Variables.Any(p => p.Name == this.txtVarName.Text)
                    || ((EnumVarType)cbVarType.SelectedItem != EnumVarType.String && (this.txtVarRangeHigh.Text == "" || this.txtVarRangeLow.Text == "")))
                {
                    if (this.txtVarName.Text == "")
                    {
                        MessageBox.Show(_res_man.GetString("ErrorNoVarName", _cul), _res_man.GetString("ErrorVarTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (this._proyect.Variables.Any(p => p.Name == this.txtVarName.Text))
                    {
                        MessageBox.Show(_res_man.GetString("ErrorVarRepeated", _cul), _res_man.GetString("ErrorVarTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if ((EnumVarType)cbVarType.SelectedItem != EnumVarType.String && (this.txtVarRangeHigh.Text == "" || this.txtVarRangeLow.Text == ""))
                    {
                        MessageBox.Show(_res_man.GetString("ErrorNoVarRange", _cul), _res_man.GetString("ErrorVarTitle"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
                _exMg.HandleException(ex);
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
                if (_eagerLoading == 1)
                {
                    _proyect.Variables.Remove(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
                    if (ValidateVar())
                    {
                        LoadVariableFromForm();
                        UpdateVar(_lastVariable);
                    }
                }
                else
                {
                    if (ValidateVar())
                    {
                        LoadVariableFromForm();
                        _proyect.Variables.Add(_variable);
                        this.CleanForm(0);
                    }
                }
            }
            catch (FormatException ex)
            {
                _exMg.HandleException(ex);
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
                if (ValidateProyect())
                {
                    _proyect.Name = this.txtProName.Text;
                    _proyect.Description = this.txtProDesc.Text;
                    _proyect.Cul = _cul;
                    saveFileDialog1 = new SaveFileDialog();
                    if (!Directory.Exists(_configsPath))
                        Directory.CreateDirectory(_configsPath);
                    saveFileDialog1.InitialDirectory = _configsPath;
                    saveFileDialog1.FileName = _proyect.Name.ToString() + ".txt";
                    saveFileDialog1.Filter = _res_man.GetString("showDialogFilter", _cul);
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(saveFileDialog1.FileName))
                            File.Delete(saveFileDialog1.FileName);
                        using (StreamWriter tw = new StreamWriter(saveFileDialog1.OpenFile()))
                        {
                            _fileSaver.WriteProyectProperties(tw, _proyect, saveFileDialog1.FileName);
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
                            tw.Close();
                        }
                        this.LoadProyect(_proyect);
                        this.CleanForm(1);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(_res_man.GetString("ErrorImage", _cul), _res_man.GetString("ErrorImgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _exMg.HandleException(ex);
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
                _exMg.HandleException(ex);
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
                //if (!_secondLap)
                //{
                //    if (_lastVariable != "")
                //        this.UpdateVar(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
                //    _lastVariable = (sender as ComboBox).SelectedValue.ToString();
                //    this.LoadVar(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
                //}
                //_secondLap = true;
                //this.cbSelectVar.DataSource = _proyect.Variables.Select(p => p.Name).ToList();
                //_secondLap = false;
                //this.cbSelectVar.Refresh();

                _lastVariable = (sender as ComboBox).SelectedValue.ToString();
                this.LoadVar(_proyect.Variables.FirstOrDefault(p => p.Name == _lastVariable));
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        #endregion

        #endregion
    }
}
