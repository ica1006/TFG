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
            this.gbProyectDetails.Location = new System.Drawing.Point(12, 12);
            this.gbProyectDetails.Name = "gbProyectDetails";
            this.gbProyectDetails.Size = new System.Drawing.Size(1016, 88);
            this.gbProyectDetails.TabIndex = 6;
            this.gbProyectDetails.TabStop = false;
            this.gbProyectDetails.Text = "DatosProyecto";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(838, 38);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(159, 37);
            this.btnLoadImage.TabIndex = 22;
            this.btnLoadImage.Text = "Cargar imagen";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // lblVectFile
            // 
            this.lblVectFile.AutoSize = true;
            this.lblVectFile.Location = new System.Drawing.Point(706, 52);
            this.lblVectFile.Name = "lblVectFile";
            this.lblVectFile.Size = new System.Drawing.Size(61, 20);
            this.lblVectFile.TabIndex = 10;
            this.lblVectFile.Text = "imagen";
            // 
            // txtProDesc
            // 
            this.txtProDesc.Location = new System.Drawing.Point(489, 45);
            this.txtProDesc.Multiline = false;
            this.txtProDesc.Name = "txtProDesc";
            this.txtProDesc.Size = new System.Drawing.Size(180, 29);
            this.txtProDesc.TabIndex = 9;
            this.txtProDesc.Text = "";
            // 
            // txtProName
            // 
            this.txtProName.Location = new System.Drawing.Point(190, 45);
            this.txtProName.Multiline = false;
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(180, 29);
            this.txtProName.TabIndex = 8;
            this.txtProName.Text = "";
            // 
            // lblConfigProDesc
            // 
            this.lblConfigProDesc.AutoSize = true;
            this.lblConfigProDesc.Location = new System.Drawing.Point(392, 52);
            this.lblConfigProDesc.Name = "lblConfigProDesc";
            this.lblConfigProDesc.Size = new System.Drawing.Size(43, 20);
            this.lblConfigProDesc.TabIndex = 7;
            this.lblConfigProDesc.Text = "desc";
            // 
            // lblConfigProName
            // 
            this.lblConfigProName.AutoSize = true;
            this.lblConfigProName.Location = new System.Drawing.Point(32, 52);
            this.lblConfigProName.Name = "lblConfigProName";
            this.lblConfigProName.Size = new System.Drawing.Size(49, 20);
            this.lblConfigProName.TabIndex = 6;
            this.lblConfigProName.Text = "nomb";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(783, 485);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(124, 35);
            this.btnSaveConfig.TabIndex = 22;
            this.btnSaveConfig.Text = "Guardar configuración";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.saveConfigFile_Click);
            // 
            // gbNewVar
            // 
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
            this.gbNewVar.Location = new System.Drawing.Point(12, 106);
            this.gbNewVar.Name = "gbNewVar";
            this.gbNewVar.Size = new System.Drawing.Size(1016, 363);
            this.gbNewVar.TabIndex = 16;
            this.gbNewVar.TabStop = false;
            this.gbNewVar.Text = "newVar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(766, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "-";
            // 
            // cbVarCommunicationType
            // 
            this.cbVarCommunicationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarCommunicationType.FormattingEnabled = true;
            this.cbVarCommunicationType.Location = new System.Drawing.Point(261, 275);
            this.cbVarCommunicationType.Name = "cbVarCommunicationType";
            this.cbVarCommunicationType.Size = new System.Drawing.Size(180, 28);
            this.cbVarCommunicationType.TabIndex = 20;
            // 
            // txtVarRangeHigh
            // 
            this.txtVarRangeHigh.Location = new System.Drawing.Point(798, 212);
            this.txtVarRangeHigh.Multiline = false;
            this.txtVarRangeHigh.Name = "txtVarRangeHigh";
            this.txtVarRangeHigh.Size = new System.Drawing.Size(66, 29);
            this.txtVarRangeHigh.TabIndex = 19;
            this.txtVarRangeHigh.Text = "";
            this.txtVarRangeHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarRangeHigh_KeyPress);
            // 
            // txtVarRangeLow
            // 
            this.txtVarRangeLow.Location = new System.Drawing.Point(684, 212);
            this.txtVarRangeLow.Multiline = false;
            this.txtVarRangeLow.Name = "txtVarRangeLow";
            this.txtVarRangeLow.Size = new System.Drawing.Size(66, 29);
            this.txtVarRangeLow.TabIndex = 18;
            this.txtVarRangeLow.Text = "";
            this.txtVarRangeLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarRangeLow_KeyPress);
            // 
            // txtVarLinearAdjB
            // 
            this.txtVarLinearAdjB.Location = new System.Drawing.Point(375, 212);
            this.txtVarLinearAdjB.Multiline = false;
            this.txtVarLinearAdjB.Name = "txtVarLinearAdjB";
            this.txtVarLinearAdjB.Size = new System.Drawing.Size(66, 29);
            this.txtVarLinearAdjB.TabIndex = 17;
            this.txtVarLinearAdjB.Text = "0";
            this.txtVarLinearAdjB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarLinearAdjB_KeyPress);
            // 
            // txtVarLinearAdjA
            // 
            this.txtVarLinearAdjA.Location = new System.Drawing.Point(261, 212);
            this.txtVarLinearAdjA.Multiline = false;
            this.txtVarLinearAdjA.Name = "txtVarLinearAdjA";
            this.txtVarLinearAdjA.Size = new System.Drawing.Size(66, 29);
            this.txtVarLinearAdjA.TabIndex = 16;
            this.txtVarLinearAdjA.Text = "1";
            this.txtVarLinearAdjA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVarLinearAdjA_KeyPress);
            // 
            // txtVarInterfaceUnits
            // 
            this.txtVarInterfaceUnits.Location = new System.Drawing.Point(684, 154);
            this.txtVarInterfaceUnits.Multiline = false;
            this.txtVarInterfaceUnits.Name = "txtVarInterfaceUnits";
            this.txtVarInterfaceUnits.Size = new System.Drawing.Size(180, 29);
            this.txtVarInterfaceUnits.TabIndex = 15;
            this.txtVarInterfaceUnits.Text = "";
            // 
            // txtVarBoardUnits
            // 
            this.txtVarBoardUnits.Location = new System.Drawing.Point(261, 154);
            this.txtVarBoardUnits.Multiline = false;
            this.txtVarBoardUnits.Name = "txtVarBoardUnits";
            this.txtVarBoardUnits.Size = new System.Drawing.Size(180, 29);
            this.txtVarBoardUnits.TabIndex = 14;
            this.txtVarBoardUnits.Text = "";
            // 
            // cbVarAccess
            // 
            this.cbVarAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarAccess.FormattingEnabled = true;
            this.cbVarAccess.Location = new System.Drawing.Point(684, 91);
            this.cbVarAccess.Name = "cbVarAccess";
            this.cbVarAccess.Size = new System.Drawing.Size(180, 28);
            this.cbVarAccess.TabIndex = 13;
            // 
            // cbVarType
            // 
            this.cbVarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVarType.FormattingEnabled = true;
            this.cbVarType.Location = new System.Drawing.Point(682, 34);
            this.cbVarType.Name = "cbVarType";
            this.cbVarType.Size = new System.Drawing.Size(180, 28);
            this.cbVarType.TabIndex = 11;
            this.cbVarType.SelectedValueChanged += new System.EventHandler(this.cbVarType_SelectedValueChanged);
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(261, 29);
            this.txtVarName.Multiline = false;
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(180, 29);
            this.txtVarName.TabIndex = 10;
            this.txtVarName.Text = "";
            // 
            // txtVarDesc
            // 
            this.txtVarDesc.Location = new System.Drawing.Point(261, 91);
            this.txtVarDesc.Multiline = false;
            this.txtVarDesc.Name = "txtVarDesc";
            this.txtVarDesc.Size = new System.Drawing.Size(180, 29);
            this.txtVarDesc.TabIndex = 12;
            this.txtVarDesc.Text = "";
            // 
            // lblVarRange
            // 
            this.lblVarRange.AutoSize = true;
            this.lblVarRange.Location = new System.Drawing.Point(502, 220);
            this.lblVarRange.Name = "lblVarRange";
            this.lblVarRange.Size = new System.Drawing.Size(75, 20);
            this.lblVarRange.TabIndex = 24;
            this.lblVarRange.Text = "rangoVar";
            // 
            // lblVarLinearAdjust
            // 
            this.lblVarLinearAdjust.AutoSize = true;
            this.lblVarLinearAdjust.Location = new System.Drawing.Point(32, 220);
            this.lblVarLinearAdjust.Name = "lblVarLinearAdjust";
            this.lblVarLinearAdjust.Size = new System.Drawing.Size(107, 20);
            this.lblVarLinearAdjust.TabIndex = 23;
            this.lblVarLinearAdjust.Text = "unInterfazVar";
            // 
            // lblVarCommunicationType
            // 
            this.lblVarCommunicationType.AutoSize = true;
            this.lblVarCommunicationType.Location = new System.Drawing.Point(32, 285);
            this.lblVarCommunicationType.Name = "lblVarCommunicationType";
            this.lblVarCommunicationType.Size = new System.Drawing.Size(93, 20);
            this.lblVarCommunicationType.TabIndex = 22;
            this.lblVarCommunicationType.Text = "tipoComVar";
            // 
            // lblVarType
            // 
            this.lblVarType.AutoSize = true;
            this.lblVarType.Location = new System.Drawing.Point(502, 38);
            this.lblVarType.Name = "lblVarType";
            this.lblVarType.Size = new System.Drawing.Size(60, 20);
            this.lblVarType.TabIndex = 21;
            this.lblVarType.Text = "tipoVar";
            // 
            // lblVarAccess
            // 
            this.lblVarAccess.AutoSize = true;
            this.lblVarAccess.Location = new System.Drawing.Point(502, 98);
            this.lblVarAccess.Name = "lblVarAccess";
            this.lblVarAccess.Size = new System.Drawing.Size(85, 20);
            this.lblVarAccess.TabIndex = 20;
            this.lblVarAccess.Text = "accesoVar";
            // 
            // lblVarBoardUnits
            // 
            this.lblVarBoardUnits.AutoSize = true;
            this.lblVarBoardUnits.Location = new System.Drawing.Point(32, 162);
            this.lblVarBoardUnits.Name = "lblVarBoardUnits";
            this.lblVarBoardUnits.Size = new System.Drawing.Size(91, 20);
            this.lblVarBoardUnits.TabIndex = 19;
            this.lblVarBoardUnits.Text = "unPlacaVar";
            // 
            // lblVarInterfaceUnits
            // 
            this.lblVarInterfaceUnits.AutoSize = true;
            this.lblVarInterfaceUnits.Location = new System.Drawing.Point(502, 162);
            this.lblVarInterfaceUnits.Name = "lblVarInterfaceUnits";
            this.lblVarInterfaceUnits.Size = new System.Drawing.Size(107, 20);
            this.lblVarInterfaceUnits.TabIndex = 18;
            this.lblVarInterfaceUnits.Text = "unInterfazVar";
            // 
            // lblVarDesc
            // 
            this.lblVarDesc.AutoSize = true;
            this.lblVarDesc.Location = new System.Drawing.Point(32, 98);
            this.lblVarDesc.Name = "lblVarDesc";
            this.lblVarDesc.Size = new System.Drawing.Size(68, 20);
            this.lblVarDesc.TabIndex = 17;
            this.lblVarDesc.Text = "descVar";
            // 
            // lblVarName
            // 
            this.lblVarName.AutoSize = true;
            this.lblVarName.Location = new System.Drawing.Point(32, 38);
            this.lblVarName.Name = "lblVarName";
            this.lblVarName.Size = new System.Drawing.Size(74, 20);
            this.lblVarName.TabIndex = 16;
            this.lblVarName.Text = "nombVar";
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(838, 302);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(159, 37);
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
            this.btnExit.Location = new System.Drawing.Point(915, 485);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 35);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "button1";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSelectVar
            // 
            this.lblSelectVar.AutoSize = true;
            this.lblSelectVar.Location = new System.Drawing.Point(44, 492);
            this.lblSelectVar.Name = "lblSelectVar";
            this.lblSelectVar.Size = new System.Drawing.Size(142, 20);
            this.lblSelectVar.TabIndex = 36;
            this.lblSelectVar.Text = "seleccione variable";
            // 
            // cbSelectVar
            // 
            this.cbSelectVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectVar.FormattingEnabled = true;
            this.cbSelectVar.Location = new System.Drawing.Point(202, 488);
            this.cbSelectVar.Name = "cbSelectVar";
            this.cbSelectVar.Size = new System.Drawing.Size(180, 28);
            this.cbSelectVar.TabIndex = 37;
            this.cbSelectVar.SelectedIndexChanged += new System.EventHandler(this.cbSelectVar_SelectedIndexChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 537);
            this.Controls.Add(this.cbSelectVar);
            this.Controls.Add(this.lblSelectVar);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gbNewVar);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.gbProyectDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "MakeConfig";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.gbProyectDetails.ResumeLayout(false);
            this.gbProyectDetails.PerformLayout();
            this.gbNewVar.ResumeLayout(false);
            this.gbNewVar.PerformLayout();
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
    }
}