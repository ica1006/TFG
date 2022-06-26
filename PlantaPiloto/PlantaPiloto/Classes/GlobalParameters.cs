using System.IO;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    public static class GlobalParameters
    {
        public static string FilesPath { get; } = Path.Combine(Application.StartupPath, "ApplicationData");
        public static string ConfigsPath { get; } = Path.Combine(Application.StartupPath, "Configuraciones");
        public static string DBPath { get; } = Path.Combine(Application.StartupPath, "DB");
        public static string DBName { get; } = "TFG-PlantaPiloto";
        public static string DBCreationUser{ get; } = "MSSQL$SQLEXPRESS";
        public static float DefaultTs { get; } = 0.2F;
        public static Logger log = new Logger("Log");
        public static Logger errorLog = new Logger("Error Log");
    }
}
