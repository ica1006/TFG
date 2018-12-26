namespace PlantaPiloto
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.btnAboutAccept = new System.Windows.Forms.Button();
            this.gbAbout = new System.Windows.Forms.GroupBox();
            this.lblAboutDesc = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblAboutDegree = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAboutUni = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.gbAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAboutAccept
            // 
            this.btnAboutAccept.Location = new System.Drawing.Point(140, 230);
            this.btnAboutAccept.Name = "btnAboutAccept";
            this.btnAboutAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAboutAccept.TabIndex = 0;
            this.btnAboutAccept.Text = "button1";
            this.btnAboutAccept.UseVisualStyleBackColor = true;
            this.btnAboutAccept.Click += new System.EventHandler(this.btnAboutAccept_Click);
            // 
            // gbAbout
            // 
            this.gbAbout.Controls.Add(this.lblAboutDesc);
            this.gbAbout.Controls.Add(this.pictureBox2);
            this.gbAbout.Controls.Add(this.lblAboutDegree);
            this.gbAbout.Controls.Add(this.pictureBox1);
            this.gbAbout.Controls.Add(this.lblAboutUni);
            this.gbAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAbout.Location = new System.Drawing.Point(24, 12);
            this.gbAbout.Name = "gbAbout";
            this.gbAbout.Size = new System.Drawing.Size(311, 208);
            this.gbAbout.TabIndex = 26;
            this.gbAbout.TabStop = false;
            this.gbAbout.Text = "groupBox1";
            // 
            // lblAboutDesc
            // 
            this.lblAboutDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutDesc.Location = new System.Drawing.Point(5, 40);
            this.lblAboutDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAboutDesc.MaximumSize = new System.Drawing.Size(363, 141);
            this.lblAboutDesc.Name = "lblAboutDesc";
            this.lblAboutDesc.Size = new System.Drawing.Size(303, 30);
            this.lblAboutDesc.TabIndex = 21;
            this.lblAboutDesc.Text = "Proyecto de Fin de Grado realizado por Francisco Crespo Diez.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(171, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // lblAboutDegree
            // 
            this.lblAboutDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutDegree.Location = new System.Drawing.Point(5, 70);
            this.lblAboutDegree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAboutDegree.MaximumSize = new System.Drawing.Size(363, 141);
            this.lblAboutDegree.Name = "lblAboutDegree";
            this.lblAboutDegree.Size = new System.Drawing.Size(231, 18);
            this.lblAboutDegree.TabIndex = 22;
            this.lblAboutDegree.Text = "Grado en Ingeniería Informática";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(87, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // lblAboutUni
            // 
            this.lblAboutUni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutUni.Location = new System.Drawing.Point(5, 101);
            this.lblAboutUni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAboutUni.MaximumSize = new System.Drawing.Size(363, 141);
            this.lblAboutUni.Name = "lblAboutUni";
            this.lblAboutUni.Size = new System.Drawing.Size(231, 18);
            this.lblAboutUni.TabIndex = 23;
            this.lblAboutUni.Text = "Universidad de Burgos";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::PlantaPiloto.Properties.Resources.help;
            this.pictureBox3.Location = new System.Drawing.Point(304, 231);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 266);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.gbAbout);
            this.Controls.Add(this.btnAboutAccept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.gbAbout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAboutAccept;
        private System.Windows.Forms.GroupBox gbAbout;
        private System.Windows.Forms.Label lblAboutDesc;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblAboutDegree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAboutUni;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}