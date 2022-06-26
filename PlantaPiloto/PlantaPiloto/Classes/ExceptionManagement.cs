using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    class ExceptionManagement
    {
        #region Properties
        //Ruta del archivo de log
        readonly string _filePath = Path.Combine(GlobalParameters.FilesPath, "ExceptionLog.txt");

        readonly CultureInfo _cul;

        public CultureInfo Cul { get; set; }

        readonly ResourceManager _res_man;
        #endregion

        #region Constructor
        public ExceptionManagement(CultureInfo cul)
        {
            _cul = cul;
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Método que recibe las excepciones de la aplicación y las controla según el tipo
        /// </summary>
        /// <param name="ex"></param>
        public void HandleException(Exception ex)
        {
            string msg = "";
            switch (ex.GetType().ToString())
            {
                case "System.FormatException":
                    msg = " Info: Formato inválido";
                    break;
                case "System.NullReferenceException":
                    msg = " Info: Valor nulo";
                    break;
                case "System.IndexOutOfRangeException":
                    msg = " Índice fuera de rango";
                    MessageBox.Show(_res_man.GetString("ErrorConnectionMsg", _cul), _res_man.GetString("ErrorConnectionTitle", _cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "System.ObjectDisposedException":
                    msg = " Info: Objeto disposed";
                    break;
                case "System.IO.IOException":
                    msg = " Info: Excepción Entrada/Salida (puerto Serie)";
                    break;
                case "System.ArgumentException":
                    msg = " Info: La ruta no tiene un formato válido.";
                    break;
                default:
                    msg = " Info: excepción no definida.";
                    break;
            }
            SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}, {msg}");
        }

        /// <summary>
        /// Método que agrega una nueva línea al archivo de log
        /// </summary>
        public void SaveVarsValue(string newLog)
        {
            
            if (!Directory.Exists(GlobalParameters.FilesPath))
                Directory.CreateDirectory(GlobalParameters.FilesPath);
            if (!File.Exists(_filePath))
                File.Create(_filePath);

            using (StreamWriter fileWriter = new StreamWriter(_filePath, true))
                fileWriter.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + " - " + newLog);
        }
        #endregion
    }
}
