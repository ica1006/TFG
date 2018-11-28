using System.Windows.Forms;

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
            this.toolStripMenuItemCreateConfig = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gBoxControls = new System.Windows.Forms.GroupBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnVar = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gBoxProyect = new System.Windows.Forms.GroupBox();
            this.dgvProVars = new System.Windows.Forms.DataGridView();
            this.pbProImg = new System.Windows.Forms.PictureBox();
            this.lblProDesc = new System.Windows.Forms.Label();
            this.lblProName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tFG_DBDataSet = new PlantaPiloto.TFG_DBDataSet();
            this.tFGDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.gBoxControls.SuspendLayout();
            this.gBoxProyect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProVars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFG_DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFGDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPorts
            // 
            this.lblPorts.AutoSize = true;
            this.lblPorts.Location = new System.Drawing.Point(495, 33);
            this.lblPorts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(34, 13);
            this.lblPorts.TabIndex = 0;
            this.lblPorts.Text = "Ports:";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(543, 31);
            this.cboPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(82, 21);
            this.cboPort.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(670, 33);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(50, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(737, 34);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(541, 60);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(247, 74);
            this.txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(737, 136);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(50, 22);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(727, 316);
            this.btnReceive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(61, 23);
            this.btnReceive.TabIndex = 7;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(495, 60);
            this.lblSend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(35, 13);
            this.lblSend.TabIndex = 8;
            this.lblSend.Text = "Send:";
            // 
            // lblReceive
            // 
            this.lblReceive.AutoSize = true;
            this.lblReceive.Location = new System.Drawing.Point(482, 184);
            this.lblReceive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReceive.Name = "lblReceive";
            this.lblReceive.Size = new System.Drawing.Size(50, 13);
            this.lblReceive.TabIndex = 9;
            this.lblReceive.Text = "Receive:";
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM3";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(541, 184);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(247, 129);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemConfig
            // 
            this.toolStripMenuItemConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateConfig,
            this.toolStripMenuItemLoadConfig,
            this.toolStripMenuItemModifyConfig});
            this.toolStripMenuItemConfig.Name = "toolStripMenuItemConfig";
            this.toolStripMenuItemConfig.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemConfig.Text = "Configuración";
            // 
            // toolStripMenuItemCreateConfig
            // 
            this.toolStripMenuItemCreateConfig.Name = "toolStripMenuItemCreateConfig";
            this.toolStripMenuItemCreateConfig.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItemCreateConfig.Text = "Crear configuración";
            this.toolStripMenuItemCreateConfig.Click += new System.EventHandler(this.toolStripMenuItemCreateConfig_Click);
            // 
            // toolStripMenuItemLoadConfig
            // 
            this.toolStripMenuItemLoadConfig.Name = "toolStripMenuItemLoadConfig";
            this.toolStripMenuItemLoadConfig.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItemLoadConfig.Text = "Cargar configuración";
            this.toolStripMenuItemLoadConfig.Click += new System.EventHandler(this.toolStripMenuItemLoadConfig_Click);
            // 
            // toolStripMenuItemModifyConfig
            // 
            this.toolStripMenuItemModifyConfig.Name = "toolStripMenuItemModifyConfig";
            this.toolStripMenuItemModifyConfig.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItemModifyConfig.Text = "Modificar configuración";
            this.toolStripMenuItemModifyConfig.Click += new System.EventHandler(this.toolStripMenuItemModifyConfig_Click);
            // 
            // toolStripMenuItemCommunication
            // 
            this.toolStripMenuItemCommunication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSerie,
            this.toolStripMenuItemOthers});
            this.toolStripMenuItemCommunication.Name = "toolStripMenuItemCommunication";
            this.toolStripMenuItemCommunication.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItemCommunication.Text = "Comunicaciones";
            // 
            // toolStripMenuItemSerie
            // 
            this.toolStripMenuItemSerie.Name = "toolStripMenuItemSerie";
            this.toolStripMenuItemSerie.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItemSerie.Text = "Serie";
            // 
            // toolStripMenuItemOthers
            // 
            this.toolStripMenuItemOthers.Name = "toolStripMenuItemOthers";
            this.toolStripMenuItemOthers.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItemOthers.Text = "Otros";
            // 
            // toolStripMenuItemLanguage
            // 
            this.toolStripMenuItemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnglish,
            this.toolStripMenuItemSpanish});
            this.toolStripMenuItemLanguage.Name = "toolStripMenuItemLanguage";
            this.toolStripMenuItemLanguage.Size = new System.Drawing.Size(56, 22);
            this.toolStripMenuItemLanguage.Text = "Idioma";
            // 
            // toolStripMenuItemEnglish
            // 
            this.toolStripMenuItemEnglish.Name = "toolStripMenuItemEnglish";
            this.toolStripMenuItemEnglish.Size = new System.Drawing.Size(115, 22);
            this.toolStripMenuItemEnglish.Text = "English";
            this.toolStripMenuItemEnglish.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSpanish
            // 
            this.toolStripMenuItemSpanish.Name = "toolStripMenuItemSpanish";
            this.toolStripMenuItemSpanish.Size = new System.Drawing.Size(115, 22);
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
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(53, 22);
            this.toolStripMenuItemHelp.Text = "Ayuda";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.userManualToolStripMenuItem.Text = "Manual de usuario";
            // 
            // toolStripMenuItemHelpHelp
            // 
            this.toolStripMenuItemHelpHelp.Name = "toolStripMenuItemHelpHelp";
            this.toolStripMenuItemHelpHelp.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemHelpHelp.Text = "Ayuda";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemAbout.Text = "Acerca de";
            // 
            // gBoxControls
            // 
            this.gBoxControls.Controls.Add(this.btnFile);
            this.gBoxControls.Controls.Add(this.btnVar);
            this.gBoxControls.Controls.Add(this.btnChart);
            this.gBoxControls.Controls.Add(this.btnFinish);
            this.gBoxControls.Controls.Add(this.btnStart);
            this.gBoxControls.Location = new System.Drawing.Point(8, 33);
            this.gBoxControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxControls.Name = "gBoxControls";
            this.gBoxControls.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxControls.Size = new System.Drawing.Size(445, 65);
            this.gBoxControls.TabIndex = 19;
            this.gBoxControls.TabStop = false;
            this.gBoxControls.Text = "groupBox1";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(324, 25);
            this.btnFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(51, 24);
            this.btnFile.TabIndex = 21;
            this.btnFile.Text = "button3";
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // btnVar
            // 
            this.btnVar.Location = new System.Drawing.Point(255, 25);
            this.btnVar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVar.Name = "btnVar";
            this.btnVar.Size = new System.Drawing.Size(65, 24);
            this.btnVar.TabIndex = 20;
            this.btnVar.Text = "button2";
            this.btnVar.UseVisualStyleBackColor = true;
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(201, 25);
            this.btnChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(51, 24);
            this.btnChart.TabIndex = 19;
            this.btnChart.Text = "button1";
            this.btnChart.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(67, 25);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(51, 24);
            this.btnFinish.TabIndex = 18;
            this.btnFinish.Text = "button2";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 25);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(51, 24);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "button1";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // gBoxProyect
            // 
            this.gBoxProyect.Controls.Add(this.dgvProVars);
            this.gBoxProyect.Controls.Add(this.pbProImg);
            this.gBoxProyect.Controls.Add(this.lblProDesc);
            this.gBoxProyect.Controls.Add(this.lblProName);
            this.gBoxProyect.Location = new System.Drawing.Point(8, 102);
            this.gBoxProyect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxProyect.Name = "gBoxProyect";
            this.gBoxProyect.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxProyect.Size = new System.Drawing.Size(445, 257);
            this.gBoxProyect.TabIndex = 20;
            this.gBoxProyect.TabStop = false;
            this.gBoxProyect.Text = "groupBox2";
            // 
            // dgvProVars
            // 
            this.dgvProVars.AllowUserToAddRows = false;
            this.dgvProVars.AllowUserToDeleteRows = false;
            this.dgvProVars.AllowUserToOrderColumns = true;
            this.dgvProVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProVars.Location = new System.Drawing.Point(201, 47);
            this.dgvProVars.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvProVars.Name = "dgvProVars";
            this.dgvProVars.ReadOnly = true;
            this.dgvProVars.RowTemplate.Height = 28;
            this.dgvProVars.Size = new System.Drawing.Size(229, 162);
            this.dgvProVars.TabIndex = 22;
            // 
            // pbProImg
            // 
            this.pbProImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbProImg.InitialImage")));
            this.pbProImg.Location = new System.Drawing.Point(12, 47);
            this.pbProImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbProImg.Name = "pbProImg";
            this.pbProImg.Size = new System.Drawing.Size(171, 166);
            this.pbProImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProImg.TabIndex = 21;
            this.pbProImg.TabStop = false;
            // 
            // lblProDesc
            // 
            this.lblProDesc.AutoSize = true;
            this.lblProDesc.Location = new System.Drawing.Point(198, 23);
            this.lblProDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProDesc.Name = "lblProDesc";
            this.lblProDesc.Size = new System.Drawing.Size(35, 13);
            this.lblProDesc.TabIndex = 20;
            this.lblProDesc.Text = "label1";
            // 
            // lblProName
            // 
            this.lblProName.AutoSize = true;
            this.lblProName.Location = new System.Drawing.Point(9, 23);
            this.lblProName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProName.Name = "lblProName";
            this.lblProName.Size = new System.Drawing.Size(35, 13);
            this.lblProName.TabIndex = 19;
            this.lblProName.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tFG_DBDataSet
            // 
            this.tFG_DBDataSet.DataSetName = "TFG_DBDataSet";
            this.tFG_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tFGDBDataSetBindingSource
            // 
            this.tFGDBDataSetBindingSource.DataSource = this.tFG_DBDataSet;
            this.tFGDBDataSetBindingSource.Position = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 367);
            this.Controls.Add(this.gBoxProyect);
            this.Controls.Add(this.gBoxControls);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Interfaz Planta Piloto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gBoxControls.ResumeLayout(false);
            this.gBoxProyect.ResumeLayout(false);
            this.gBoxProyect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProVars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFG_DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFGDBDataSetBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateConfig;
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
        private GroupBox gBoxControls;
        private Button btnFile;
        private Button btnVar;
        private Button btnChart;
        private Button btnFinish;
        private Button btnStart;
        private GroupBox gBoxProyect;
        private Label lblProDesc;
        private Label lblProName;
        private OpenFileDialog openFileDialog1;
        private PictureBox pbProImg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dgvProVars;
        private BindingSource tFGDBDataSetBindingSource;
        private TFG_DBDataSet tFG_DBDataSet;
    }
}

