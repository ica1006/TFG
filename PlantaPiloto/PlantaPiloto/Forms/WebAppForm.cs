using PlantaPiloto.Classes;
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
using System.Threading;
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
        private int processId = -1;
        private HelpProvider _helpProvider;
        private ExceptionManagement _exMg;

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
            _helpProvider = new HelpProvider();
            _helpProvider.HelpNamespace = Path.Combine(GlobalParameters.FilesPath, "helpProyect.chm");
            _exMg = new ExceptionManagement(_cul);

            this.Switch_language();
            this.InitializeTextBoxesText();
        }

        /// <summary>
        /// Método que carga los valores por defecto en los recuadros de texto.
        /// </summary>
        private void InitializeTextBoxesText()
        {
            this.txtConnectionString.Text = connectionString;
            this.txtIISlocation.Text = IISExpressPath;
            this.txtIP.Text = ipAdress;
            this.txtPort.Text = port;
            this.txtProjectPath.Text = projectFilePath;
            this.txtWebAppPath.Text = webAppPath;
        }

        /// <summary>
        /// Método encargado de gestionar el cambio de idioma.
        /// </summary>
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
            this.btnCloseServer.Text = _res_man.GetString("btnCloseServer_txt", _cul);
        }

        /// <summary>
        /// Evento que actúa cuando el usuario da click en el botón Lanzar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c cd ^\"" + this.IISExpressPath + "^\" & iisexpress /config:^\"" + webAppPath + "\\iisexpress.config^\" & pause";
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                processId = process.Id;

                Thread.Sleep(1000);
                Process.Start("http://" + ipAdress + ":" + port + "/Main");
                changeButtons();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        /// <summary>
        /// Método que devuelve si el script de lanzamiento está en ejecución
        /// </summary>
        private bool isProcessStarted()
        {
            Process requestedProcess = null;
            if (!processId.Equals(-1))
                try {
                    requestedProcess = Process.GetProcessById(processId); 
                }
                catch (Exception) { /* It can be ignored because the exception means that there is no process started */ }

            if (requestedProcess != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Método que deshabilita el botón Lanzar cuando el script ya ha sido lanzado
        /// </summary>
        private void changeButtons()
        {
            int i = 0;
            while (true)
            {
                i++;
                if (isProcessStarted())
                {
                    btnLaunchWebApp.Enabled = false;
                }
                else
                {
                    btnLaunchWebApp.Enabled = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Método que lee los parámetros indicados por el usuario en los boxes de texto.
        /// </summary>
        private void readTextValues()
        {
            connectionString = this.txtConnectionString.Text;
            IISExpressPath = this.txtIISlocation.Text;
            ipAdress = this.txtIP.Text;
            port = this.txtPort.Text;
            projectFilePath = this.txtProjectPath.Text;
            webAppPath = this.txtWebAppPath.Text;
        }

        /// <summary>
        /// Evento que actúa cuando el usuario escribe en el box del puerto, para asegurarse de introducir un formato válido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Evento que actúa cuando el usuario termina de escribir en el box del puerto, para asegurarse de introducir un formato válido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            int number = -1;
            if (!int.TryParse(txtPort.Text, out number) && txtPort.Text != "")
                txtPort.Text = "1337";
            if ((number > 65535 || number < 1) && txtPort.Text != "")
                txtPort.Text = "1337";
            checkIfItCanLaunch(sender, e);
        }

        /// <summary>
        /// Método que verifica que ningún campo esté en blanco, para permitir lanzar la aplicación web
        /// </summary>
        /// <param name="sender"></param>
        private void checkIfItCanLaunch(object sender, EventArgs e)
        {
            if (txtPort.Text != "" && txtIP.Text != "" && txtIISlocation.Text != "" && txtWebAppPath.Text != "" && txtProjectPath.Text != "" && txtConnectionString.Text != "")
                btnLaunchWebApp.Enabled = true;
            else
                btnLaunchWebApp.Enabled = false;
        }

        /// <summary>
        /// Evento que actúa cuando el usuario presiona el botón de ayuda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "WebApp");
                GlobalParameters.log.NewEntry("Help window oppened.");
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
                GlobalParameters.errorLog.NewEntry("Exception oppening the help window.\n" + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
