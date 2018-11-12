namespace PlantaPiloto
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblPorts = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.lblSend = new System.Windows.Forms.Label();
            this.lblReceive = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMakeConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemModifyConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Location = new System.Drawing.Point(743, 51);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(50, 20);
            this.lblPorts.TabIndex = 0;
            this.lblPorts.Text = "Ports:";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(815, 48);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(121, 28);
            this.cboPort.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(1005, 51);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 35);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1106, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(812, 92);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(369, 112);
            this.txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1106, 210);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 34);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(1090, 486);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(91, 35);
            this.btnReceive.TabIndex = 7;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(742, 92);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(51, 20);
            this.lblSend.TabIndex = 8;
            this.lblSend.Text = "Send:";
            // 
            // lblReceive
            // 
            this.lblReceive.AutoSize = true;
            this.lblReceive.Location = new System.Drawing.Point(723, 286);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(70, 20);
            this.lblReceive.TabIndex = 9;
            this.lblReceive.Text = "Receive:";
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM3";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(812, 283);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(369, 197);
            this.txtReceive.TabIndex = 10;
            this.txtReceive.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConfig,
            this.toolStripMenuItemCommunication,
            this.toolStripMenuItemLanguage,
            this.toolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1205, 33);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMakeConfig,
            this.toolStripMenuItemLoadConfig,
            this.toolStripMenuItemModifyConfig});
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            this.toolStripMenuItemConfig.Size = new System.Drawing.Size(135, 29);
            this.toolStripMenuItemConfig.Text = "Configuración";
            // 
            // toolStripMenuItemMakeConfig
            // 
            this.toolStripMenuItemMakeConfig.Name = "toolStripMenuItemMakeConfig";
            this.toolStripMenuItemMakeConfig.Size = new System.Drawing.Size(284, 30);
            this.toolStripMenuItemMakeConfig.Text = "Crear configuración";
            // 
            // toolStripMenuItemLoadConfig
            // 
            this.toolStripMenuItemLoadConfig.Name = "toolStripMenuItemLoadConfig";
            this.toolStripMenuItemLoadConfig.Size = new System.Drawing.Size(284, 30);
            this.toolStripMenuItemLoadConfig.Text = "Cargar configuración";
            // 
            // toolStripMenuItemModifyConfig
            // 
            this.toolStripMenuItemModifyConfig.Name = "toolStripMenuItemModifyConfig";
            this.toolStripMenuItemModifyConfig.Size = new System.Drawing.Size(284, 30);
            this.toolStripMenuItemModifyConfig.Text = "Modificar configuración";
            // 
            // toolStripMenuItemCommunication
            // 
            this.toolStripMenuItemCommunication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSerie,
            this.toolStripMenuItemOthers});
            this.toolStripMenuItemCommunication.Name = "toolStripMenuItemCommunication";
            this.toolStripMenuItemCommunication.Size = new System.Drawing.Size(153, 29);
            this.toolStripMenuItemCommunication.Text = "Comunicaciones";
            // 
            // toolStripMenuItemSerie
            // 
            this.toolStripMenuItemSerie.Name = "toolStripMenuItemSerie";
            this.toolStripMenuItemSerie.Size = new System.Drawing.Size(141, 30);
            this.toolStripMenuItemSerie.Text = "Serie";
            // 
            // toolStripMenuItemOthers
            // 
            this.toolStripMenuItemOthers.Name = "toolStripMenuItemOthers";
            this.toolStripMenuItemOthers.Size = new System.Drawing.Size(141, 30);
            this.toolStripMenuItemOthers.Text = "Otros";
            // 
            // toolStripMenuItemLanguage
            // 
            this.toolStripMenuItemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnglish,
            this.toolStripMenuItemSpanish});
            this.toolStripMenuItemLanguage.Name = "toolStripMenuItemLanguage";
            this.toolStripMenuItemLanguage.Size = new System.Drawing.Size(80, 29);
            this.toolStripMenuItemLanguage.Text = "Idioma";
            // 
            // toolStripMenuItemEnglish
            // 
            this.toolStripMenuItemEnglish.Name = "toolStripMenuItemEnglish";
            this.toolStripMenuItemEnglish.Size = new System.Drawing.Size(252, 30);
            this.toolStripMenuItemEnglish.Text = "English";
            this.toolStripMenuItemEnglish.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSpanish
            // 
            this.toolStripMenuItemSpanish.Name = "toolStripMenuItemSpanish";
            this.toolStripMenuItemSpanish.Size = new System.Drawing.Size(252, 30);
            this.toolStripMenuItemSpanish.Text = "Español";
            this.toolStripMenuItemSpanish.Click += new System.EventHandler(this.toolStripMenuItemSpanish_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem,
            this.toolStripMenuItemHelpHelp,
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(75, 29);
            this.toolStripMenuItemHelp.Text = "Ayuda";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.userManualToolStripMenuItem.Text = "Manual de usuario";
            // 
            // toolStripMenuItemHelpHelp
            // 
            this.toolStripMenuItemHelpHelp.Name = "toolStripMenuItemHelpHelp";
            this.toolStripMenuItemHelpHelp.Size = new System.Drawing.Size(242, 30);
            this.toolStripMenuItemHelpHelp.Text = "Ayuda";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(242, 30);
            this.toolStripMenuItemAbout.Text = "Acerca de";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 565);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.lblReceive);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.lblPorts);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Interfaz Planta Piloto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPorts;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Label lblReceive;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMakeConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemModifyConfig;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCommunication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSerie;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOthers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelpHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnglish;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSpanish;
    }
}

