using System.IO;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    public static class GlobalParameters
    {
        public static string FilesPath = Path.Combine(Application.StartupPath, "..\\..\\ApplicationData");
        public static string ConfigsPath = Path.Combine(Application.StartupPath, "Configuraciones");
        public static string DBPath = Path.Combine(Application.StartupPath, "DB");
        public static string DBName = "TFG_DB";
        public static float DefaultTs = 0.2F;
    }
}
