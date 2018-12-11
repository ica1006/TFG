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
using System.Windows.Forms.DataVisualization.Charting;

namespace PlantaPiloto
{
    public partial class ChartForm : Form
    {
        private MainForm _mainForm;
        private ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;            // declare culture info
        private Proyect _proyect;
        private List<Variable> _variables;
        private List<List<Variable>> _sqlData;
        private List<int> _sqlTime;
        private EnumVarSelection _purpose;
        private DB_services _db_services;

        #region Constructor

        public ChartForm()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _variables = new List<Variable>();
            _db_services = new DB_services();
            _proyect = new Proyect();
            _sqlData = new List<List<Variable>>();
            _sqlTime = new List<int>();
        }

        public ChartForm(Proyect proyect, List<Variable> variables, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services();
            _sqlData = new List<List<Variable>>();
            _sqlTime = new List<int>();
            _variables = variables;
            _cul = cultureInfo;
            _proyect = proyect;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que carga los datos al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_Load(object sender, EventArgs e)
        {
            Switch_language();

            //Rellenamos el gráfico
            chartVar.Series.Clear();

            //Se recogen los valores de las variables seleccionadas
            foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
            {
                _sqlData.Add(_db_services.GetVarValue(_proyect, v));
                chartVar.Series.Add(v.Name);
            }

            for (int i = 0; i < _sqlData.Count(); i++)
            {
                Series series = this.chartVar.Series.Add(_sqlData[i].ToString());
                series.Points.Add(Double.Parse(_sqlData[i].ToString()));
                //chartVar.Series[i].XValueMember = _sqlTime[0].ToString();
                //chartVar.Series[i].XValueType = ChartValueType.Int32;
                //chartVar.Series[i].YValueMembers = _sqlData[i].ToString();
                //chartVar.Series[i].YValueType = ChartValueType.Double;
                //chartVar.Series[i].Points.AddXY(i, i);
                ////chartVar.Series[i].Points.AddXY(Int32.Parse(_sqlTime[i].ToString()), Double.Parse(_sqlData[i].ToString()));
                //chartVar.Series[i].ChartType = SeriesChartType.Spline;
                //chartVar.Series[i].BorderWidth = 3;
                //chartVar.ChartAreas[i].AxisX.Interval = 1;
            }
        }

        /// <summary>
        /// Método que actualiza las cadenas según idioma
        /// </summary>
        public void Switch_language()
        {
            //Cambio de idioma de las cadenas
            this.Text = _res_man.GetString("ChartForm_txt", _cul);
            foreach (Variable v in _variables)
            {
                this.Text += " - " + v.Name;
            }
            this.btnClose.Text = _res_man.GetString("btnClose_txt", _cul);
        }

        #endregion


    }
}