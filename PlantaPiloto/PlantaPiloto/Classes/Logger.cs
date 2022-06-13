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
            string directory = Directory.GetCurrentDirectory() + "/Logs/";
            Directory.CreateDirectory(directory);

            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files.OrderBy(f => f.LastWriteTime))
            {
                int filesAmount = Directory.GetFiles(directory).Length;
                if (filesAmount > 10)
                    file.Delete();
                else
                    break;
            }
            

            this.fileDirectory = Directory.GetCurrentDirectory() + "/Logs/" + fileName;
        }

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