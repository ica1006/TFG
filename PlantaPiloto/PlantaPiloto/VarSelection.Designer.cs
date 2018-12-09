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
            this.Variables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.gbVarSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVarSelection)).BeginInit();
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
            this.dgvVarSelection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variables,
            this.CheckColumn});
            this.dgvVarSelection.Location = new System.Drawing.Point(7, 20);
            this.dgvVarSelection.Name = "dgvVarSelection";
            this.dgvVarSelection.Size = new System.Drawing.Size(247, 352);
            this.dgvVarSelection.TabIndex = 0;
            // 
            // Variables
            // 
            this.Variables.HeaderText = "Variables";
            this.Variables.Name = "Variables";
            this.Variables.ReadOnly = true;
            // 
            // CheckColumn
            // 
            this.CheckColumn.HeaderText = "";
            this.CheckColumn.Name = "CheckColumn";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(19, 405);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(176, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // VarSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 440);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbVarSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Variables;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckColumn;
        private System.Windows.Forms.Button btnAccept;
    }
}