using PlantaPiloto.Enums;
using System;

namespace PlantaPiloto
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.gbProyectDetails = new System.Windows.Forms.GroupBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.lblVectFile = new System.Windows.Forms.Label();
            this.txtProDesc = new System.Windows.Forms.RichTextBox();
            this.txtProName = new System.Windows.Forms.RichTextBox();
            this.lblConfigProDesc = new System.Windows.Forms.Label();
            this.lblConfigProName = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.gbNewVar = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVarCommunicationType = new System.Windows.Forms.ComboBox();
            this.txtVarRangeHigh = new System.Windows.Forms.RichTextBox();
            this.txtVarRangeLow = new System.Windows.Forms.RichTextBox();
            this.txtVarLinearAdjB = new System.Windows.Forms.RichTextBox();
            this.txtVarLinearAdjA = new System.Windows.Forms.RichTextBox();
            this.txtVarInterfaceUnits = new System.Windows.Forms.RichTextBox();
            this.txtVarBoardUnits = new System.Windows.Forms.RichTextBox();
            this.cbVarAccess = new System.Windows.Forms.ComboBox();
            this.cbVarType = new System.Windows.Forms.ComboBox();
            this.txtVarName = new System.Windows.Forms.RichTextBox();
            this.txtVarDesc = new System.Windows.Forms.RichTextBox();
            this.lblVarRange = new System.Windows.Forms.Label();
            this.lblVarLinearAdjust = new System.Windows.Forms.Label();
            this.lblVarCommunicationType = new System.Windows.Forms.Label();
            this.lblVarType = new System.Windows.Forms.Label();
            this.lblVarAccess = new System.Windows.Forms.Label();
            this.lblVarBoardUnits = new System.Windows.Forms.Label();
            this.lblVarInterfaceUnits = new System.Windows.Forms.Label();
            this.lblVarDesc = new System.Windows.Forms.Label();
            this.lblVarName = new System.Windows.Forms.Label();
            this.btnAddVar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSelectVar = new System.Windows.Forms.Label();
            this.cbSelectVar = new System.Windows.Forms.ComboBox();
            this.gbProyectDetails.SuspendLayout();
            this.gbNewVar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbProyectDetails
            // 
            this.gbProyectDetails.Controls.Add(this.btnLoadImage);
            this.gbProyectDetails.Controls.Add(this.lblVectFile);
            this.gbProyectDetails.Controls.Add(this.txtProDesc);
            this.gbProyectDetails.Controls.Add(this.txtProName);
            this.gbProyectDetails.Controls.Add(this.lblConfigProDesc);
            this.gbProyectDetails.Controls.Add(this.lblConfigProName);
            this.gbProyectDetails.Location = new System.Drawing.Point(8, 8);
            this.gbProyectDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbProyectDetails.Name = "gbProyectDetails";
            this.gbProyectDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbProyectDetails.Size = new System.Drawing.Size(677, 57);
            this.gbProyectDetails.TabIndex = 6;
            this.gbProyectDetails.TabStop = false;
            this.gbProyectDetails.Text = "DatosProyecto";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(559, 25);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(106, 24);
            this.btnLoadImage.TabIndex = 22;
            this.btnLoadImage.Text = "Cargar imagen";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // lblVectFile
            // 
            this.lblVectFile.AutoSize = true;
            this.lblVectFile.Location = new System.Drawing.Point(471, 34);
            this.lblVectFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVectFile.Name = "lblVectFile";
            this.lblVectFile.Size = new System.Drawing.Size(41, 13);
            this.lblVectFile.TabIndex = 10;
            this.lblVectFile.Text = "imagen";
            // 
            // txtProDesc
            // 
            this.txtProDesc.Location = new System.Drawing.Point(326, 29);
            this.txtProDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtProDesc.Multiline = false;
            this.txtProDesc.Name = "txtProDesc";
            this.txtProDesc.Size = new System.Drawing.Size(121, 20);
            this.txtProDesc.TabIndex = 9;
            this.txtProDesc.Text = "";
            // 
            // txtProName
            // 
            this.txtProName.Location = new System.Drawing.Point(127, 29);
            this.txtProName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProName.Multiline = false;
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(121, 20);
            this.txtProName.TabIndex = 8;
            this.txtProName.Text = "";
            // 
            // lblConfigProDesc
            // 
            this.lblConfigProDesc.AutoSize = true;
            this.lblConfigProDesc.Location = new System.Drawing.Point(261, 34);
            this.lblConfigProDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfigProDesc.Name = "lblConfigProDesc";
            this.lblConfigProDesc.Size = new System.Drawing.Size(30, 13);
            this.lblConfigProDesc.TabIndex = 7;
            this.lblConfigProDesc.Text = "desc";
            // 
            // lblConfigProName
            // 
            this.lblConfigProName.AutoSize = true;
            this.lblConfigProName.Location = new System.Drawing.Point(21, 34);
            this.lblConfigProName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfigProName.Name = "lblConfigProName";
            this.lblConfigProName.Size = new System.Drawing.Size(33, 13);
            this.lblConfigProName.TabIndex = 6;
            this.lblConfigProName.Text = "nomb";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(522, 315);
            this.btnSaveConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(83, 23);
            this.btnSaveConfig.TabIndex = 22;
            this.btnSaveConfig.Text = "Guardar configuración";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.saveConfigFile_Click);
            // 
            // gbNewVar
            // 
            this.gbNewVar.Controls.Add(this.pictureBox1);
            this.gbNewVar.Controls.Add(this.label2);
            this.gbNewVar.Controls.Add(this.label1);
            this.gbNewVar.Controls.Add(this.cbVarCommunicationType);
            this.gbNewVar.Controls.Add(this.txtVarRangeHigh);
            this.gbNewVar.Controls.Add(this.txtVarRangeLow);
            this.gbNewVar.Controls.Add(this.txtVarLinearAdjB);
            this.gbNewVar.Controls.Add(this.txtVarLinearAdjA);
            this.gbNewVar.Controls.Add(this.txtVarInterfaceUnits);
            this.gbNewVar.Controls.Add(this.txtVarBoardUnits);
            this.gbNewVar.Controls.Add(this.cbVarAccess);
            this.gbNewVar.Controls.Add(this.cbVarType);
            this.gbNewVar.Controls.Add(this.txtVarName);
            this.gbNewVar.Controls.Add(this.txtVarDesc);
            this.gbNewVar.Controls.Add(this.lblVarRange);
            this.gbNewVar.Controls.Add(this.lblVarLinearAdjust);
            this.gbNewVar.Controls.Add(this.lblVarCommunicationType);
            this.gbNewVar.Controls.Add(this.lblVarType);
            this.gbNewVar.Controls.Add(this.lblVarAccess);
            this.gbNewVar.Controls.Add(this.lblVarBoardUnits);
            this.gbNewVar.Controls.Add(this.lblVarInterfaceUnits);
            this.gbNewVar.Controls.Add(this.lblVarDesc);
            this.gbNewVar.Controls.Add(this.lblVarName);
            this.gbNewVar.Controls.Add(this.btnAddVar);
            this.gbNewVar.Location = new System.Drawing.Point(8, 69);
            this.gbNewVar.Margin = new System.Windows.Forms.Padding(2);
            this.gbNewVar.Name = "gbNewVar";
            this.gbNewVar.Padding = new System.Windows.Forms.Padding(2);
            this.gbNewVar.Size = new System.Drawing.Size(677, 236);
            this.gbNewVar.TabIndex = 16;
            this.gbNewVar.TabStop = false;
            this.gbNewVar.Text = "newVar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::PlantaPiloto.Properties.Resources.help;
            this.pictureBox1.Location = new System.Drawing.Point(629, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(511, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "-";
            // 
            // cbVarCommunicationType
            // 
            this.cbVarCommunicationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarCommunicationType.FormattingEnabled = true;
            this.cbVarCommunicationType.Location = new System.Drawing.Point(174, 179);
            this.cbVarCommunicationType.Margin = new System.Windows.Forms.Padding(2);
            this.cbVarCommunicationType.Name = "cbVarCommunicationType";
            this.cbVarCommunicationType.Size = new System.Drawing.Size(121, 21);
            this.cbVarCommunicationType.TabIndex = 20;
            // 
            // txtVarRangeHigh
            // 
            this.txtVarRangeHigh.Location = new System.Drawing.Point(532, 138);
            this.txtVarRangeHigh.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarRangeHigh.Multiline = false;
            this.txtVarRangeHigh.Name = "txtVarRangeHigh";
            this.txtVarRangeHigh.Size = new System.Drawing.Size(45, 20);
            this.txtVarRangeHigh.TabIndex = 19;
            this.txtVarRangeHigh.Text = "";
            this.txtVarRangeHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberInput);
            // 
            // txtVarRangeLow
            // 
            this.txtVarRangeLow.Location = new System.Drawing.Point(456, 138);
            this.txtVarRangeLow.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarRangeLow.Multiline = false;
            this.txtVarRangeLow.Name = "txtVarRangeLow";
            this.txtVarRangeLow.Size = new System.Drawing.Size(45, 20);
            this.txtVarRangeLow.TabIndex = 18;
            this.txtVarRangeLow.Text = "";
            this.txtVarRangeLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberInput);
            // 
            // txtVarLinearAdjB
            // 
            this.txtVarLinearAdjB.Location = new System.Drawing.Point(250, 138);
            this.txtVarLinearAdjB.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarLinearAdjB.Multiline = false;
            this.txtVarLinearAdjB.Name = "txtVarLinearAdjB";
            this.txtVarLinearAdjB.Size = new System.Drawing.Size(45, 20);
            this.txtVarLinearAdjB.TabIndex = 17;
            this.txtVarLinearAdjB.Text = "0";
            this.txtVarLinearAdjB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberInput);
            // 
            // txtVarLinearAdjA
            // 
            this.txtVarLinearAdjA.Location = new System.Drawing.Point(174, 138);
            this.txtVarLinearAdjA.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarLinearAdjA.Multiline = false;
            this.txtVarLinearAdjA.Name = "txtVarLinearAdjA";
            this.txtVarLinearAdjA.Size = new System.Drawing.Size(45, 20);
            this.txtVarLinearAdjA.TabIndex = 16;
            this.txtVarLinearAdjA.Text = "1";
            this.txtVarLinearAdjA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumberInput);
            // 
            // txtVarInterfaceUnits
            // 
            this.txtVarInterfaceUnits.Location = new System.Drawing.Point(456, 100);
            this.txtVarInterfaceUnits.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarInterfaceUnits.Multiline = false;
            this.txtVarInterfaceUnits.Name = "txtVarInterfaceUnits";
            this.txtVarInterfaceUnits.Size = new System.Drawing.Size(121, 20);
            this.txtVarInterfaceUnits.TabIndex = 15;
            this.txtVarInterfaceUnits.Text = "";
            // 
            // txtVarBoardUnits
            // 
            this.txtVarBoardUnits.Location = new System.Drawing.Point(174, 100);
            this.txtVarBoardUnits.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarBoardUnits.Multiline = false;
            this.txtVarBoardUnits.Name = "txtVarBoardUnits";
            this.txtVarBoardUnits.Size = new System.Drawing.Size(121, 20);
            this.txtVarBoardUnits.TabIndex = 14;
            this.txtVarBoardUnits.Text = "";
            // 
            // cbVarAccess
            // 
            this.cbVarAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarAccess.FormattingEnabled = true;
            this.cbVarAccess.Location = new System.Drawing.Point(456, 59);
            this.cbVarAccess.Margin = new System.Windows.Forms.Padding(2);
            this.cbVarAccess.Name = "cbVarAccess";
            this.cbVarAccess.Size = new System.Drawing.Size(121, 21);
            this.cbVarAccess.TabIndex = 13;
            // 
            // cbVarType
            // 
            this.cbVarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarType.FormattingEnabled = true;
            this.cbVarType.Location = new System.Drawing.Point(455, 22);
            this.cbVarType.Margin = new System.Windows.Forms.Padding(2);
            this.cbVarType.Name = "cbVarType";
            this.cbVarType.Size = new System.Drawing.Size(121, 21);
            this.cbVarType.TabIndex = 11;
            this.cbVarType.SelectedValueChanged += new System.EventHandler(this.cbVarType_SelectedValueChanged);
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(174, 19);
            this.txtVarName.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarName.Multiline = false;
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(121, 20);
            this.txtVarName.TabIndex = 10;
            this.txtVarName.Text = "";
            // 
            // txtVarDesc
            // 
            this.txtVarDesc.Location = new System.Drawing.Point(174, 59);
            this.txtVarDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtVarDesc.Multiline = false;
            this.txtVarDesc.Name = "txtVarDesc";
            this.txtVarDesc.Size = new System.Drawing.Size(121, 20);
            this.txtVarDesc.TabIndex = 12;
            this.txtVarDesc.Text = "";
            // 
            // lblVarRange
            // 
            this.lblVarRange.AutoSize = true;
            this.lblVarRange.Location = new System.Drawing.Point(335, 143);
            this.lblVarRange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarRange.Name = "lblVarRange";
            this.lblVarRange.Size = new System.Drawing.Size(50, 13);
            this.lblVarRange.TabIndex = 24;
            this.lblVarRange.Text = "rangoVar";
            // 
            // lblVarLinearAdjust
            // 
            this.lblVarLinearAdjust.AutoSize = true;
            this.lblVarLinearAdjust.Location = new System.Drawing.Point(21, 143);
            this.lblVarLinearAdjust.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarLinearAdjust.Name = "lblVarLinearAdjust";
            this.lblVarLinearAdjust.Size = new System.Drawing.Size(70, 13);
            this.lblVarLinearAdjust.TabIndex = 23;
            this.lblVarLinearAdjust.Text = "unInterfazVar";
            // 
            // lblVarCommunicationType
            // 
            this.lblVarCommunicationType.AutoSize = true;
            this.lblVarCommunicationType.Location = new System.Drawing.Point(21, 185);
            this.lblVarCommunicationType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarCommunicationType.Name = "lblVarCommunicationType";
            this.lblVarCommunicationType.Size = new System.Drawing.Size(61, 13);
            this.lblVarCommunicationType.TabIndex = 22;
            this.lblVarCommunicationType.Text = "tipoComVar";
            // 
            // lblVarType
            // 
            this.lblVarType.AutoSize = true;
            this.lblVarType.Location = new System.Drawing.Point(335, 25);
            this.lblVarType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarType.Name = "lblVarType";
            this.lblVarType.Size = new System.Drawing.Size(40, 13);
            this.lblVarType.TabIndex = 21;
            this.lblVarType.Text = "tipoVar";
            // 
            // lblVarAccess
            // 
            this.lblVarAccess.AutoSize = true;
            this.lblVarAccess.Location = new System.Drawing.Point(335, 64);
            this.lblVarAccess.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarAccess.Name = "lblVarAccess";
            this.lblVarAccess.Size = new System.Drawing.Size(58, 13);
            this.lblVarAccess.TabIndex = 20;
            this.lblVarAccess.Text = "accesoVar";
            // 
            // lblVarBoardUnits
            // 
            this.lblVarBoardUnits.AutoSize = true;
            this.lblVarBoardUnits.Location = new System.Drawing.Point(21, 105);
            this.lblVarBoardUnits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarBoardUnits.Name = "lblVarBoardUnits";
            this.lblVarBoardUnits.Size = new System.Drawing.Size(62, 13);
            this.lblVarBoardUnits.TabIndex = 19;
            this.lblVarBoardUnits.Text = "unPlacaVar";
            // 
            // lblVarInterfaceUnits
            // 
            this.lblVarInterfaceUnits.AutoSize = true;
            this.lblVarInterfaceUnits.Location = new System.Drawing.Point(335, 105);
            this.lblVarInterfaceUnits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarInterfaceUnits.Name = "lblVarInterfaceUnits";
            this.lblVarInterfaceUnits.Size = new System.Drawing.Size(70, 13);
            this.lblVarInterfaceUnits.TabIndex = 18;
            this.lblVarInterfaceUnits.Text = "unInterfazVar";
            // 
            // lblVarDesc
            // 
            this.lblVarDesc.AutoSize = true;
            this.lblVarDesc.Location = new System.Drawing.Point(21, 64);
            this.lblVarDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarDesc.Name = "lblVarDesc";
            this.lblVarDesc.Size = new System.Drawing.Size(46, 13);
            this.lblVarDesc.TabIndex = 17;
            this.lblVarDesc.Text = "descVar";
            // 
            // lblVarName
            // 
            this.lblVarName.AutoSize = true;
            this.lblVarName.Location = new System.Drawing.Point(21, 25);
            this.lblVarName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVarName.Name = "lblVarName";
            this.lblVarName.Size = new System.Drawing.Size(49, 13);
            this.lblVarName.TabIndex = 16;
            this.lblVarName.Text = "nombVar";
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(559, 196);
            this.btnAddVar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(106, 24);
            this.btnAddVar.TabIndex = 21;
            this.btnAddVar.Text = "Agregar variable";
            this.btnAddVar.UseVisualStyleBackColor = true;
            this.btnAddVar.Click += new System.EventHandler(this.addNewVar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(610, 315);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "button1";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSelectVar
            // 
            this.lblSelectVar.AutoSize = true;
            this.lblSelectVar.Location = new System.Drawing.Point(29, 320);
            this.lblSelectVar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectVar.Name = "lblSelectVar";
            this.lblSelectVar.Size = new System.Drawing.Size(98, 13);
            this.lblSelectVar.TabIndex = 36;
            this.lblSelectVar.Text = "seleccione variable";
            // 
            // cbSelectVar
            // 
            this.cbSelectVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectVar.FormattingEnabled = true;
            this.cbSelectVar.Location = new System.Drawing.Point(135, 317);
            this.cbSelectVar.Margin = new System.Windows.Forms.Padding(2);
            this.cbSelectVar.Name = "cbSelectVar";
            this.cbSelectVar.Size = new System.Drawing.Size(121, 21);
            this.cbSelectVar.TabIndex = 37;
            this.cbSelectVar.SelectedIndexChanged += new System.EventHandler(this.cbSelectVar_SelectedIndexChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 349);
            this.Controls.Add(this.cbSelectVar);
            this.Controls.Add(this.lblSelectVar);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gbNewVar);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.gbProyectDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "MakeConfig";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.gbProyectDetails.ResumeLayout(false);
            this.gbProyectDetails.PerformLayout();
            this.gbNewVar.ResumeLayout(false);
            this.gbNewVar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProyectDetails;
        private System.Windows.Forms.RichTextBox txtProDesc;
        private System.Windows.Forms.RichTextBox txtProName;
        private System.Windows.Forms.Label lblConfigProDesc;
        private System.Windows.Forms.Label lblConfigProName;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.GroupBox gbNewVar;
        private System.Windows.Forms.Button btnAddVar;
        private System.Windows.Forms.Label lblVarRange;
        private System.Windows.Forms.Label lblVarLinearAdjust;
        private System.Windows.Forms.Label lblVarCommunicationType;
        private System.Windows.Forms.Label lblVarType;
        private System.Windows.Forms.Label lblVarAccess;
        private System.Windows.Forms.Label lblVarBoardUnits;
        private System.Windows.Forms.Label lblVarInterfaceUnits;
        private System.Windows.Forms.Label lblVarDesc;
        private System.Windows.Forms.Label lblVarName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox txtVarName;
        private System.Windows.Forms.RichTextBox txtVarDesc;
        private System.Windows.Forms.ComboBox cbVarType;
        private System.Windows.Forms.RichTextBox txtVarRangeHigh;
        private System.Windows.Forms.RichTextBox txtVarRangeLow;
        private System.Windows.Forms.RichTextBox txtVarLinearAdjB;
        private System.Windows.Forms.RichTextBox txtVarLinearAdjA;
        private System.Windows.Forms.RichTextBox txtVarInterfaceUnits;
        private System.Windows.Forms.RichTextBox txtVarBoardUnits;
        private System.Windows.Forms.ComboBox cbVarAccess;
        private System.Windows.Forms.ComboBox cbVarCommunicationType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVectFile;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSelectVar;
        private System.Windows.Forms.ComboBox cbSelectVar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}