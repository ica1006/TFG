using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public partial class VarSelection : Form
    {
        private MainForm _mainForm;
        private ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private Variable _variable;
        private EnumVarSelection _purpose;
        private DB_services _db_services;

        #region Constructor

        public VarSelection()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = new Proyect();
            _db_services = new DB_services();
        }

        public VarSelection(Proyect proyect, EnumVarSelection purpose, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services();
            _proyect = proyect;
            _purpose = purpose;
            _cul = cultureInfo;
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
                CellTemplate = new dg
            });
            dgvVarSelection.Columns[0].CellTemplate = 
            if (_purpose == EnumVarSelection.Vars)
            {
                this.btnAccept.Visible = false;
                dgvVarSelection.Columns.Add(new DataGridViewColumn()
                {
                    Name = "Values",
                    HeaderText = _res_man.GetString("chartYAxisLabel", _cul),
                    ReadOnly = true,
                });
                //for(int i = 0; i < _proyect.Variables.Count(); i++)
                //{
                //    dgvVarSelection.Rows.Add(values.,);
                //}
                if (_proyect.Variables.Count(p => p.Value == null) == 0)
                    foreach (Variable v in _proyect.Variables)
                        dgvVarSelection.Rows.Add(new object[] { v.Name, v.Value });
            }
            else
            {
                this.btnAccept.Visible = true;
                dgvVarSelection.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "X", HeaderText = "X", ReadOnly = false });
                foreach (Variable v in _proyect.Variables.Where(p => p.Type != EnumVarType.String))
                    dgvVarSelection.Rows.Add(new object[] { v.Name, false });
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
            this.btnCancel.Text = _res_man.GetString("btnCancel_txt", _cul);
            switch (this._purpose)
            {
                case EnumVarSelection.Chart:
                    this.btnAccept.Text = _res_man.GetString("btnAcceptChart_txt", _cul);
                    break;
                case EnumVarSelection.File:
                    this.btnAccept.Text = _res_man.GetString("btnAcceptFile_txt", _cul);
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
                            MessageBox.Show("gráficas");
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
