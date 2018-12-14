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
            this.gbVarSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVarSelection
            // 
            this.gbVarSelection.Controls.Add(this.dgvVarSelection);
            this.gbVarSelection.Location = new System.Drawing.Point(18, 18);
            this.gbVarSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVarSelection.Name = "gbVarSelection";
            this.gbVarSelection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbVarSelection.Size = new System.Drawing.Size(396, 595);
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
            this.dgvVarSelection.Location = new System.Drawing.Point(10, 31);
            this.dgvVarSelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvVarSelection.Name = "dgvVarSelection";
            this.dgvVarSelection.Size = new System.Drawing.Size(370, 542);
            this.dgvVarSelection.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 623);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(28, 623);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(264, 35);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // VarSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 677);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbVarSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VarSelection";
            this.Text = "VarSelection";
            this.Load += new System.EventHandler(this.VarSelection_Load);
            this.gbVarSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVarSelection;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvVarSelection;
        private System.Windows.Forms.Button btnAccept;
    }
}