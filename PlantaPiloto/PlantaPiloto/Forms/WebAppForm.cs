using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PlantaPiloto.Forms
{
    public partial class WebAppForm : Form
    {
        readonly ResourceManager _res_man;
        readonly CultureInfo _cul;

        private string port;
        private string IISExpressPath;
        private string ipAdress;
        private string webAppPath;
        private string connectionString;
        private string projectFilePath;

        public WebAppForm(string connectionString, string projectFilePath, CultureInfo _cul)
        {
            InitializeComponent();
            this._res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            this._cul = _cul;
            this.port = "1337";
            this.ipAdress = "localhost";
            this.IISExpressPath = "C:\\Program Files (x86)\\IIS Express";
            this.connectionString = connectionString;
            this.projectFilePath = projectFilePath;
            this.webAppPath = Directory.GetCurrentDirectory() + "\\WebAppRelease";

            this.Switch_language();
            this.InitializeTextBoxesText();
        }

        private void InitializeTextBoxesText()
        {
            this.txtConnectionString.Text = connectionString;
            this.txtIISlocation.Text = IISExpressPath;
            this.txtIP.Text = ipAdress;
            this.txtPort.Text = port;
            this.txtProjectPath.Text = projectFilePath;
            this.txtWebAppPath.Text = webAppPath;
        }

        public void Switch_language()
        {
            this.lblIISlocation.Text = _res_man.GetString("lblIISlocation_txt", _cul);
            this.lblIP.Text = _res_man.GetString("lblIP_txt", _cul);
            this.lblPort.Text = _res_man.GetString("lblPort_txt", _cul);
            this.gbWebApp.Text = _res_man.GetString("gbWebApp_txt", _cul);
            this.lblWebAppPath.Text = _res_man.GetString("lblWebAppPath_txt", _cul);
            this.lblProjectPath.Text = _res_man.GetString("lblProjectPath_txt", _cul);
            this.lblConnectionString.Text = _res_man.GetString("lblConnectionString_txt", _cul);
            this.btnLaunchWebApp.Text = _res_man.GetString("btnLaunchWebApp_txt", _cul);
        }

        private void btnLaunchWebApp_Click(object sender, EventArgs e)
        {
            try
            {
                readTextValues();

                XmlDocument config = new XmlDocument();
                config.Load(webAppPath + "\\iisexpress.config");
                XmlNode virtualDirectory = config.SelectSingleNode("configuration/system.applicationHost/sites/site[@id=1]/application/virtualDirectory");
                virtualDirectory.Attributes[1].Value = webAppPath;
                XmlNode binding = config.SelectSingleNode("configuration/system.applicationHost/sites/site[@id=1]/bindings/binding");
                binding.Attributes[1].Value = "*:" + port + ":" + ipAdress;
                config.Save(webAppPath + "\\iisexpress.config");

                XmlDocument webParametters = new XmlDocument();
                XmlElement parametters = webParametters.CreateElement("parametters");
                XmlElement connectionStringXml = webParametters.CreateElement("connectionString");
                connectionStringXml.InnerText = connectionString;
                XmlElement webAppPathXml = webParametters.CreateElement("webAppPath");
                webAppPathXml.InnerText = webAppPath;
                parametters.AppendChild(connectionStringXml);
                parametters.AppendChild(webAppPathXml);
                webParametters.AppendChild(parametters);
                webParametters.Save(webAppPath + "\\webParametters.xml");

                File.Copy(projectFilePath, webAppPath + "\\project.txt", true);

                File.WriteAllText(this.webAppPath + "\\launch.bat", "chcp 65001\ncd \"" + this.IISExpressPath + "\" \niiiisexpress /config:\"" + webAppPath + "\\iisexpress.config\"" + "\npause");
                Process process = new Process();
                process.StartInfo.FileName = this.webAppPath + "\\launch.bat";
                process.Start();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void readTextValues()
        {
            connectionString = this.txtConnectionString.Text;
            IISExpressPath = this.txtIISlocation.Text;
            ipAdress = this.txtIP.Text;
            port = this.txtPort.Text;
            projectFilePath = this.txtProjectPath.Text;
            webAppPath = this.txtWebAppPath.Text;
        }
    }
}
