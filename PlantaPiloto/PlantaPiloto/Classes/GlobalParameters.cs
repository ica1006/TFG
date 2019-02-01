using System.IO;
using System.Windows.Forms;

namespace PlantaPiloto.Classes
{
    public static class GlobalParameters
    {
        public static string FilesPath { get; } = Path.Combine(Application.StartupPath, "ApplicationData");
        public static string ConfigsPath { get; } = Path.Combine(Application.StartupPath, "Configuraciones");
        public static string DBPath { get; } = Path.Combine(Application.StartupPath, "DB");
        public static string DBName { get; } = "TFG_DB";
        //public static string DBCreationUser{ get; } = @"NT Service\SQLTELEMETRY$SQLEXPRESS";
        public static string DBCreationUser{ get; } = "MSSQL$SQLEXPRESS";
        public static float DefaultTs { get; } = 0.2F;
    }
}
