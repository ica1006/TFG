using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
            set { _serialPort = value; OnPropertyChanged("SerialPort"); }
        }

        private string[] _ports;

        /// <summary>
        /// Puertos serie en el equipo
        /// </summary>
        public string[] Ports
        {
            get { return _ports; }
            set { _ports = value; OnPropertyChanged("Ports"); }
        }

        private ResourceManager _res_man;

        /// <summary>
        /// Archivo de recursos de la aplicación
        /// </summary>
        public ResourceManager Res_man
        {
            get { return _res_man; }
            set { _res_man = value; OnPropertyChanged("Res_man"); }
        }

        private CultureInfo _cul;

        /// <summary>
        /// Información cultural de la aplicacíón
        /// </summary>
        public CultureInfo Cul
        {
            get { return _cul; }
            set { _cul = value; OnPropertyChanged("Cul"); }
        }

        public Proyect _proyect { get; set; }

        public DB_services _db_services { get; set; }

        #endregion

        #region Constructor
        public SP_services()
        {
            _serialPort = new SerialPort();
            _ports = SerialPort.GetPortNames();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services();
        }

        public SP_services(Proyect pr, CultureInfo cul)
        {
            _serialPort = new SerialPort();
            _ports = SerialPort.GetPortNames();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = pr;
            _cul = cul;
            _db_services = new DB_services();
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
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.Open();
                
                var a = _serialPort.ReadLine();
                while (_serialPort.IsOpen)
                {
                    // Lectura del puerto serie
                    string[] spLine = _serialPort.ReadLine().Split(';');
                    // Asignación del valor a la variable
                    if (_proyect.Variables.Count(p => p.Name == spLine[1]) > 0)
                        _proyect.Variables.FirstOrDefault(p => p.Name == spLine[1]).Value = spLine[2];
                    // Comprobación que todas las variables tienen valor y llamada al método que las guarda en la BD
                    // Se crea el requisito de que todas las variables del proyecto deben existir en la placa
                    if (_proyect.Variables.Count(p => p.Value == null) == 0)
                    {
                        _db_services.SaveRow(_proyect);
                        foreach (Variable v in _proyect.Variables)
                        {
                            v.Value = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _res_man.GetString("ErrorSerialPortConnectionKey", _cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Miembros de INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Método que actualiza la propiedad cuando esta cambia
        /// </summary>
        /// <param name="name">Propiedad a actualizar</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
