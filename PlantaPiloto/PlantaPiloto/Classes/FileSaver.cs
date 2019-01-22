using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    class FileSaver
    {
        /// <summary>
        /// Método que guarda las propiedades de un proyecto en un archivo de texto
        /// </summary>
        /// <param name="tw">StreamWriter que escribe en el archivo de texto</param>
        /// <param name="proyect">Proyecto del que se guardan las propiedades</param>
        public void WriteProyectProperties(StreamWriter tw, Proyect proyect, string fileDir)
        {
            tw.WriteLine(DateTime.Now);
            tw.WriteLine(proyect.Name);
            tw.WriteLine(proyect.Description);
            string fileDirectory = fileDir.Split('\\')[fileDir.Split('\\').Length - 1];
            fileDirectory = fileDirectory.Substring(0, fileDirectory.Length - 4);
            if (File.Exists(proyect.ImagePath))
            {
                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Configuraciones\\images", fileDirectory)))
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Configuraciones\\images", fileDirectory));
                string newPath = Path.Combine(Application.StartupPath, "Configuraciones\\images", fileDirectory, Path.GetFileName(proyect.ImagePath));
                if (File.Exists(newPath))
                {
                    string fileName = Path.GetFileName(proyect.ImagePath);
                    string fileFormat = fileName.Substring(fileName.Length - 4);
                    fileName = fileName.Substring(0,fileName.Length - 4);
                    newPath = Path.Combine(
                        Application.StartupPath, "Configuraciones\\images",
                        fileDirectory,
                        string.Concat(fileName, "_", (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, fileFormat)); //Se añade la fecha en timespam                   
                }
                File.Copy(proyect.ImagePath, newPath);
                proyect.ImagePath = newPath;
            }
            tw.WriteLine(proyect.ImagePath);
        }
    }
}
