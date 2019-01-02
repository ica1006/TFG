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
        public void WriteProyectProperties(StreamWriter tw, Proyect _proyect)
        {
            tw.WriteLine(DateTime.Now);
            tw.WriteLine(_proyect.Name);
            tw.WriteLine(_proyect.Description);
            tw.WriteLine(_proyect.ImagePath);
        }
    }
}
