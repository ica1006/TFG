using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace PlantaPiloto
{
    public partial class MainForm : Form
    {
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info

        public MainForm()
        {
            InitializeComponent();

            toolStripMenuItemSpanish.Checked = true;    
            toolStripMenuItemEnglish.Checked = false;//default language is spanish
            res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            switch_language();
        }

        /// <summary>
        /// Método que carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            //cboPort.SelectedIndex = 0;
            btnClose.Enabled = false;
        }

        /// <summary>
        /// Método encargado de abrir una conexión con el puerto serie elegido en el comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            try
            {
                serialPort2.PortName = cboPort.Text;
                serialPort2.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método encargado de enviar un mensaje a través del puerto serie con el que se tiene conexión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort2.IsOpen)
                {
                    serialPort2.WriteLine(txtMessage.Text);
                    txtMessage.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que cierra la conexión con el puerto serie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            try
            {
                serialPort2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que recibe por el puerto serie y lo muestra en el txtBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            ;
            try
            {
                txtReceive.Clear();
                if (serialPort2.IsOpen)
                {
                    txtReceive.Text = serialPort2.ReadExisting() + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }
        }

        /// <summary>
        /// Método que se encarga de actualizar todas las etiquetas del form a la cultura correspondiente
        /// </summary>
        void switch_language()
        {
            if (toolStripMenuItemSpanish.Checked == true)    //in vietnamese
            {
                cul = CultureInfo.CreateSpecificCulture("es");    //create culture for spanish
            }
            else                                                //in english
            {
                cul = CultureInfo.CreateSpecificCulture("en");     //create culture for english
            }

            //Cambio de idioma de las cadenas
            this.Text = res_man.GetString("MainForm_txt", cul);
            this.toolStripMenuItemAbout.Text = res_man.GetString("toolStripMenuItemAbout_txt", cul);
            this.toolStripMenuItemCommunication.Text = res_man.GetString("toolStripMenuItemCommunication_txt", cul);
            this.toolStripMenuItemConfig.Text = res_man.GetString("toolStripMenuItemConfig_txt", cul);
            this.toolStripMenuItemEnglish.Text = res_man.GetString("toolStripMenuItemEnglish_txt", cul);
            this.toolStripMenuItemHelp.Text = res_man.GetString("toolStripMenuItemHelp_txt", cul);
            this.toolStripMenuItemHelpHelp.Text = res_man.GetString("toolStripMenuItemHelpHelp_txt", cul);
            this.toolStripMenuItemLanguage.Text = res_man.GetString("toolStripMenuItemLanguage_txt", cul);
            this.toolStripMenuItemLoadConfig.Text = res_man.GetString("toolStripMenuItemLoadConfig_txt", cul);
            this.toolStripMenuItemCreateConfig.Text = res_man.GetString("toolStripMenuItemCreateConfig_txt", cul);
            this.toolStripMenuItemModifyConfig.Text = res_man.GetString("toolStripMenuItemModifyConfig_txt", cul);
            this.toolStripMenuItemOthers.Text = res_man.GetString("toolStripMenuItemOthers_txt", cul);
            this.toolStripMenuItemSerie.Text = res_man.GetString("toolStripMenuItemSerie_txt", cul);
            this.toolStripMenuItemSpanish.Text = res_man.GetString("toolStripMenuItemSpanish_txt", cul);
            this.lblPorts.Text = res_man.GetString("lblPorts_txt", cul);
            this.lblReceive.Text = res_man.GetString("lblReceive_txt", cul);
            this.lblSend.Text = res_man.GetString("lblSend_txt", cul);
            this.btnClose.Text = res_man.GetString("btnClose_txt", cul);
            this.btnOpen.Text = res_man.GetString("btnOpen_txt", cul);
            this.btnReceive.Text = res_man.GetString("btnReceive_txt", cul);
            this.btnSend.Text = res_man.GetString("btnSend_txt", cul);
            this.btnStart.Text = res_man.GetString("btnStart_txt", cul);
            this.btnFinish.Text = res_man.GetString("btnFinish_txt", cul);
            this.btnChart.Text = res_man.GetString("btnChart_txt", cul);
            this.btnVar.Text = res_man.GetString("btnVar_txt", cul);
            this.btnFile.Text = res_man.GetString("btnFile_txt", cul);
            this.lblProDesc.Text = res_man.GetString("lblProDesc_txt", cul);
            this.lblProName.Text = res_man.GetString("lblProName_txt", cul);
        }

        /// <summary>
        /// Método que cambia el idioma a inglés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItemSpanish.Checked = false;
            toolStripMenuItemEnglish.Checked = true;
            switch_language();
        }

        /// <summary>
        /// Método que cambia el idioma a español
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSpanish_Click(object sender, EventArgs e)
        {
            toolStripMenuItemSpanish.Checked = true;
            toolStripMenuItemEnglish.Checked = false;
            switch_language();
        }
    }
}
