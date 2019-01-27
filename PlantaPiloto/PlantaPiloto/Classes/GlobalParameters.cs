using System.IO;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    class GlobalParameters
    {
        public string FilesPath = Path.Combine(Application.StartupPath, "..\\..\\ApplicationData");
        public string ConfigsPath = Path.Combine(Application.StartupPath, "Configuraciones");
        public string DBPath = Path.Combine(Application.StartupPath, "DB");
    }
}
