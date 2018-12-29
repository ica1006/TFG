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
        string _filePath = Path.Combine(Application.StartupPath, "../../files/ExceptionLog.txt");
        /// <summary>
        /// Método que recibe las excepciones de la aplicación y las controla según el tipo
        /// </summary>
        /// <param name="ex"></param>
        public void HandleException(Exception ex)
        {
            string a = ex.GetType().ToString();
            switch (ex.GetType().ToString())
            {
                case "System.FormatException":
                    SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}, Info: Formato inválido");
                    break;
                case "System.NullReferenceException":
                    SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}, Info: Valor nulo");
                    break;
                case "System.IndexOutOfRangeException":
                    SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}, Info: Índice fuera de rango");
                    break;
                case "System.ObjectDisposedException":
                    SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}, Info: Objeto disposed");
                    break;
                case "System.IO.IOException":
                    SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}, Info: Excepción Entrada/Salida (puerto Serie)");
                    break;
                default:
                    SaveVarsValue($"{ex.GetType().Name}, {ex.StackTrace}");
                    break;
            }
        }

        /// <summary>
        /// Método que agrega una nueva línea al archivo de log
        /// </summary>
        public void SaveVarsValue(string newLog)
        {
            using (StreamWriter fileWriter = new StreamWriter(_filePath, true))
                fileWriter.WriteLine(DateTime.Now.ToString() + " - " + newLog);
        }
    }
}
