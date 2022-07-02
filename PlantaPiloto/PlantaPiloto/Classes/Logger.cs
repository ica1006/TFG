using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PlantaPiloto
{
    public class Logger
    {
        public string fileDirectory {get; set;}

        public Logger(string name)
        {
            string fileName = name + " " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".txt";
            string fullDirectory = AppContext.BaseDirectory + "/Logs/";
            Directory.CreateDirectory(fullDirectory);

            DirectoryInfo directoryInfo = new DirectoryInfo(fullDirectory);
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files.OrderBy(f => f.LastWriteTime))
            {
                int filesAmount = Directory.GetFiles(fullDirectory).Length;
                if (filesAmount > 10)
                    file.Delete();
                else
                    break;
            }
            

            this.fileDirectory = fullDirectory + fileName;
        }

        public Logger(string name, string directory)
        {
            string fileName = name + " " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".txt";
            string fullDirectory = directory + "/Logs/";
            Directory.CreateDirectory(fullDirectory);

            DirectoryInfo directoryInfo = new DirectoryInfo(fullDirectory);
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files.OrderBy(f => f.LastWriteTime))
            {
                int filesAmount = Directory.GetFiles(fullDirectory).Length;
                if (filesAmount > 10)
                    file.Delete();
                else
                    break;
            }


            this.fileDirectory = fullDirectory + fileName;
        }

        /// <summary>
        /// Método que registra una nueva entrada en el log
        /// </summary>
        /// <param name="logEntry">Entrada a registrar</param>
        public void NewEntry(string logEntry)
        {
            Console.WriteLine("New log entry: " + logEntry);

            using (StreamWriter writer = File.AppendText(this.fileDirectory))
            {
                writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:ffff") + ":\t" + logEntry);
            }
        }
    }
}