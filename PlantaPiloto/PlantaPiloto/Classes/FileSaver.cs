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
        /// <param name="_proyect">Proyecto del que se guardan las propiedades</param>
        public void WriteProyectProperties(StreamWriter tw, Proyect _proyect)
        {
            tw.WriteLine(DateTime.Now);
            tw.WriteLine(_proyect.Name);
            tw.WriteLine(_proyect.Description);
            if (File.Exists(_proyect.ImagePath))
            {
                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Configuraciones\\images")))
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Configuraciones\\images"));
                string newPath = Path.Combine(Application.StartupPath, "Configuraciones\\images", Path.GetFileName(_proyect.ImagePath));
                File.Copy(_proyect.ImagePath, newPath);
                _proyect.ImagePath = newPath;
            }
                tw.WriteLine(_proyect.ImagePath);
        }
    }
}
