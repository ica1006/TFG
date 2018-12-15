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
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
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
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnVar = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gBoxProyect = new System.Windows.Forms.GroupBox();
            this.lblRWVariables = new System.Windows.Forms.Label();
            this.dgvProVars = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblPorts.Location = new System.Drawing.Point(10, 28);
            this.lblPorts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPorts.Name = "lblPorts";
            this.lblPorts.Size = new System.Drawing.Size(34, 13);
            this.lblPorts.TabIndex = 0;
            this.lblPorts.Text = "Ports:";
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(56, 27);
            this.cboPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(82, 21);
            this.cboPort.TabIndex = 1;
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM3";
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
            this.menuStrip1.Size = new System.Drawing.Size(619, 24);
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
            this.gBoxControls.Controls.Add(this.btnRefreshPorts);
            this.gBoxControls.Controls.Add(this.btnFile);
            this.gBoxControls.Controls.Add(this.btnVar);
            this.gBoxControls.Controls.Add(this.btnChart);
            this.gBoxControls.Controls.Add(this.btnFinish);
            this.gBoxControls.Controls.Add(this.btnStart);
            this.gBoxControls.Controls.Add(this.cboPort);
            this.gBoxControls.Controls.Add(this.lblPorts);
            this.gBoxControls.Location = new System.Drawing.Point(8, 33);
            this.gBoxControls.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxControls.Name = "gBoxControls";
            this.gBoxControls.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxControls.Size = new System.Drawing.Size(601, 65);
            this.gBoxControls.TabIndex = 19;
            this.gBoxControls.TabStop = false;
            this.gBoxControls.Text = "groupBox1";
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshPorts.Location = new System.Drawing.Point(144, 26);
            this.btnRefreshPorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(63, 24);
            this.btnRefreshPorts.TabIndex = 22;
            this.btnRefreshPorts.Text = "Actualizar";
            this.btnRefreshPorts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(532, 26);
            this.btnFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(51, 24);
            this.btnFile.TabIndex = 21;
            this.btnFile.Text = "Archivo";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnVar
            // 
            this.btnVar.Location = new System.Drawing.Point(463, 26);
            this.btnVar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVar.Name = "btnVar";
            this.btnVar.Size = new System.Drawing.Size(65, 24);
            this.btnVar.TabIndex = 20;
            this.btnVar.Text = "Variables";
            this.btnVar.UseVisualStyleBackColor = true;
            this.btnVar.Click += new System.EventHandler(this.btnVar_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(409, 26);
            this.btnChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(51, 24);
            this.btnChart.TabIndex = 19;
            this.btnChart.Text = "Graficar";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(277, 26);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(51, 24);
            this.btnFinish.TabIndex = 18;
            this.btnFinish.Text = "Fin";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(222, 26);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(51, 24);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Inicio";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gBoxProyect
            // 
            this.gBoxProyect.Controls.Add(this.lblRWVariables);
            this.gBoxProyect.Controls.Add(this.dgvProVars);
            this.gBoxProyect.Controls.Add(this.pbProImg);
            this.gBoxProyect.Controls.Add(this.lblProDesc);
            this.gBoxProyect.Controls.Add(this.lblProName);
            this.gBoxProyect.Location = new System.Drawing.Point(8, 102);
            this.gBoxProyect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxProyect.Name = "gBoxProyect";
            this.gBoxProyect.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gBoxProyect.Size = new System.Drawing.Size(601, 327);
            this.gBoxProyect.TabIndex = 20;
            this.gBoxProyect.TabStop = false;
            this.gBoxProyect.Text = "groupBox2";
            // 
            // lblRWVariables
            // 
            this.lblRWVariables.AutoSize = true;
            this.lblRWVariables.Location = new System.Drawing.Point(219, 23);
            this.lblRWVariables.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRWVariables.Name = "lblRWVariables";
            this.lblRWVariables.Size = new System.Drawing.Size(74, 13);
            this.lblRWVariables.TabIndex = 23;
            this.lblRWVariables.Text = "VariablesR/W";
            // 
            // dgvProVars
            // 
            this.dgvProVars.AllowUserToAddRows = false;
            this.dgvProVars.AllowUserToDeleteRows = false;
            this.dgvProVars.AllowUserToOrderColumns = true;
            this.dgvProVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvProVars.Location = new System.Drawing.Point(222, 41);
            this.dgvProVars.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvProVars.Name = "dgvProVars";
            this.dgvProVars.RowTemplate.Height = 28;
            this.dgvProVars.Size = new System.Drawing.Size(361, 273);
            this.dgvProVars.TabIndex = 22;
            this.dgvProVars.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProVars_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // pbProImg
            // 
            this.pbProImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbProImg.InitialImage")));
            this.pbProImg.Location = new System.Drawing.Point(13, 132);
            this.pbProImg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbProImg.Name = "pbProImg";
            this.pbProImg.Size = new System.Drawing.Size(191, 182);
            this.pbProImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProImg.TabIndex = 21;
            this.pbProImg.TabStop = false;
            // 
            // lblProDesc
            // 
            this.lblProDesc.Location = new System.Drawing.Point(10, 48);
            this.lblProDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProDesc.MaximumSize = new System.Drawing.Size(363, 141);
            this.lblProDesc.Name = "lblProDesc";
            this.lblProDesc.Size = new System.Drawing.Size(193, 68);
            this.lblProDesc.TabIndex = 20;
            this.lblProDesc.Text = "label1";
            // 
            // lblProName
            // 
            this.lblProName.Location = new System.Drawing.Point(10, 23);
            this.lblProName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProName.Name = "lblProName";
            this.lblProName.Size = new System.Drawing.Size(193, 25);
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
            this.ClientSize = new System.Drawing.Size(619, 436);
            this.Controls.Add(this.gBoxProyect);
            this.Controls.Add(this.gBoxControls);
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
            this.gBoxControls.PerformLayout();
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
        private System.IO.Ports.SerialPort serialPort2;
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
        private Button btnRefreshPorts;
        private Label lblRWVariables;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

