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
using System.Threading;
using System.Timers;

namespace PlantaPiloto
{
    public partial class MainForm : Form
    {
        ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;
        private DB_services _db_services;
        private SP_services _sp_services;
        private Thread _threadSaveRow;
        private Thread _threadSaveFile;
        private System.Timers.Timer _timerRefreshDataGrid;
        private Proyect _lastRowSP;
        delegate void StringArgReturningVoidDelegate(Proyect rows);
        delegate void ShowButtonsDelegate();
        public delegate void SaveFileDelegate(List<Variable> vars);

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            toolStripMenuItemSpanish.Checked = true;
            toolStripMenuItemEnglish.Checked = false;//default language is spanish
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _variable = new Variable();
            _db_services = new DB_services();
            Switch_language();
            _timerRefreshDataGrid = new System.Timers.Timer(2000);
            _timerRefreshDataGrid.Enabled = false;
            _timerRefreshDataGrid.Elapsed += new ElapsedEventHandler(this.TimerElapsedEvent);
            dgvProVars.Columns[0].ReadOnly = true;
            dgvProVars.Columns[1].ReadOnly = true;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Evento que se invoca al cargar el formulario. Carga los elementos necesarios para conformar la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            _sp_services = new SP_services();
            this.LoadPorts();
            this.ViewNoProyect();
        }

