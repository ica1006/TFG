using PlantaPiloto.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Timers;
using System.Windows.Forms;

namespace PlantaPiloto.Forms
{
    public partial class VarValuesForm : Form
    {
        #region Properties

        readonly ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        readonly CultureInfo _cul;            // declare culture info
        readonly Proyect _proyect;
        readonly List<Variable> _varsSelected;
        readonly DB_services _db_services;
        readonly HelpProvider _helpProvider;
        readonly ExceptionManagement _exMg;
        readonly System.Timers.Timer _timer;
        readonly string _filesPath;

        #endregion

        #region Constructor

        public VarValuesForm(Proyect proyect, List<Variable> varsSelected, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services(_cul);
            _proyect = proyect;
            _varsSelected = varsSelected;
            _cul = cultureInfo;
            _helpProvider = new HelpProvider();
            _filesPath = GlobalParameters.FilesPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _exMg = new ExceptionManagement(_cul);
            _timer = new System.Timers.Timer(5000);
            _timer.Enabled = false;
            _timer.Elapsed += new ElapsedEventHandler(this.FillDataGridTimer);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Evento que carga valores al abrir el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VarValuesForm_Load(object sender, EventArgs e)
        {
            //Creación de columnas
            dgvVarValues.Columns.Add(new DataGridViewColumn
            {
                Name = "Variables",
                HeaderText = "Variables",
                ReadOnly = true,
                CellTemplate = new DataGridViewTextBoxCell()
            });

            dgvVarValues.Columns.Add(new DataGridViewColumn
            {
                Name = "Values",
                HeaderText = _res_man.GetString("chartYAxisLabel", _cul),
                ReadOnly = true,
                CellTemplate = new DataGridViewTextBoxCell()
            });

            this.FillDataGrid();
            _timer.Enabled = true;
            this.Switch_language();
        }

        /// <summary>
        /// Método que actualiza las cadenas según idioma
        /// </summary>
        public void Switch_language()
        {
            //Cambio de idioma de las cadenas
            #region Actualización de cadenas

            this.Text = _res_man.GetString("VarValuesForm_txt", _cul);
            this.gbVarValues.Text = _res_man.GetString("gbVarValues_txt", _cul);
            this.btnCancel.Text = _res_man.GetString("btnClose_txt", _cul);

            #endregion
        }

        /// <summary>
        /// Método que responde a la llamada del timer de la ventana y llama a FillDataGrid.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void FillDataGridTimer(object source, ElapsedEventArgs e)
        {
            this.FillDataGrid();
        }

        /// <summary>
        /// Método que rellena las columnas con los últimos valores
        /// </summary>
        private void FillDataGrid()
        {
            try
            {
                if (_varsSelected.Any())
                {
                    if (dgvVarValues.Rows.Count == 0)
                    {
                        foreach (Variable v in _varsSelected)
                        {
                            string value = _db_services.GetVarValue(_proyect, v, 1).FirstOrDefault(p => p.Name == v.Name).Value;
                            dgvVarValues.Rows.Add(v.Name, value);
                        }
                    }
                    else
                    {
                        foreach (Variable v in _varsSelected)
                        {
                            string value = _db_services.GetVarValue(_proyect, v, 1).FirstOrDefault(p => p.Name == v.Name).Value;
                            for (int i = 0; i < dgvVarValues.Rows.Count; i++)
                                if (dgvVarValues[0, i].Value.ToString() == v.Name)
                                    dgvVarValues[1, i].Value = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
                GlobalParameters.errorLog.NewEntry("Exception filling the data grid view.\n" + ex.Message + "\n" + ex.StackTrace);
            }
        }

        #endregion
        /// <summary>
        /// Evento que controla el botón Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _timer.Close();
            this.Close();
        }

        /// <summary>
        /// Evento que abre la ayuda de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "Formulario Valores de variables");
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
                GlobalParameters.errorLog.NewEntry("Exception opening the help window.\n" + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
