namespace PlantaPiloto
{
    partial class VarSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VarSelection));
            this.gbVarSelection = new System.Windows.Forms.GroupBox();
            this.dgvVarSelection = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbVarSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVarSelection
            // 
            this.gbVarSelection.Controls.Add(this.dgvVarSelection);
            this.gbVarSelection.Location = new System.Drawing.Point(12, 12);
            this.gbVarSelection.Name = "gbVarSelection";
            this.gbVarSelection.Size = new System.Drawing.Size(264, 387);
            this.gbVarSelection.TabIndex = 0;
            this.gbVarSelection.TabStop = false;
            this.gbVarSelection.Text = "VarSelection";
            // 
            // dgvVarSelection
            // 
            this.dgvVarSelection.AllowUserToAddRows = false;
            this.dgvVarSelection.AllowUserToDeleteRows = false;
            this.dgvVarSelection.AllowUserToOrderColumns = true;
            this.dgvVarSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVarSelection.Location = new System.Drawing.Point(7, 20);
            this.dgvVarSelection.Name = "dgvVarSelection";
            this.dgvVarSelection.Size = new System.Drawing.Size(247, 352);
            this.dgvVarSelection.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(49, 405);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(146, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::PlantaPiloto.Properties.Resources.help;
            this.pictureBox1.Location = new System.Drawing.Point(12, 405);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // VarSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(288, 440);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbVarSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VarSelection";
            this.Text = "VarSelection";
            this.Load += new System.EventHandler(this.VarSelection_Load);
            this.gbVarSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVarSelection;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvVarSelection;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}