
namespace PlantaPiloto.Forms
{
    partial class WebAppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebAppForm));
            this.txtIISlocation = new System.Windows.Forms.RichTextBox();
            this.lblIISlocation = new System.Windows.Forms.Label();
            this.gbIISExpress = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.RichTextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.RichTextBox();
            this.gbWebApp = new System.Windows.Forms.GroupBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.lblProjectPath = new System.Windows.Forms.Label();
            this.lblWebAppPath = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.RichTextBox();
            this.txtProjectPath = new System.Windows.Forms.RichTextBox();
            this.txtWebAppPath = new System.Windows.Forms.RichTextBox();
            this.btnLaunchWebApp = new System.Windows.Forms.Button();
            this.gbIISExpress.SuspendLayout();
            this.gbWebApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIISlocation
            // 
            this.txtIISlocation.Location = new System.Drawing.Point(222, 26);
            this.txtIISlocation.Name = "txtIISlocation";
            this.txtIISlocation.Size = new System.Drawing.Size(788, 20);
            this.txtIISlocation.TabIndex = 0;
            this.txtIISlocation.Text = "";
            this.txtIISlocation.TextChanged += new System.EventHandler(this.checkIfItCanLaunch);
            // 
            // lblIISlocation
            // 
            this.lblIISlocation.AutoSize = true;
            this.lblIISlocation.Location = new System.Drawing.Point(19, 26);
            this.lblIISlocation.Name = "lblIISlocation";
            this.lblIISlocation.Size = new System.Drawing.Size(35, 13);
            this.lblIISlocation.TabIndex = 1;
            this.lblIISlocation.Text = "label1";
            // 
            // gbIISExpress
            // 
            this.gbIISExpress.Controls.Add(this.lblPort);
            this.gbIISExpress.Controls.Add(this.txtPort);
            this.gbIISExpress.Controls.Add(this.lblIP);
            this.gbIISExpress.Controls.Add(this.txtIP);
            this.gbIISExpress.Controls.Add(this.lblIISlocation);
            this.gbIISExpress.Controls.Add(this.txtIISlocation);
            this.gbIISExpress.Location = new System.Drawing.Point(12, 12);
            this.gbIISExpress.Name = "gbIISExpress";
            this.gbIISExpress.Size = new System.Drawing.Size(1016, 106);
            this.gbIISExpress.TabIndex = 2;
            this.gbIISExpress.TabStop = false;
            this.gbIISExpress.Text = "IIS Express";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(313, 70);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "label1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(357, 67);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(147, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(18, 70);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(35, 13);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "label1";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(85, 67);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(147, 20);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "";
            this.txtIP.TextChanged += new System.EventHandler(this.checkIfItCanLaunch);
            // 
            // gbWebApp
            // 
            this.gbWebApp.Controls.Add(this.lblConnectionString);
            this.gbWebApp.Controls.Add(this.lblProjectPath);
            this.gbWebApp.Controls.Add(this.lblWebAppPath);
            this.gbWebApp.Controls.Add(this.txtConnectionString);
            this.gbWebApp.Controls.Add(this.txtProjectPath);
            this.gbWebApp.Controls.Add(this.txtWebAppPath);
            this.gbWebApp.Location = new System.Drawing.Point(12, 124);
            this.gbWebApp.Name = "gbWebApp";
            this.gbWebApp.Size = new System.Drawing.Size(1016, 135);
            this.gbWebApp.TabIndex = 3;
            this.gbWebApp.TabStop = false;
            this.gbWebApp.Text = "groupBox1";
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(19, 105);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(35, 13);
            this.lblConnectionString.TabIndex = 10;
            this.lblConnectionString.Text = "label1";
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.AutoSize = true;
            this.lblProjectPath.Location = new System.Drawing.Point(19, 62);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(35, 13);
            this.lblProjectPath.TabIndex = 9;
            this.lblProjectPath.Text = "label1";
            // 
            // lblWebAppPath
            // 
            this.lblWebAppPath.AutoSize = true;
            this.lblWebAppPath.Location = new System.Drawing.Point(19, 26);
            this.lblWebAppPath.Name = "lblWebAppPath";
            this.lblWebAppPath.Size = new System.Drawing.Size(35, 13);
            this.lblWebAppPath.TabIndex = 6;
            this.lblWebAppPath.Text = "label1";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(222, 98);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(788, 20);
            this.txtConnectionString.TabIndex = 8;
            this.txtConnectionString.Text = "";
            this.txtConnectionString.TextChanged += new System.EventHandler(this.checkIfItCanLaunch);
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Location = new System.Drawing.Point(222, 59);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(788, 20);
            this.txtProjectPath.TabIndex = 7;
            this.txtProjectPath.Text = "";
            this.txtProjectPath.TextChanged += new System.EventHandler(this.checkIfItCanLaunch);
            // 
            // txtWebAppPath
            // 
            this.txtWebAppPath.Location = new System.Drawing.Point(222, 19);
            this.txtWebAppPath.Name = "txtWebAppPath";
            this.txtWebAppPath.Size = new System.Drawing.Size(788, 20);
            this.txtWebAppPath.TabIndex = 6;
            this.txtWebAppPath.Text = "";
            this.txtWebAppPath.TextChanged += new System.EventHandler(this.checkIfItCanLaunch);
            // 
            // btnLaunchWebApp
            // 
            this.btnLaunchWebApp.Location = new System.Drawing.Point(947, 281);
            this.btnLaunchWebApp.Name = "btnLaunchWebApp";
            this.btnLaunchWebApp.Size = new System.Drawing.Size(75, 23);
            this.btnLaunchWebApp.TabIndex = 4;
            this.btnLaunchWebApp.Text = "button1";
            this.btnLaunchWebApp.UseVisualStyleBackColor = true;
            this.btnLaunchWebApp.Click += new System.EventHandler(this.btnLaunchWebApp_Click);
            // 
            // WebAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 322);
            this.Controls.Add(this.btnLaunchWebApp);
            this.Controls.Add(this.gbWebApp);
            this.Controls.Add(this.gbIISExpress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WebAppForm";
            this.Text = "WebApp";
            this.Load += new System.EventHandler(this.checkIfItCanLaunch);
            this.gbIISExpress.ResumeLayout(false);
            this.gbIISExpress.PerformLayout();
            this.gbWebApp.ResumeLayout(false);
            this.gbWebApp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtIISlocation;
        private System.Windows.Forms.Label lblIISlocation;
        private System.Windows.Forms.GroupBox gbIISExpress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.RichTextBox txtPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.RichTextBox txtIP;
        private System.Windows.Forms.GroupBox gbWebApp;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblProjectPath;
        private System.Windows.Forms.Label lblWebAppPath;
        private System.Windows.Forms.RichTextBox txtConnectionString;
        private System.Windows.Forms.RichTextBox txtProjectPath;
        private System.Windows.Forms.RichTextBox txtWebAppPath;
        private System.Windows.Forms.Button btnLaunchWebApp;
    }
}