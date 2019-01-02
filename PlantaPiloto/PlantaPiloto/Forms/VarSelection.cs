using PlantaPiloto.Classes;
using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using static PlantaPiloto.MainForm;

namespace PlantaPiloto
{
    public partial class VarSelection : Form
    {
        readonly MainForm _mainForm;
        readonly ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        readonly CultureInfo _cul;            // declare culture info
        readonly Proyect _proyect;
        readonly EnumVarSelection _purpose;
        readonly DB_services _db_services;
        readonly HelpProvider _helpProvider;
        public event SaveFileDelegate Save_file;
        readonly ExceptionManagement _exMg;

        #region Constructor

        public VarSelection()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _db_services = new DB_services();
            _helpProvider = new HelpProvider();
            _helpProvider.HelpNamespace = Path.Combine(Application.StartupPath, "../../files/helpProyect.chm");
            _exMg = new ExceptionManagement();
        }

        public VarSelection(Proyect proyect, EnumVarSelection purpose, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services();
            _proyect = new Proyect(
                proyect.Name,
                proyect.Description,
                proyect.ImagePath,
                proyect.Cul
            );
            proyect.Variables.ToList().ForEach(p => _proyect.Variables.Add(new Variable(
                p.Name,
                p.Type,
                p.Description,
                p.Access,
                p.BoardUnits,
                p.InterfaceUnits,
                p.LinearAdjustA,
                p.LinearAdjustB,
                p.RangeLow,
                p.RangeHigh,
                p.CommunicationType,
                p.Value,
                p.Time,
                p.Cul
            )));
            _purpose = purpose;
            _cul = cultureInfo;
            _helpProvider = new HelpProvider();
            _helpProvider.HelpNamespace = Path.Combine(Application.StartupPath, "../../files/helpProyect.chm");
            _exMg = new ExceptionManagement();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que se ejecuta al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VarSelection_Load(object sender, EventArgs e)
        {
            //Carga de variables en el dataGridView
            dgvVarSelection.Columns.Add(new DataGridViewColumn()
            {
                Name = "Variables",
                HeaderText = "Variables",
                ReadOnly = true,
                CellTemplate = new DataGridViewTextBoxCell()
            });

            switch (_purpose)
            {
                case EnumVarSelection.Chart:
                    this.btnAccept.Visible = true;
                    dgvVarSelection.Columns.Add(new DataGridViewCheckBoxColumn()
                    {
                        Name = "X",
                        HeaderText = "X",
                        ReadOnly = false,
                        CellTemplate = new DataGridViewCheckBoxCell()
                    });
                    foreach (Variable v in _proyect.Variables.Where(p => p.Type != EnumVarType.String))
                        dgvVarSelection.Rows.Add(new object[] { v.Name, false });
                    break;
                case EnumVarSelection.File:
                    this.btnAccept.Visible = true;
                    dgvVarSelection.Columns.Add(new DataGridViewCheckBoxColumn()
                    {
                        Name = "X",
                        HeaderText = "X",
                        ReadOnly = false,
                        CellTemplate = new DataGridViewCheckBoxCell()
                    });
                    foreach (Variable v in _proyect.Variables)
                        dgvVarSelection.Rows.Add(new object[] { v.Name, false });
                    break;
                case EnumVarSelection.Vars:
                    this.btnAccept.Visible = false;
                    dgvVarSelection.Columns.Add(new DataGridViewColumn()
                    {
                        Name = "Values",
                        HeaderText = _res_man.GetString("chartYAxisLabel", _cul),
                        ReadOnly = true,
                        CellTemplate = new DataGridViewTextBoxCell()
                    });

                    if (_proyect.Variables.Count(p => p.Value == null) == 0)
                        foreach (Variable v in _proyect.Variables)
                            dgvVarSelection.Rows.Add(new object[] { v.Name, v.Value });
                    break;
                default:
                    this.btnAccept.Visible = false;
                    break;
            }

            this.Switch_language();
        }

        /// <summary>
        /// Método que actualiza las cadenas según idioma
        /// </summary>
        public void Switch_language()
        {
            //Cambio de idioma de las cadenas
            #region Actualización de cadenas

            this.Text = _res_man.GetString("VarSelectionForm_txt", _cul);
            this.gbVarSelection.Text = _res_man.GetString("gbVarSelection_txt", _cul);
            this.btnCancel.Text = _res_man.GetString("btnClose_txt", _cul);
            switch (this._purpose)
            {
                case EnumVarSelection.Chart:
                    this.btnAccept.Text = _res_man.GetString("btnAcceptChart_txt", _cul);
                    break;
                case EnumVarSelection.File:
                    this.btnAccept.Text = _res_man.GetString("btnAcceptFile_txt", _cul);
                    break;
                default:
                    this.btnAccept.Visible = false;
                    break;
            }

            #endregion
        }

        #endregion

        #region Events


        /// <summary>
        /// Evento que responde al botón de aceptar de la ventana y según el propósito de la misma
        /// carga las variables en una ventana graficadas o las guarda en un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                List<Variable> _varSelected = new List<Variable>();
                foreach (DataGridViewRow row in dgvVarSelection.Rows)
                {
                    if (row.Cells[1].Value.Equals(true))
                        _varSelected.Add(_proyect.Variables.FirstOrDefault(p => p.Name == row.Cells[0].Value.ToString()));
                }

                if (_varSelected.Count != 0)
                {
                    switch (_purpose)
                    {
                        case EnumVarSelection.Chart:
                            ChartForm _chartForm = new ChartForm(_proyect, _varSelected, _cul);
                            _chartForm.MdiParent = this.MdiParent;
                            _chartForm.Show();
                            break;
                        case EnumVarSelection.File:
                            Save_file(_varSelected);
                            this.Close();
                            break;
                        default:
                            this.Close();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que recoge la pulsación del botón cancelar.
        /// Cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que abre el archivo de ayuda para el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "Formulario Selección de Variables");
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        #endregion
    }
}
