using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    class ExceptionManagement
    {
        //Ruta del archivo de log
        readonly string _filePath = Path.Combine(Application.StartupPath, "../../files/ExceptionLog.txt");

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
                    break;
                case "System.ObjectDisposedException":
                    msg = " Info: Objeto disposed";
                    break;
                case "System.IO.IOException":
                    msg = " Info: Excepción Entrada/Salida (puerto Serie)";
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
            using (StreamWriter fileWriter = new StreamWriter(_filePath, true))
                fileWriter.WriteLine(DateTime.Parse(DateTime.Now.ToString(), new System.Globalization.CultureInfo("es-ES")).ToString() + " - " + newLog);
        }
    }
}
