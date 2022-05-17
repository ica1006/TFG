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
using System.Diagnostics;
using PlantaPiloto.Classes;
using PlantaPiloto.Forms;

namespace PlantaPiloto
{
    public partial class MainForm : Form
    {
        #region Properties
        readonly ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;
        readonly DB_services _db_services;
        private SP_services _sp_services;
        private Thread _threadSaveRow;
        readonly System.Timers.Timer _timerRefreshDataGrid;
        readonly System.Timers.Timer _timerSaveFile;
        private Proyect _lastRowSP;
        readonly string _pdfPath;
        readonly HelpProvider _helpProvider;
        readonly ExceptionManagement _exMg;
        delegate void StringArgReturningVoidDelegate(Proyect rows);
        delegate void ShowButtonsDelegate();
        public delegate void SaveFileDelegate(List<Variable> vars);
        public delegate void ShowChartDelegate(List<Variable> vars);
        public delegate void LoadProyectDelegate(Proyect proyect);
        readonly FileSaver _fileSaver;
        readonly string _filesPath;
        readonly string _configsPath;
        private string _saveFilePath;

        public static MainForm instance;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            toolStripMenuItemSpanish.Checked = true;
            toolStripMenuItemEnglish.Checked = false;//default language is spanish
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _variable = new Variable();
            _db_services = new DB_services(_cul);
            Switch_language();
            _timerRefreshDataGrid = new System.Timers.Timer(2000);
            _timerRefreshDataGrid.Enabled = false;
            _timerRefreshDataGrid.Elapsed += this.TimerElapsedEvent;
            _timerSaveFile = new System.Timers.Timer(2000);
            _timerSaveFile.Enabled = false;
            _timerSaveFile.Elapsed += this.TimerSaveFile;
            dgvProVars.Columns[0].ReadOnly = true;
            dgvProVars.Columns[1].ReadOnly = true;
            _helpProvider = new HelpProvider();
            _configsPath = GlobalParameters.ConfigsPath;
            _filesPath = GlobalParameters.FilesPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _pdfPath = Path.Combine(_filesPath, "Manual_Usuario.pdf");
            _exMg = new ExceptionManagement(_cul);
            _fileSaver = new FileSaver();
            instance = this;
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
        /// Evento que se ejecuta al cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_sp_services.SerialPort.IsOpen)
                _sp_services.CloseConnection();
            this.Dispose();
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
            this.userManualToolStripMenuItem.Text = _res_man.GetString("toolStripMenuItemUserManual_txt", _cul);
            this.lblPorts.Text = _res_man.GetString("lblPorts_txt", _cul);
            this.lblProDesc.Text = _res_man.GetString("lblProDesc_txt", _cul);
            this.lblProName.Text = _res_man.GetString("lblProName_txt", _cul);
            if (_proyect != null)
            {
                this.lblProName.Text += " " + _proyect.Name;
                this.lblProDesc.Text += " " + _proyect.Description;
            }
            this.lblRWVariables.Text = _res_man.GetString("lblRWVariables_txt", _cul);
            this.btnStart.Text = _res_man.GetString("btnStart_txt", _cul);
            this.btnFinish.Text = _res_man.GetString("btnFinish_txt", _cul);
            this.btnChart.Text = _res_man.GetString("btnChart_txt", _cul);
            this.btnVar.Text = _res_man.GetString("btnVar_txt", _cul);
            if (_sp_services == null || !_sp_services.SaveFile)
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
                    //Creamos la BD y la tabla en la BD para el proyecto
                    //_db_services.CreateDB();
                    _db_services.CreateTableDB(_proyect);

                    //Mostramos datos
                    this.lblProName.Text = _res_man.GetString("lblProName_txt", _cul) + " " + _proyect.Name;
                    this.lblProDesc.Text = _res_man.GetString("lblProDesc_txt", _cul) + " " + _proyect.Description;
                    if (File.Exists(_proyect.ImagePath))
                        this.pbProImg.Image = Image.FromFile(_proyect.ImagePath);
                    else
                        this.pbProImg.Image = null;

