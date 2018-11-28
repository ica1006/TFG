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

namespace PlantaPiloto
{
    public partial class ConfigForm : Form
    {
        private MainForm _mainForm;
        private ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;

        #region Form Methods

        public ConfigForm()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            cbVarType.DataSource = Enum.GetValues(typeof(EnumVarType));
            cbVarAccess.DataSource = Enum.GetValues(typeof(EnumVarAccess));
            cbVarCommunicationType.DataSource = Enum.GetValues(typeof(EnumVarCommunicationType));
            this.Switch_language();
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
                if (ValidateProyect())
                {
                    _proyect.Name = this.txtProName.Text;
                    _proyect.Description = this.txtProDesc.Text;
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
                        this.CreateTableDB(_proyect);
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
        /// Método que crea la tabla donde se van a guardar los datos a partir de las variables del proyecto
        /// </summary>
        /// <param name="pr">Proyecto del que toma los datos</param>
        private void CreateTableDB(Proyect proyect)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=TFG_DB;Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    // Delete table if exists
                    using (SqlCommand command = new SqlCommand("DROP TABLE dbo." + _proyect.Name, con))
                        command.ExecuteNonQuery();
                        // Create table string
                        string sqlStr = "CREATE TABLE " + proyect.Name + "([Id] [int] IDENTITY(1,1) NOT NULL";
                    foreach (Variable v in proyect.Variables)
                    {
                        sqlStr += ", [" + v.Name + "] ";
                        if (v.Type == EnumVarType.String)
                            sqlStr += "[nchar](20) NULL";
                        else
                            sqlStr += "[float] NULL";
                    }
                    sqlStr += ");";

                    // The following code uses an SqlCommand based on the SqlConnection.
                    using (SqlCommand command = new SqlCommand(sqlStr, con))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
        /// Método que controla que el caracter introducido sea un número, "," o ".".
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

        #region Eventos 

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

        private void txtVarLinearAdjA_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumberInput(sender, e);
        }

        private void txtVarLinearAdjB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumberInput(sender, e);
        }

        private void txtVarRangeLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumberInput(sender, e);
        }

        private void txtVarRangeHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumberInput(sender, e);
        }

        #endregion

        #endregion
    }
}
