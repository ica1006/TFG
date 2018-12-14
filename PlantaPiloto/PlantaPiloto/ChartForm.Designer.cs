namespace PlantaPiloto
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.chartVar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClose = new System.Windows.Forms.Button();
            this.tFG_DBDataSet = new PlantaPiloto.TFG_DBDataSet();
            this.lblChartAmount = new System.Windows.Forms.Label();
            this.txtChartAmount = new System.Windows.Forms.RichTextBox();
            this.btnChartAmount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFG_DBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // chartVar
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVar.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVar.Legends.Add(legend1);
            this.chartVar.Location = new System.Drawing.Point(18, 18);
            this.chartVar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartVar.Name = "chartVar";
            this.chartVar.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVar.Series.Add(series1);
            this.chartVar.Size = new System.Drawing.Size(1164, 611);
            this.chartVar.TabIndex = 0;
            this.chartVar.Text = "chart1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1068, 638);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "button1";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tFG_DBDataSet
            // 
            this.tFG_DBDataSet.DataSetName = "TFG_DBDataSet";
            this.tFG_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblChartAmount
            // 
            this.lblChartAmount.AutoSize = true;
            this.lblChartAmount.Location = new System.Drawing.Point(18, 638);
            this.lblChartAmount.Name = "lblChartAmount";
            this.lblChartAmount.Size = new System.Drawing.Size(113, 20);
            this.lblChartAmount.TabIndex = 2;
            this.lblChartAmount.Text = "cantidadDatos";
            // 
            // txtChartAmount
            // 
            this.txtChartAmount.Location = new System.Drawing.Point(286, 636);
            this.txtChartAmount.Multiline = false;
            this.txtChartAmount.Name = "txtChartAmount";
            this.txtChartAmount.Size = new System.Drawing.Size(124, 31);
            this.txtChartAmount.TabIndex = 3;
            this.txtChartAmount.Text = "";
            this.txtChartAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChartAmount_KeyPress);
            this.txtChartAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtChartAmount_Validating);
            // 
            // btnChartAmount
            // 
            this.btnChartAmount.Location = new System.Drawing.Point(426, 636);
            this.btnChartAmount.Name = "btnChartAmount";
            this.btnChartAmount.Size = new System.Drawing.Size(78, 38);
            this.btnChartAmount.TabIndex = 4;
            this.btnChartAmount.Text = "button1";
            this.btnChartAmount.UseVisualStyleBackColor = true;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnChartAmount);
            this.Controls.Add(this.txtChartAmount);
            this.Controls.Add(this.lblChartAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chartVar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChartForm";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFG_DBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVar;
        private System.Windows.Forms.Button btnClose;
        private TFG_DBDataSet tFG_DBDataSet;
        private System.Windows.Forms.Label lblChartAmount;
        private System.Windows.Forms.RichTextBox txtChartAmount;
        private System.Windows.Forms.Button btnChartAmount;
    }
}