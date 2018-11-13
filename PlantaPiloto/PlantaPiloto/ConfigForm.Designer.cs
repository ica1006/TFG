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
            this.lblConfigTitle = new System.Windows.Forms.GroupBox();
            this.txtProDesc = new System.Windows.Forms.RichTextBox();
            this.txtProName = new System.Windows.Forms.RichTextBox();
            this.lblConfigProDesc = new System.Windows.Forms.Label();
            this.lblConfigProName = new System.Windows.Forms.Label();
            this.lblConfigTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConfigTitle
            // 
            this.lblConfigTitle.Controls.Add(this.txtProDesc);
            this.lblConfigTitle.Controls.Add(this.txtProName);
            this.lblConfigTitle.Controls.Add(this.lblConfigProDesc);
            this.lblConfigTitle.Controls.Add(this.lblConfigProName);
            this.lblConfigTitle.Location = new System.Drawing.Point(12, 12);
            this.lblConfigTitle.Name = "lblConfigTitle";
            this.lblConfigTitle.Size = new System.Drawing.Size(441, 412);
            this.lblConfigTitle.TabIndex = 6;
            this.lblConfigTitle.TabStop = false;
            this.lblConfigTitle.Text = "groupBox1";
            // 
            // txtProDesc
            // 
            this.txtProDesc.Location = new System.Drawing.Point(176, 87);
            this.txtProDesc.Name = "txtProDesc";
            this.txtProDesc.Size = new System.Drawing.Size(180, 84);
            this.txtProDesc.TabIndex = 9;
            this.txtProDesc.Text = "";
            // 
            // txtProName
            // 
            this.txtProName.Location = new System.Drawing.Point(176, 44);
            this.txtProName.Multiline = false;
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(180, 28);
            this.txtProName.TabIndex = 8;
            this.txtProName.Text = "";
            // 
            // lblConfigProDesc
            // 
            this.lblConfigProDesc.AutoSize = true;
            this.lblConfigProDesc.Location = new System.Drawing.Point(6, 87);
            this.lblConfigProDesc.Name = "lblConfigProDesc";
            this.lblConfigProDesc.Size = new System.Drawing.Size(51, 20);
            this.lblConfigProDesc.TabIndex = 7;
            this.lblConfigProDesc.Text = "label1";
            // 
            // lblConfigProName
            // 
            this.lblConfigProName.AutoSize = true;
            this.lblConfigProName.Location = new System.Drawing.Point(6, 44);
            this.lblConfigProName.Name = "lblConfigProName";
            this.lblConfigProName.Size = new System.Drawing.Size(51, 20);
            this.lblConfigProName.TabIndex = 6;
            this.lblConfigProName.Text = "label1";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 450);
            this.Controls.Add(this.lblConfigTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "MakeConfig";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.lblConfigTitle.ResumeLayout(false);
            this.lblConfigTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox lblConfigTitle;
        private System.Windows.Forms.RichTextBox txtProDesc;
        private System.Windows.Forms.RichTextBox txtProName;
        private System.Windows.Forms.Label lblConfigProDesc;
        private System.Windows.Forms.Label lblConfigProName;
    }
}