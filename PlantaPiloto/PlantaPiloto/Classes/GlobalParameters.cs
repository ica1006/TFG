using System.IO;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    public static class GlobalParameters
    {
        static readonly string _filesPath = Path.Combine(Application.StartupPath, "..\\..\\ApplicationData");
        public static string FilesPath
        {
            get { return _filesPath; }
        }
        static readonly string _configsPath = Path.Combine(Application.StartupPath, "Configuraciones");
        public static string ConfigsPath
        {
            get { return _configsPath; }
        }
        static readonly string _dBPath = Path.Combine(Application.StartupPath, "DB");
        public static string DBPath
        {
            get { return _dBPath; }
        }
        static readonly string _dBName = "TFG_DB";
        public static string DBName
        {
            get { return _dBName; }
        }
        public static float DefaultTs { get; } = 0.2F;
    }
}
