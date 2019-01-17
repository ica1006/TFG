namespace PlantaPiloto.Forms
{
    partial class VarValuesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VarValuesForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbVarValues = new System.Windows.Forms.GroupBox();
            this.dgvVarValues = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbVarValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarValues)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::PlantaPiloto.Properties.Resources.help;
            this.pictureBox1.Location = new System.Drawing.Point(13, 619);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 619);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbVarValues
            // 
            this.gbVarValues.Controls.Add(this.dgvVarValues);
            this.gbVarValues.Location = new System.Drawing.Point(13, 14);
            this.gbVarValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVarValues.Name = "gbVarValues";
            this.gbVarValues.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVarValues.Size = new System.Drawing.Size(396, 595);
            this.gbVarValues.TabIndex = 39;
            this.gbVarValues.TabStop = false;
            this.gbVarValues.Text = "VarSelection";
            // 
            // dgvVarValues
            // 
            this.dgvVarValues.AllowUserToAddRows = false;
            this.dgvVarValues.AllowUserToDeleteRows = false;
            this.dgvVarValues.AllowUserToOrderColumns = true;
            this.dgvVarValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVarValues.Location = new System.Drawing.Point(10, 31);
            this.dgvVarValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvVarValues.Name = "dgvVarValues";
            this.dgvVarValues.Size = new System.Drawing.Size(370, 542);
            this.dgvVarValues.TabIndex = 0;
            // 
            // VarValuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(418, 665);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbVarValues);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VarValuesForm";
            this.Text = "VarValuesForm";
            this.Load += new System.EventHandler(this.VarValuesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbVarValues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbVarValues;
        private System.Windows.Forms.DataGridView dgvVarValues;
    }
}