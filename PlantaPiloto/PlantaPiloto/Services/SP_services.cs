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

        private Proyect _lastRow;
        /// <summary>
        /// Propiedad que almacena el valor de la última iteración recibida
        /// </summary>
        public Proyect LastRow
        {
            get { return _lastRow; }
            set { _lastRow = value; OnPropertyChanged("LastRow"); }
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
            set { _saveFile = value; OnPropertyChanged("SaveFile"); }
        }

        private string _filePath;
        /// <summary>
        /// Ruta del archivo donde guardar las variables
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; OnPropertyChanged("FilePath");}
        }

        private ExceptionManagement _exMg = new ExceptionManagement();

        #endregion

        #region Constructor
        public SP_services()
        {
            _serialPort = new SerialPort();
            _ports = SerialPort.GetPortNames();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _db_services = new DB_services();
            _lastRow = new Proyect();
            _saveFile = false;
        }

        public SP_services(Proyect pr, CultureInfo cul)
        {
            _serialPort = new SerialPort();
            _ports = SerialPort.GetPortNames();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _proyect = pr;
            _cul = cul;
            _db_services = new DB_services();
            _lastRow = new Proyect();
            _saveFile = false;
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
                _serialPort.ReadBufferSize = 8192;
                _serialPort.Open();

                var a = _serialPort.ReadLine();
                while (_serialPort.IsOpen)
                {
                    // Lectura del puerto serie
                    string[] spLine = _serialPort.ReadLine().Split(';');
                    // Asignación del valor a la variable

                    if (_proyect.Variables.Count(p => p.Name == spLine[1]) > 0)
                    {
                        _proyect.Variables.FirstOrDefault(p => p.Name == spLine[1]).Time = Int32.Parse(spLine[0]);
                        _proyect.Variables.FirstOrDefault(p => p.Name == spLine[1]).Value = spLine[2];

                        //Asigno valor a las variables que son sólo de escritura para tener una referencia en la vista
                        if (spLine[1].EndsWith("_eco") && _proyect.Variables.Where(p => p.Name + "_eco" == spLine[1]).Count() != 0)
                        {
                            _proyect.Variables.FirstOrDefault(p => p.Name + "_eco" == spLine[1]).Time = Int32.Parse(spLine[0]);
                            _proyect.Variables.FirstOrDefault(p => p.Name + "_eco" == spLine[1]).Value = spLine[2];
                        }
                        if (spLine[1].EndsWith("_x3_eco") && _proyect.Variables.Where(p => p.Name + "_x3_eco" == spLine[1]).Count() != 0)
                        {
                            _proyect.Variables.FirstOrDefault(p => p.Name + "_x3_eco" == spLine[1]).Time = Int32.Parse(spLine[0]);
                            _proyect.Variables.FirstOrDefault(p => p.Name + "_x3_eco" == spLine[1]).Value = spLine[2];
                        }
                    }
                    // Comprobación que todas las variables tienen valor y llamada al método que las guarda en la BD
                    // Se crea el requisito de que todas las variables del proyecto deben existir en la placa
                    if (_proyect.Variables.Count(p => p.Value == null) == 0)
                    {
                        _db_services.SaveRow(_proyect);
                        _lastRow = new Proyect();

                        foreach (Variable v in _proyect.Variables)
                        {
                            _lastRow.Variables.Add(new Variable
                            {
                                Name = v.Name,
                                Access = v.Access,
                                Time = v.Time,
                                Value = v.Value
                            });
                            v.Time = null;
                            v.Value = null;
                        }

                        if (_saveFile)
                        {
                            this.SaveVarsValue();
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

        /// <summary>
        /// Método que agrega una nueva línea al archivo donde se guardan los valores de las variables
        /// </summary>
        public void SaveVarsValue()
        {
            try
            {
                if (File.Exists(_filePath) && !new FileInfo(_filePath).IsReadOnly)
                {
                    //Leemos la línea que almacena los nombres de las variables
                    int counter = 0;
                    string line = "";
                    string[] fileVars = new string[] { };
                    StreamReader fileReader = new StreamReader(_filePath);
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        if (counter == 5)
                        {
                            fileVars = line.Split(';');
                            fileVars = fileVars.Where(p => p != "").ToArray();
                            break;
                        }
                        counter++;
                    }
                    fileReader.Close();
                    //Guardamos la nueva línea
                    using (StreamWriter fileWriter = new StreamWriter(_filePath, true))
                    {
                        //añadir los valores de las variables cuyo nombre coincide con alguno de los presentes en fileVars
                        string newValues = "";
                        _lastRow.Variables.Where(p => fileVars.Contains(p.Name)).ToList().ForEach(q => newValues += q.Value + ";");
                        fileWriter.WriteLine(newValues);
                    }
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
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