                    //Se muestran sólo las variables que son de escritura
                    this.dgvProVars.Rows.Clear();
                    if (_proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).Count() > 0)
                    {
                        this.dgvProVars.Rows.Add(_proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).Count());
                        for (int i = 0; i < _proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).Count(); i++)
                            this.dgvProVars[0, i].Value = _proyect.Variables.Where(p => p.Access == EnumVarAccess.Escritura).ToList()[i].Name;
                    }

                    this.ViewConnectionClose();
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
                if (_lastRowSP.Variables.Count() == _proyect.Variables.Count() 
                    && _lastRowSP.Variables.Where(p => p.Value == null).Count() == 0)
                {
                    this.FillDataGridView(_lastRowSP);
                    this.ViewConnectionOpen();
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que guarda una nueva línea en el archivo
        /// </summary>
        private void TimerSaveFile(object source, ElapsedEventArgs e)
        {
            try
            {
                if (File.Exists(_saveFilePath) && !new FileInfo(_saveFilePath).IsReadOnly)
                {
                    //Leemos la línea que almacena los nombres de las variables
                    int counter = 0;
                    string line = "";
                    List<string> fileVars = new List<string>();
                    StreamReader fileReader = new StreamReader(_saveFilePath);
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        if (counter == 5)
                        {
                            fileVars = line.Split(';').ToList();
                            fileVars.RemoveAt(0);
                            fileVars.Remove("");
                            break;
                        }
                        counter++;
                    }
                    fileReader.Close();
                    //Guardamos la nueva línea
                    using (StreamWriter fileWriter = new StreamWriter(_saveFilePath, true))
                    {
                        //añadir los valores de las variables cuyo nombre coincide con alguno de los presentes en fileVars
                        string newValues = _db_services.GetLastRowValue(_proyect, fileVars);
                        fileWriter.WriteLine(newValues);
                    }
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que cierra la conexión con el puerto serie
        /// </summary>
        public void CloseSP_services()
        {
            if (_sp_services.SerialPort.IsOpen)
            {
                _sp_services.CloseConnection();
                _timerRefreshDataGrid.Enabled = false;
                if (_threadSaveRow != null)
                    _threadSaveRow.Join();
                _sp_services.SaveFile = false;
                LoadProyect();
                this.ViewConnectionClose();
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
                _exMg.HandleException(ex);
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
                    saveFileDialog1.FileName = _proyect.Name.ToString() + "_" + vars.Count + "variables.txt";
                    saveFileDialog1.Filter = _res_man.GetString("showDialogFilter", _cul);
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter tw = new StreamWriter(saveFileDialog1.OpenFile());
                        _fileSaver.WriteProyectProperties(tw, _proyect, saveFileDialog1.FileName);
                        tw.WriteLine("****************************************");
                        string varNames = "Time;";
                        vars.ForEach(p => varNames += p.Name + ";");
                        tw.WriteLine(varNames);
                        tw.Close();
                        _saveFilePath = saveFileDialog1.FileName;
                        this.btnFile.Text = _res_man.GetString("btnFileStop_txt", _cul);
                        _timerSaveFile.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que abre una nueva ventana en la que aparecen una gráfica con las variables pasadas como parámetro
        /// </summary>
        /// <param name="vars">Variables a graficar</param>
        public void ShowChart(List<Variable> vars)
        {
            try
            {
                ChartForm _chartForm = new ChartForm(_proyect, vars, _cul);                
                _chartForm.Show();
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que abre la ventana de configuración según la llamada
        /// </summary>
        /// <param name="eagerLoading"></param>
        public void CreateConfigForm(int eagerLoading)
        {
            ConfigForm _createConfig;
            if (eagerLoading == 1)
                _createConfig = new ConfigForm(_proyect, _cul);
            else
                _createConfig = new ConfigForm(_cul);
            _createConfig.LoadProyect += LoadProyect;
            _createConfig.ShowDialog();
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
            toolStripMenuItemModifyConfig.Enabled = false;
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
                    if (_lastRowSP != null 
                        && _lastRowSP.Variables.Count() == _proyect.Variables.Count()
                        && _lastRowSP.Variables.Where(p => p.Value == null).Count() == 0)
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
                    toolStripMenuItemModifyConfig.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que establece la visibilidad o estado de los elementos de la vista cuando 
        /// la aplicación tiene cargado un proyecto y la conexión con el puerto serie cerrada.
        /// </summary>
        private void ViewConnectionClose()
        {
            if (cboPort.Items.Count != 0)
                btnStart.Enabled = true;
            else
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
            toolStripMenuItemModifyConfig.Enabled = true;
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Método que abre la ventana para introducir una nueva configuración
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCreateConfig_Click(object sender, EventArgs e)
        {
            CloseSP_services();
            CreateConfigForm(0);
        }

        /// <summary>
        /// Evento que lee un archivo en el que está guardada una configuración y la carga al programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemLoadConfig_Click(object sender, EventArgs e)
        {
            CloseSP_services();
            if (!Directory.Exists(_configsPath))
                Directory.CreateDirectory(_configsPath);
            openFileDialog1.InitialDirectory = _configsPath;
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
                    _exMg.HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Evento que abre la ventana de configuración con los datos del proyecto cargados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemModifyConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (_proyect != null)
                {
                    CloseSP_services();
                    CreateConfigForm(1);
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
        /// Evento que abre un archivo PDF con el manual de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_pdfPath);
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que abre el archivo de ayuda de la ventana principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemHelpHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "Formulario Principal");
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que recoge el clic sobre el elemento del menú "Acerca de"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutForm _aboutForm = new AboutForm(_cul);
            _aboutForm.Show();
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
            _varSelection.ShowChart += ShowChart;
            _varSelection.ShowDialog();
        }

        /// <summary>
        /// Evento que se ejecuta cuando el botón Archivo es pulsado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFile_Click(object sender, EventArgs e)
        {
            if (_timerSaveFile.Enabled)
            {
                _timerSaveFile.Enabled = false;
                this.btnFile.Text = _res_man.GetString("btnFile_txt", _cul);
            }
            else
            {
                _proyect.Variables.ToList().ForEach(p => p.Value = _lastRowSP.Variables.FirstOrDefault(q => q.Name == p.Name).Value);
                VarSelection _varSelection = new VarSelection(_proyect, EnumVarSelection.File, this.getCulture());
                _varSelection.MdiParent = this.MdiParent;
                _varSelection.Save_file += SaveFile;
                _varSelection.ShowDialog();
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
                _varSelection.ShowDialog();
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
                this.btnSearchPort.Enabled = false;
            }
            catch (Exception ex)
            {
                this.ViewConnectionClose();
                _exMg.HandleException(ex);
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
                CloseSP_services();
                this.btnSearchPort.Enabled = true;
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
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
                    this.SendVarSP(e);
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        #endregion

        private void btnSearchPort_Click(object sender, EventArgs e)
        {
            this.btnRefreshPorts_Click(sender, e);
            _sp_services = new SP_services(_proyect, _cul);
            List<SerialPort> ports = new List<SerialPort>();
            SerialPort port;
            this.btnSearchPort.Text = "Buscando...";
            this.btnSearchPort.Enabled = false;

            foreach(string s in _sp_services.Ports)
            {
                SerialPort p = new SerialPort();
                p.PortName = s;
                ports.Add(p);
            }

            port = _sp_services.getOpened(ports, 20);

            if (port == null)
            {
                MessageBox.Show("No se ha encontrado ningun puerto abierto");
            }
            else
            {
                cboPort.Text = port.PortName;
                MessageBox.Show("El puerto abierto es el " + port.PortName);
            }

            this.btnSearchPort.Text = "Buscar Puerto";
            this.btnSearchPort.Enabled = true;
        }

        private void webServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        public Proyect getProyect()
        {
            return this._proyect;
        }

        private void btnConStrin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_db_services.getConnectionString());
            MessageBox.Show("Contenido compiado al portapapeles");
        }
    }
}