        /// <summary>
        /// Evento que se ejecuta al cerrarse (justo antes) el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timerRefreshDataGrid.Enabled = false;
            if (_sp_services != null && _sp_services.SerialPort.IsOpen)
                _sp_services.SerialPort.Close();
            if (_threadSaveRow != null && _threadSaveRow.IsAlive)
                _threadSaveRow.Abort(); ;
            if (_threadSaveFile != null && _threadSaveFile.IsAlive)
                _threadSaveFile.Abort();
        }

        #endregion

        #region Methods

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
            this.lblProDesc.Text = _res_man.GetString("lblProDesc_txt", _cul);
            this.lblProName.Text = _res_man.GetString("lblProName_txt", _cul);
            this.lblRWVariables.Text = _res_man.GetString("lblRWVariables_txt", _cul);
            this.btnStart.Text = _res_man.GetString("btnStart_txt", _cul);
            this.btnFinish.Text = _res_man.GetString("btnFinish_txt", _cul);
            this.btnChart.Text = _res_man.GetString("btnChart_txt", _cul);
            this.btnVar.Text = _res_man.GetString("btnVar_txt", _cul);
            if(_sp_services == null || !_sp_services.SaveFile)
                this.btnFile.Text = _res_man.GetString("btnFile_txt", _cul);
            else
                this.btnFile.Text = _res_man.GetString("btnFileStop_txt", _cul);
            this.btnRefreshPorts.Text = _res_man.GetString("btnRefreshPorts_txt", _cul);
            this.gBoxControls.Text = _res_man.GetString("gBoxControls_txt", _cul);
            this.gBoxProyect.Text = _res_man.GetString("gBoxProyect_txt", _cul);
            this.dgvProVars.Columns[0].Name = _res_man.GetString("dgvColumnVarName", _cul);
            this.dgvProVars.Columns[1].Name = _res_man.GetString("dgvColumnVarOldValue", _cul);
            this.dgvProVars.Columns[2].Name = _res_man.GetString("dgvColumnVarNewValue", _cul);

            #endregion
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
        /// Método que carga el proyecto recibido en la aplicación
        /// </summary>
        private void LoadProyect()
        {
            try
            {
                if (_proyect.Name != null)
                {
                    //Creamos la tabla en la BD para el proyecto
                    _db_services.CreateTableDB(_proyect);

                    //Mostramos datos
                    this.ViewConnectionClose();
                    this.lblProName.Text = _res_man.GetString("lblProName_txt", _cul) + " " + _proyect.Name;
                    this.lblProDesc.Text = _res_man.GetString("lblProDesc_txt", _cul) + " " + _proyect.Description;
                    this.pbProImg.Image = Image.FromFile(_proyect.ImagePath);
                    //Se muestran sólo las variables que son de escritura
                    this.dgvProVars.Rows.Clear();
                    this.dgvProVars.Rows.Add(_proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).Count());
                    for (int i = 0; i < _proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).Count(); i++)
                        this.dgvProVars[0, i].Value = _proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).ToList()[i].Name;

                    //ConfigForm c = new ConfigForm();
                    //var iniDrawX = gbProVars.Location.X - gbProVars.Width;
                    //var iniDrawY = gbProVars.Location.Y + 20;

                    //foreach (Variable v in _proyect.Variables)
                    //{
                    //    Label lblVar = new Label();
                    //    lblVar.Name = "lblVar" + v.Name;
                    //    lblVar.Text = v.Name;
                    //    iniDrawY += 20;
                    //    lblVar.Location = new System.Drawing.Point(iniDrawX, iniDrawY);
                    //    gbProVars.Controls.Add(lblVar);
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Sobrecarga del método LoadProyect() para poder recibir un proyecto como parámetro
        /// </summary>
        /// <param name="pr">Proyecto para cargar en MainForm</param>
        public void LoadProyect(Proyect pr)
        {
            _proyect = pr;
            this.LoadProyect();
        }

        /// <summary>
        /// Método que carga los puertos serie activos en el equipo en el ComboBox
        /// </summary>
        public void LoadPorts()
        {
            _sp_services = new SP_services();
            string[] ports = _sp_services.Ports;
            cboPort.Items.Clear();
            cboPort.Items.AddRange(ports);
            if (cboPort.Items.Count > 0)
            {
                cboPort.SelectedIndex = 0;
                if (_proyect.Name != null)
                    this.ViewConnectionClose();
            }
            else
            {
                if (_proyect.Name != null)
                    this.ViewConnectionClose();
                else
                    this.ViewNoProyect();
            }
        }

        /// <summary>
        /// Método que rellena el data grid view con las variables modificables del proyecto
        /// </summary>
        private void TimerElapsedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                _lastRowSP = _sp_services.LastRow;
                if (_lastRowSP.Variables.Where(p => p.Value == null).Count() == 0)
                {
                    this.FillDataGridView(_lastRowSP);
                    this.ViewConnectionOpen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que actualiza la columna del dataGrid que contiene los valores actuales que recibe de la placa
        /// </summary>
        /// <param name="rows">Proyecto que guarda todas las variables con su último valor</param>
        private void FillDataGridView(Proyect rows)
        {
            try
            {
                if (this.dgvProVars.InvokeRequired)
                {
                    //Para evitar concurrencia se llama a un delegado puesto que los datos se han obtenido en otro hilo
                    StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(FillDataGridView);
                    this.Invoke(d, new object[] { rows });
                }
                else
                {
                    for (int j = 0; j < dgvProVars.Rows.Count; j++)
                        for (int i = 0; i < rows.Variables.Count; i++)
                            if (dgvProVars[0, j].Value.ToString() == rows.Variables[i].Name)
                                dgvProVars[1, j].Value = rows.Variables[i].Value;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que envía el valor de una nueva variable al puerto serie
        /// </summary>
        /// <param name="cell">Celda que contiene el nuevo valor de la variable</param>
        private void SendVarSP(DataGridViewCellEventArgs cell)
        {
            try
            {
                if (_proyect.Variables.FirstOrDefault(p => p.Name == dgvProVars[0, cell.RowIndex].Value.ToString()).Type != EnumVarType.String)
                {
                    float val;
                    if (float.TryParse(dgvProVars[cell.ColumnIndex, cell.RowIndex].Value.ToString(), out val))
                    {
                        _sp_services.SerialPort.WriteLine(dgvProVars[0, cell.RowIndex].Value.ToString() + ";"
                            + dgvProVars[cell.ColumnIndex, cell.RowIndex].Value.ToString());
                    }
                }
                else
                    _sp_services.SerialPort.WriteLine(dgvProVars[0, cell.RowIndex].Value.ToString() + ";"
                                    + dgvProVars[cell.ColumnIndex, cell.RowIndex].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que crea el archivo y la cabecera del archivo donde se van a guardar las variables
        /// y activa el guardado de variables
        /// </summary>
        /// <param name="vars">Variables que van a ser guardadas</param>
        public void SaveFile(List<Variable> vars)
        {
            try
            {
                if (vars.Count() > 0)
                {
                    SaveFileDialog saveFileDialog1;
                    saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.FileName = _proyect.Name.ToString();
                    foreach (Variable v in vars)
                        saveFileDialog1.FileName += "_" + v.Name;
                    saveFileDialog1.FileName += ".txt";
                    saveFileDialog1.Filter = _res_man.GetString("showDialogFilter", _cul);
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter tw = new StreamWriter(saveFileDialog1.OpenFile());
                        tw.WriteLine(DateTime.Now);
                        tw.WriteLine(_proyect.Name);
                        tw.WriteLine(_proyect.Description);
                        tw.WriteLine(_proyect.ImagePath);
                        tw.WriteLine("****************************************");
                        string varNames = "";
                        vars.ForEach(p => varNames += p.Name + ";");
                        tw.WriteLine(varNames);
                        tw.Dispose();
                        tw.Close();
                        if (_sp_services != null)
                        {
                            _sp_services.FilePath = saveFileDialog1.FileName;
                            _sp_services.SaveFile = true;
                        }
                        this.btnFile.Text = _res_man.GetString("btnFileStop_txt", _cul);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos modificadores del estado de los elementos de la vista

        /// <summary>
        /// Método que establece la visibilidad o estado de los elementos de la vista cuando 
        /// la aplicación no tiene cargado un proyecto.
        /// </summary>
        private void ViewNoProyect()
        {
            btnStart.Enabled = false;
            btnFinish.Enabled = false;
            btnChart.Enabled = false;
            btnVar.Enabled = false;
            btnFile.Enabled = false;
            btnRefreshPorts.Enabled = true;
            cboPort.Enabled = true;
            lblProName.Visible = false;
            lblProDesc.Visible = false;
            lblRWVariables.Visible = false;
            dgvProVars.Visible = false;
        }

        /// <summary>
        /// Método que establece la visibilidad o estado de los elementos de la vista cuando 
        /// la aplicación no tiene cargado un proyecto.
        /// </summary>
        private void ViewNoConnection()
        {
            btnStart.Enabled = false;
            btnFinish.Enabled = false;
            btnChart.Enabled = false;
            btnVar.Enabled = false;
            btnFile.Enabled = false;
            btnRefreshPorts.Enabled = true;
            cboPort.Enabled = true;
            lblProName.Visible = true;
            lblProDesc.Visible = true;
            lblRWVariables.Visible = true;
            dgvProVars.Visible = true;
        }

        /// <summary>
        /// Método que establece la visibilidad o estado de los elementos de la vista cuando 
        /// la aplicación tiene cargado un proyecto y la conexión con el puerto serie abierta.
        /// </summary>
        private void ViewConnectionOpen()
        {
            try
            {
                if (this.gBoxControls.InvokeRequired)
                {
                    //Para evitar concurrencia se llama a un delegado puesto que los datos se han obtenido en otro hilo
                    ShowButtonsDelegate d = new ShowButtonsDelegate(ViewConnectionOpen);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    btnStart.Enabled = false;
                    btnFinish.Enabled = true;
                    if (_lastRowSP != null && _lastRowSP.Variables.Where(p => p.Value == null).Count() == 0)
                    {
                        btnChart.Enabled = true;
                        btnVar.Enabled = true;
                        btnFile.Enabled = true;
                    }
                    else
                    {
                        btnChart.Enabled = false;
                        btnVar.Enabled = false;
                        btnFile.Enabled = false;
                    }
                    btnRefreshPorts.Enabled = false;
                    cboPort.Enabled = false;
                    lblProName.Visible = true;
                    lblRWVariables.Visible = true;
                    lblProDesc.Visible = true;
                    dgvProVars.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que establece la visibilidad o estado de los elementos de la vista cuando 
        /// la aplicación tiene cargado un proyecto y la conexión con el puerto serie cerrada.
        /// </summary>
        private void ViewConnectionClose()
        {
            if (cboPort.Items.Count != 0)
            {
                btnStart.Enabled = true;
                btnFinish.Enabled = false;
                btnChart.Enabled = false;
                btnVar.Enabled = false;
                btnFile.Enabled = false;
                btnRefreshPorts.Enabled = true;
                cboPort.Enabled = true;
                lblProName.Visible = true;
                lblProDesc.Visible = true;
                lblRWVariables.Visible = true;
                dgvProVars.Visible = true;
            }
            else
            {
                btnStart.Enabled = false;
                btnFinish.Enabled = false;
                btnChart.Enabled = true;
                btnVar.Enabled = true;
                btnFile.Enabled = true;
                btnRefreshPorts.Enabled = true;
                cboPort.Enabled = true;
                lblProName.Visible = true;
                lblProDesc.Visible = true;
                lblRWVariables.Visible = true;
                dgvProVars.Visible = true;
            }
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Método encargado de abrir una conexión con el puerto serie elegido en el comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _sp_services = new SP_services(_proyect, _cul);
                _sp_services.SerialPort.PortName = cboPort.Text;
                _threadSaveRow = new Thread(() => _sp_services.OpenConnection());
                _threadSaveRow.Start();
                this.ViewConnectionOpen();
                this._timerRefreshDataGrid.Enabled = true;
            }
            catch (Exception ex)
            {
                this.ViewConnectionClose();
                MessageBox.Show(ex.Message, _res_man.GetString("ErrorSerialPortConnectionKey", _cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que cierra la conexión con el puerto serie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                _sp_services.CloseConnection();
                _timerRefreshDataGrid.Enabled = false;
                _threadSaveRow.Abort();
                _sp_services.SaveFile = false;
                this.ViewConnectionClose();
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
            try
            {
                //txtReceive.Clear();
                //if (_sp_services.SerialPort.IsOpen)
                //{
                //    txtReceive.Text = _sp_services.SerialPort.ReadLine() + Environment.NewLine;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        /// <summary>
        /// Evento que lee un archivo en el que está guardada una configuración y la carga al programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemLoadConfig_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = _res_man.GetString("showDialogFilter", _cul);
            openFileDialog1.Title = _res_man.GetString("showDialogTitle", _cul);
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
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
                    this.LoadProyect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(_res_man.GetString("ErrorFileNoValid", _cul) + "\n" + ex.Message.ToString(),
                        _res_man.GetString("ErrorFileNoValid", _cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void toolStripMenuItemModifyConfig_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Evento que atiende al botón de gráfica. Abre una ventana donde se seleccionan las variables a mostrar en gráficas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChart_Click(object sender, EventArgs e)
        {
            _proyect.Variables.ToList().ForEach(p => p.Value = _lastRowSP.Variables.FirstOrDefault(q => q.Name == p.Name).Value);
            VarSelection _varSelection = new VarSelection(_proyect, EnumVarSelection.Chart, this.getCulture());
            _varSelection.MdiParent = this.MdiParent;
            _varSelection.Show();
        }

        /// <summary>
        /// Evento que se ejecuta cuando el botón Archivo es pulsado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFile_Click(object sender, EventArgs e)
        {
            if (_sp_services.SaveFile)
            {
                _sp_services.SaveFile = false;
                this.btnFile.Text = _res_man.GetString("btnFile_txt", _cul);
            }
            else
            {
                _proyect.Variables.ToList().ForEach(p => p.Value = _lastRowSP.Variables.FirstOrDefault(q => q.Name == p.Name).Value);
                VarSelection _varSelection = new VarSelection(_proyect, EnumVarSelection.File, this.getCulture());
                _varSelection.MdiParent = this.MdiParent;
                _varSelection.Save_file += new SaveFileDelegate(SaveFile);
                _varSelection.Show();
            }
        }

        /// <summary>
        /// Evento que atiende al botón de Variables. Abre una ventana donde se muestran todas las variables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVar_Click(object sender, EventArgs e)
        {
            _proyect.Variables.ToList().ForEach(p => p.Value = _lastRowSP.Variables.FirstOrDefault(q => q.Name == p.Name).Value);
            if (_proyect.Variables.Count(p => p.Value == null) == 0)
            {
                VarSelection _varSelection = new VarSelection(_proyect, EnumVarSelection.Vars, this.getCulture());
                _varSelection.MdiParent = this.MdiParent;
                _varSelection.Show();
            }
        }

        /// <summary>
        /// Evento que recoge la llamada para actualizar la lista de puertos serie activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            this.LoadPorts();
        }

        /// <summary>
        /// Evento que actúa al cambiar el valor de una celda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProVars_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2 && dgvProVars[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                {
                    var c = dgvProVars[e.ColumnIndex, e.RowIndex].Value.ToString();
                    this.SendVarSP(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}
