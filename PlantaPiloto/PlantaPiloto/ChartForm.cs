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
using System.Timers;
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
        private List<double> _sqlTime;
        private EnumVarSelection _purpose;
        private DB_services _db_services;
        private System.Timers.Timer _timer;
        delegate void StringArgReturningVoidDelegate();

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
            _sqlTime = new List<double>();
            _timer = new System.Timers.Timer(5000);
            _timer.Enabled = false;
            _timer.Elapsed += new ElapsedEventHandler(this.LoadChartsTimer);
        }

        public ChartForm(Proyect proyect, List<Variable> variables, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services();
            _sqlData = new List<List<Variable>>();
            _sqlTime = new List<double>();
            _timer = new System.Timers.Timer(5000); ;
            _timer.Enabled = false;
            _timer.Elapsed += new ElapsedEventHandler(this.LoadChartsTimer);
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
            this.LoadCharts();

            //Iniciamos el timer
            this._timer.Enabled = true;
        }

        /// <summary>
        /// Método que crea las series para el gráfico a partir de las variables seleccionadas
        /// </summary>
        private void LoadCharts()
        {
            try
            {
                chartVar.Series.Clear();
                //Se recogen los valores de las variables seleccionadas
                foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
                {
                    _sqlData.Add(_db_services.GetVarValue(_proyect, v));
                }
                //_sqlTime = _db_services.GetVarValue(_proyect, _proyect.Variables.First()).Select(p => p.Time.Value).ToList();
                double _ts = Double.Parse(_db_services.GetVarValue(_proyect, _proyect.Variables.FirstOrDefault(q => q.Name == "Ts")).First().Value);
                _sqlTime = _db_services.GetVarValue(_proyect, _proyect.Variables.First())
                    .Select(p => Double.Parse(p.Time.Value.ToString()) * _ts).ToList();
                for (int i = 0; i < _sqlData.Count(); i++)
                {
                    Series series = new Series(_sqlData[i].First().Name);
                    series.Points.DataBindXY(_sqlTime, "Time", _sqlData[i].Select(p => Double.Parse(p.Value)).ToList(), "Value");
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 3;
                    chartVar.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Método que responde a la llamada del timer de la ventana y llama a LoadCharts.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void LoadChartsTimer(object source, ElapsedEventArgs e)
        {
            this.UpdateChart();
        }

        /// <summary>
        /// Función que actualiza la gráfica
        /// </summary>
        private void UpdateChart()
        {
            if (this.chartVar.InvokeRequired)
            {
                //Para evitar concurrencia se llama a un delegado puesto que los datos se han obtenido en otro hilo
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(UpdateChart);
                this.Invoke(d, new object[] { });
            }
            else
            {
                //Se recogen los valores de las variables seleccionadas
                double _ts = Double.Parse(_db_services.GetVarValue(_proyect, _proyect.Variables.FirstOrDefault(q => q.Name == "Ts")).First().Value);
                _sqlTime = _db_services.GetVarValue(_proyect, _proyect.Variables.First())
                    .Select(p => Double.Parse(p.Time.Value.ToString()) * _ts).ToList();
                foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
                {
                    _sqlData.Add(_db_services.GetVarValue(_proyect, v));
                    if(_sqlTime.Count() == _sqlData.Last().Select(p => p.Value).ToList().Count())
                    {
                        chartVar.Series[v.Name].Points.Clear();
                        chartVar.Series[v.Name].Points.DataBindXY(_sqlTime, "Seconds", _sqlData.Last().Select(p => Double.Parse(p.Value)).ToList(), "Value");
                    }
                }

                chartVar.Update();
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

        #region Events

        /// <summary>
        /// Evento que recoge la pulsación del botón cancelar.
        /// Cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this._timer.Dispose();
                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}