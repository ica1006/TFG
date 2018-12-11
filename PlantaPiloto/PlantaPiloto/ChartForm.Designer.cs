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
            this.chartVar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnClose = new System.Windows.Forms.Button();
            this.tFG_DBDataSet = new PlantaPiloto.TFG_DBDataSet();
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
            this.chartVar.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
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
            // 
            // tFG_DBDataSet
            // 
            this.tFG_DBDataSet.DataSetName = "TFG_DBDataSet";
            this.tFG_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chartVar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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