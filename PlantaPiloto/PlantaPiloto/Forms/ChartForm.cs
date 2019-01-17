using PlantaPiloto.Classes;
using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        readonly MainForm _mainForm;
        readonly ResourceManager _res_man;    // declare Resource manager to access to specific cultureinfo
        readonly CultureInfo _cul;            // declare culture info
        readonly Proyect _proyect;
        readonly List<Variable> _variables;
        readonly List<List<Variable>> _sqlData;
        private List<double> _sqlTime;
        readonly DB_services _db_services;
        readonly System.Timers.Timer _timer;
        delegate void StringArgReturningVoidDelegate();
        private int _chartAmount;
        readonly HelpProvider _helpProvider;
        readonly ExceptionManagement _exMg;
        readonly string _filesPath;

        #region Constructor

        public ChartForm()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _variables = new List<Variable>();
            _db_services = new DB_services(_cul);
            _proyect = new Proyect();
            _sqlData = new List<List<Variable>>();
            _sqlTime = new List<double>();
            _timer = new System.Timers.Timer(2000);
            _timer.Enabled = false;
            _timer.Elapsed += new ElapsedEventHandler(this.LoadChartsTimer);
            _chartAmount = 100;
            _helpProvider = new HelpProvider();
            _filesPath = new GlobalParameters().FilesPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _exMg = new ExceptionManagement(_cul);
        }

        public ChartForm(Proyect proyect, List<Variable> variables, CultureInfo cultureInfo)
        {
            InitializeComponent();
            _mainForm = new MainForm();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services(_cul);
            _sqlData = new List<List<Variable>>();
            _sqlTime = new List<double>();
            _timer = new System.Timers.Timer(2000);
            _timer.Enabled = false;
            _timer.Elapsed += new ElapsedEventHandler(this.LoadChartsTimer);
            _variables = variables;
            _cul = cultureInfo;
            _proyect = proyect;
            _chartAmount = 100;
            _helpProvider = new HelpProvider();
            _filesPath = new GlobalParameters().FilesPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _exMg = new ExceptionManagement(_cul);
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
            this.txtChartAmount.Text = "100";

            //Iniciamos el timer
            this._timer.Enabled = true;
        }

        /// <summary>
        /// Método que se ejecuta al cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _timer.Enabled = false;
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
                    _sqlData.Add(_db_services.GetVarValue(_proyect, v, _chartAmount));

                GetVarValuesAndTimes();

                for (int i = 0; i < _sqlData.Count(); i++)
                {
                    Series series = new Series(_sqlData[i].First().Name);
                    series.Points.DataBindXY(_sqlTime, "Time", _sqlData[i].Select(p => Double.Parse(p.Value)).ToList(), "Value");
                    series.ChartType = SeriesChartType.Line;
                    series.BorderWidth = 3;
                    chartVar.Series.Add(series);
                    chartVar.ChartAreas[0].AxisX.Interval = 10;
                    chartVar.ChartAreas[0].AxisX.Title = _res_man.GetString("chartXAxisLabel", _cul);
                    chartVar.ChartAreas[0].AxisY.Title = _res_man.GetString("chartYAxisLabel", _cul);

                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
            try
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
                    GetVarValuesAndTimes();
                    foreach (Variable v in _variables.Where(p => p.Type != EnumVarType.String))
                    {
                        _sqlData.Add(_db_services.GetVarValue(_proyect, v, _chartAmount));
                        if (_sqlTime.Count() == _sqlData.Last().Select(p => p.Value).ToList().Count())
                        {
                            chartVar.Series[v.Name].Points.Clear();
                            chartVar.Series[v.Name].Points.DataBindXY(_sqlTime, _sqlData.Last().Select(p => Double.Parse(p.Value)).ToList());
                        }
                    }

                    chartVar.Update();
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que devuelve el valor de la variable y el tiempo de la gráfica
        /// </summary>
        /// <returns></returns>
        private void GetVarValuesAndTimes()
        {
            //Obtengo el periodo
            double values = Double.Parse(_db_services.GetVarValue(_proyect, _proyect.Variables.FirstOrDefault(q => q.Name == "Ts"), _chartAmount).First().Value);
            //Multiplico el periodo por el momento de la placa guardado en la BD
            _sqlTime = _db_services.GetVarValue(_proyect, _proyect.Variables.First(), _chartAmount)
                    .Select(p => Double.Parse(p.Time.Value.ToString()) * values).ToList();
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
            this.lblChartAmount.Text = _res_man.GetString("lblChartAmount_txt", _cul);
            this.btnChartAmount.Text = _res_man.GetString("btnChartAmount_txt", _cul);
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
                Close();
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que controla que la tecla pulsada es un número
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void txtChartAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que actualiza el número de valores a mostrar en la gráfica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChartAmount_Click(object sender, EventArgs e)
        {
            try
            {
                _chartAmount = Int32.Parse(txtChartAmount.Text);
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Evento que abre el archivo de ayuda del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "Formulario Gráficos");
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        #endregion
    }
}