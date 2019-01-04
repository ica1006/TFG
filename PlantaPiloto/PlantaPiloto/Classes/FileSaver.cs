using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            tw.WriteLine(_proyect.ImagePath);
        }
    }
}
