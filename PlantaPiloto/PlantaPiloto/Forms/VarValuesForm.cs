using PlantaPiloto.Classes;
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

namespace PlantaPiloto.Forms
{
    public partial class VarValuesForm : Form
    {
        readonly ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        readonly CultureInfo _cul;            // declare culture info
        readonly Proyect _proyect;
        readonly List<Variable> _varsSelected;
        readonly DB_services _db_services;
        readonly HelpProvider _helpProvider;
        readonly ExceptionManagement _exMg;

        public VarValuesForm(Proyect proyect, List<Variable> varsSelected, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services(_cul);
            _proyect = proyect;
            _varsSelected = varsSelected;
            _cul = cultureInfo;
            _helpProvider = new HelpProvider();
            _helpProvider.HelpNamespace = Path.Combine(Application.StartupPath, "../../files/helpProyect.chm");
            _exMg = new ExceptionManagement(_cul);
        }

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

            foreach (Variable v in _varsSelected)
            {
                string value = _db_services.GetVarValue(_proyect, v, 1).FirstOrDefault(p => p.Name == v.Name).Value;
                dgvVarValues.Rows.Add(new object[] {
                        v.Name,
                        value
                });
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

            this.Text = _res_man.GetString("VarValuesForm_txt", _cul);
            this.gbVarValues.Text = _res_man.GetString("gbVarValues_txt", _cul);
            this.btnCancel.Text = _res_man.GetString("btnClose_txt", _cul);

            #endregion
        }
    }
}
