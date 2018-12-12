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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            this.chartVar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClose = new System.Windows.Forms.Button();
            this.tFG_DBDataSet = new PlantaPiloto.TFG_DBDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.chartVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFG_DBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // chartVar
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVar.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVar.Legends.Add(legend2);
            this.chartVar.Location = new System.Drawing.Point(12, 12);
            this.chartVar.Name = "chartVar";
            this.chartVar.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVar.Series.Add(series2);
            this.chartVar.Size = new System.Drawing.Size(776, 397);
            this.chartVar.TabIndex = 0;
            this.chartVar.Text = "chart1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(712, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
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
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chartVar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartForm";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tFG_DBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVar;
        private System.Windows.Forms.Button btnClose;
        private TFG_DBDataSet tFG_DBDataSet;
    }
}