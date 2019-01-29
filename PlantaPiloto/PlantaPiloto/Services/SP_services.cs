using PlantaPiloto.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public class SP_services
    {
        #region Properties

        private SerialPort _serialPort;

        /// <summary>
        /// Conexión a puerto serie
        /// </summary>
        public SerialPort SerialPort
        {
            get { return _serialPort; }
            set { _serialPort = value; OnPropertyChangedSP_services("SerialPort"); }
        }

        private string[] _ports;

        /// <summary>
        /// Puertos serie en el equipo
        /// </summary>
        public string[] Ports
        {
            get { return _ports; }
            set { _ports = value; OnPropertyChangedSP_services("Ports"); }
        }

        private ResourceManager _res_man;

        /// <summary>
        /// Archivo de recursos de la aplicación
        /// </summary>
        public ResourceManager Res_man
        {
            get { return _res_man; }
            set { _res_man = value; OnPropertyChangedSP_services("Res_man"); }
        }

        private CultureInfo _cul;

        /// <summary>
        /// Información cultural de la aplicacíón
        /// </summary>
        public CultureInfo Cul
        {
            get { return _cul; }
            set { _cul = value; OnPropertyChangedSP_services("Cul"); }
        }

        private Proyect _lastRow;
        /// <summary>
        /// Propiedad que almacena el valor de la última iteración recibida
        /// </summary>
        public Proyect LastRow
        {
            get { return _lastRow; }
            set { _lastRow = value; OnPropertyChangedSP_services("LastRow"); }
        }

        public Proyect _proyect { get; set; }

        public DB_services _db_services { get; set; }

        private bool _saveFile;
        /// <summary>
        /// Propiedad que indica si hay que guardar los valores de las variables en un archivo o no
        /// </summary>
        public bool SaveFile
        {
            get { return _saveFile; }
            set { _saveFile = value; OnPropertyChangedSP_services("SaveFile"); }
        }

        /// <summary>
        /// Encargado de controlar las excepciones
        /// </summary>
        readonly ExceptionManagement _exMg;

        /// <summary>
        /// Tiempo de la aplicación
        /// </summary>
        private float _time;

        /// <summary>
        /// Periodo de la placa
        /// </summary>
        private float _ts;

        #endregion

        #region Constructor
        public SP_services()
        {
            _serialPort = new SerialPort();
            _ports = SerialPort.GetPortNames();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services(_cul);
            _lastRow = new Proyect();
            _saveFile = false;
            _exMg = new ExceptionManagement(_cul);
            _time = 0;
            _ts = GlobalParameters.DefaultTs;
        }

        public SP_services(Proyect pr, CultureInfo cul)
        {
            _serialPort = new SerialPort();
            _ports = SerialPort.GetPortNames();
            _time = 0;
            _ts = GlobalParameters.DefaultTs;
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = pr;
            _cul = cul;
            _db_services = new DB_services(_cul);
            _lastRow = new Proyect();
            _saveFile = false;
            _exMg = new ExceptionManagement(_cul);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Método que abre la conexión con el puerto serie y guarda los datos recibidos en la BD.
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                // Set the read/write timeouts
                //_serialPort.ReadBufferSize = 8192;
                _serialPort.Open();
                int oldMoment = -1;

                while (_serialPort.IsOpen)
                {
                    // Lectura del puerto serie
                    string[] spLine = _serialPort.ReadLine().Split(';');
                    if (spLine.Count() == 3)
                    {
                        if (oldMoment == -1)
                            Int32.TryParse(spLine[0], out oldMoment);

                        int newMoment = Int32.Parse(spLine[0]);

                        if (newMoment != oldMoment)
                        {
                            _time += _ts;
                            _time = (float)(Math.Round((double)_time, 2));
                            oldMoment = newMoment;
                        }

                        // Asignación del valor a la variable
                        if (_proyect.Variables.Count(p => p.Name == spLine[1]) > 0)
                        {
                            _proyect.Variables.FirstOrDefault(p => p.Name == spLine[1]).BoardMoment = Int32.Parse(spLine[0]);
                            _proyect.Variables.FirstOrDefault(p => p.Name == spLine[1]).Value = spLine[2];

                            //Se actualiza el valor del periodo de la placa
                            if (spLine[1] == "Ts")
                                _ts = float.Parse(spLine[2], CultureInfo.InvariantCulture);

                            //Asigno valor a las variables que son sólo de escritura para tener una referencia en la vista
                            if (spLine[1].EndsWith("_eco") && _proyect.Variables.Where(p => p.Name + "_eco" == spLine[1]).Count() != 0)
                            {
                                _proyect.Variables.FirstOrDefault(p => p.Name + "_eco" == spLine[1]).BoardMoment = Int32.Parse(spLine[0]);
                                _proyect.Variables.FirstOrDefault(p => p.Name + "_eco" == spLine[1]).Value = spLine[2];
                            }
                            if (spLine[1].EndsWith("_x3_eco") && _proyect.Variables.Where(p => p.Name + "_x3_eco" == spLine[1]).Count() != 0)
                            {
                                _proyect.Variables.FirstOrDefault(p => p.Name + "_x3_eco" == spLine[1]).BoardMoment = Int32.Parse(spLine[0]);
                                _proyect.Variables.FirstOrDefault(p => p.Name + "_x3_eco" == spLine[1]).Value = spLine[2];
                            }
                        }
                        // Comprobación que todas las variables tienen valor y llamada al método que las guarda en la BD
                        // Se crea el requisito de que todas las variables del proyecto deben existir en la placa
                        if (_proyect.Variables.Count(p => p.Value == null) == 0)
                        {
                            _db_services.SaveRow(_proyect, _time);
                            _lastRow = new Proyect();

                            foreach (Variable v in _proyect.Variables)
                            {
                                _lastRow.Variables.Add(new Variable
                                {
                                    Name = v.Name,
                                    Access = v.Access,
                                    BoardMoment = v.BoardMoment,
                                    Value = v.Value
                                });
                                v.BoardMoment = null;
                                v.Value = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        /// <summary>
        /// Método que cierra la conexión al puerto serie
        /// </summary>
        public void CloseConnection()
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        #endregion

        #region Miembros de INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Método que actualiza la propiedad cuando esta cambia
        /// </summary>
        /// <param name="name">Propiedad a actualizar</param>
        protected void OnPropertyChangedSP_services(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
