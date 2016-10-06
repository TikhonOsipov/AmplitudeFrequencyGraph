namespace AmplitudeFrequencyGraph
{
    partial class Form1
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
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelK = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.labelL0 = new System.Windows.Forms.Label();
            this.textBoxL0 = new System.Windows.Forms.TextBox();
            this.labelL1 = new System.Windows.Forms.Label();
            this.textBoxL1 = new System.Windows.Forms.TextBox();
            this.labelL2 = new System.Windows.Forms.Label();
            this.textBoxL2 = new System.Windows.Forms.TextBox();
            this.labelL3 = new System.Windows.Forms.Label();
            this.textBoxL3 = new System.Windows.Forms.TextBox();
            this.labelT2 = new System.Windows.Forms.Label();
            this.textBoxT2 = new System.Windows.Forms.TextBox();
            this.labelT3 = new System.Windows.Forms.Label();
            this.textBoxT3 = new System.Windows.Forms.TextBox();
            this.labelT1 = new System.Windows.Forms.Label();
            this.textBoxT1 = new System.Windows.Forms.TextBox();
            this.labelWStart = new System.Windows.Forms.Label();
            this.labelWEnd = new System.Windows.Forms.Label();
            this.textBoxWStart = new System.Windows.Forms.TextBox();
            this.textBoxWEnd = new System.Windows.Forms.TextBox();
            this.buttonCompute = new System.Windows.Forms.Button();
            this.labelL4 = new System.Windows.Forms.Label();
            this.textBoxL4 = new System.Windows.Forms.TextBox();
            this.labelKsi4 = new System.Windows.Forms.Label();
            this.textBoxKsi4 = new System.Windows.Forms.TextBox();
            this.labelT4 = new System.Windows.Forms.Label();
            this.textBoxT4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 175);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(980, 367);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Location = new System.Drawing.Point(9, 9);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(14, 13);
            this.labelK.TabIndex = 1;
            this.labelK.Text = "K";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(29, 6);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(100, 20);
            this.textBoxK.TabIndex = 0;
            // 
            // labelL0
            // 
            this.labelL0.AutoSize = true;
            this.labelL0.Location = new System.Drawing.Point(135, 9);
            this.labelL0.Name = "labelL0";
            this.labelL0.Size = new System.Drawing.Size(19, 13);
            this.labelL0.TabIndex = 1;
            this.labelL0.Text = "L0";
            // 
            // textBoxL0
            // 
            this.textBoxL0.Location = new System.Drawing.Point(155, 6);
            this.textBoxL0.Name = "textBoxL0";
            this.textBoxL0.Size = new System.Drawing.Size(100, 20);
            this.textBoxL0.TabIndex = 1;
            // 
            // labelL1
            // 
            this.labelL1.AutoSize = true;
            this.labelL1.Location = new System.Drawing.Point(261, 9);
            this.labelL1.Name = "labelL1";
            this.labelL1.Size = new System.Drawing.Size(19, 13);
            this.labelL1.TabIndex = 1;
            this.labelL1.Text = "L1";
            // 
            // textBoxL1
            // 
            this.textBoxL1.Location = new System.Drawing.Point(281, 6);
            this.textBoxL1.Name = "textBoxL1";
            this.textBoxL1.Size = new System.Drawing.Size(100, 20);
            this.textBoxL1.TabIndex = 2;
            // 
            // labelL2
            // 
            this.labelL2.AutoSize = true;
            this.labelL2.Location = new System.Drawing.Point(9, 35);
            this.labelL2.Name = "labelL2";
            this.labelL2.Size = new System.Drawing.Size(19, 13);
            this.labelL2.TabIndex = 1;
            this.labelL2.Text = "L2";
            // 
            // textBoxL2
            // 
            this.textBoxL2.Location = new System.Drawing.Point(29, 32);
            this.textBoxL2.Name = "textBoxL2";
            this.textBoxL2.Size = new System.Drawing.Size(100, 20);
            this.textBoxL2.TabIndex = 4;
            // 
            // labelL3
            // 
            this.labelL3.AutoSize = true;
            this.labelL3.Location = new System.Drawing.Point(9, 61);
            this.labelL3.Name = "labelL3";
            this.labelL3.Size = new System.Drawing.Size(19, 13);
            this.labelL3.TabIndex = 1;
            this.labelL3.Text = "L3";
            // 
            // textBoxL3
            // 
            this.textBoxL3.Location = new System.Drawing.Point(29, 58);
            this.textBoxL3.Name = "textBoxL3";
            this.textBoxL3.Size = new System.Drawing.Size(100, 20);
            this.textBoxL3.TabIndex = 6;
            // 
            // labelT2
            // 
            this.labelT2.AutoSize = true;
            this.labelT2.Location = new System.Drawing.Point(135, 35);
            this.labelT2.Name = "labelT2";
            this.labelT2.Size = new System.Drawing.Size(20, 13);
            this.labelT2.TabIndex = 1;
            this.labelT2.Text = "T2";
            // 
            // textBoxT2
            // 
            this.textBoxT2.Location = new System.Drawing.Point(155, 32);
            this.textBoxT2.Name = "textBoxT2";
            this.textBoxT2.Size = new System.Drawing.Size(100, 20);
            this.textBoxT2.TabIndex = 5;
            // 
            // labelT3
            // 
            this.labelT3.AutoSize = true;
            this.labelT3.Location = new System.Drawing.Point(135, 61);
            this.labelT3.Name = "labelT3";
            this.labelT3.Size = new System.Drawing.Size(20, 13);
            this.labelT3.TabIndex = 1;
            this.labelT3.Text = "T3";
            // 
            // textBoxT3
            // 
            this.textBoxT3.Location = new System.Drawing.Point(155, 58);
            this.textBoxT3.Name = "textBoxT3";
            this.textBoxT3.Size = new System.Drawing.Size(100, 20);
            this.textBoxT3.TabIndex = 7;
            // 
            // labelT1
            // 
            this.labelT1.AutoSize = true;
            this.labelT1.Location = new System.Drawing.Point(384, 9);
            this.labelT1.Name = "labelT1";
            this.labelT1.Size = new System.Drawing.Size(20, 13);
            this.labelT1.TabIndex = 1;
            this.labelT1.Text = "T1";
            // 
            // textBoxT1
            // 
            this.textBoxT1.Location = new System.Drawing.Point(404, 6);
            this.textBoxT1.Name = "textBoxT1";
            this.textBoxT1.Size = new System.Drawing.Size(100, 20);
            this.textBoxT1.TabIndex = 3;
            // 
            // labelWStart
            // 
            this.labelWStart.AutoSize = true;
            this.labelWStart.Location = new System.Drawing.Point(9, 142);
            this.labelWStart.Name = "labelWStart";
            this.labelWStart.Size = new System.Drawing.Size(24, 13);
            this.labelWStart.TabIndex = 1;
            this.labelWStart.Text = "W1";
            // 
            // labelWEnd
            // 
            this.labelWEnd.AutoSize = true;
            this.labelWEnd.Location = new System.Drawing.Point(135, 142);
            this.labelWEnd.Name = "labelWEnd";
            this.labelWEnd.Size = new System.Drawing.Size(24, 13);
            this.labelWEnd.TabIndex = 1;
            this.labelWEnd.Text = "W2";
            // 
            // textBoxWStart
            // 
            this.textBoxWStart.Location = new System.Drawing.Point(29, 139);
            this.textBoxWStart.Name = "textBoxWStart";
            this.textBoxWStart.Size = new System.Drawing.Size(100, 20);
            this.textBoxWStart.TabIndex = 11;
            // 
            // textBoxWEnd
            // 
            this.textBoxWEnd.Location = new System.Drawing.Point(155, 139);
            this.textBoxWEnd.Name = "textBoxWEnd";
            this.textBoxWEnd.Size = new System.Drawing.Size(100, 20);
            this.textBoxWEnd.TabIndex = 12;
            // 
            // buttonCompute
            // 
            this.buttonCompute.Location = new System.Drawing.Point(865, 548);
            this.buttonCompute.Name = "buttonCompute";
            this.buttonCompute.Size = new System.Drawing.Size(127, 54);
            this.buttonCompute.TabIndex = 14;
            this.buttonCompute.Text = "Рассчитать";
            this.buttonCompute.UseVisualStyleBackColor = true;
            this.buttonCompute.Click += new System.EventHandler(this.buttonCompute_Click);
            // 
            // labelL4
            // 
            this.labelL4.AutoSize = true;
            this.labelL4.Location = new System.Drawing.Point(9, 87);
            this.labelL4.Name = "labelL4";
            this.labelL4.Size = new System.Drawing.Size(19, 13);
            this.labelL4.TabIndex = 1;
            this.labelL4.Text = "L4";
            // 
            // textBoxL4
            // 
            this.textBoxL4.Location = new System.Drawing.Point(29, 84);
            this.textBoxL4.Name = "textBoxL4";
            this.textBoxL4.Size = new System.Drawing.Size(100, 20);
            this.textBoxL4.TabIndex = 8;
            // 
            // labelKsi4
            // 
            this.labelKsi4.AutoSize = true;
            this.labelKsi4.Location = new System.Drawing.Point(371, 87);
            this.labelKsi4.Name = "labelKsi4";
            this.labelKsi4.Size = new System.Drawing.Size(27, 13);
            this.labelKsi4.TabIndex = 1;
            this.labelKsi4.Text = "Ksi4";
            // 
            // textBoxKsi4
            // 
            this.textBoxKsi4.Location = new System.Drawing.Point(404, 84);
            this.textBoxKsi4.Name = "textBoxKsi4";
            this.textBoxKsi4.Size = new System.Drawing.Size(100, 20);
            this.textBoxKsi4.TabIndex = 10;
            // 
            // labelT4
            // 
            this.labelT4.AutoSize = true;
            this.labelT4.Location = new System.Drawing.Point(135, 87);
            this.labelT4.Name = "labelT4";
            this.labelT4.Size = new System.Drawing.Size(20, 13);
            this.labelT4.TabIndex = 1;
            this.labelT4.Text = "T4";
            // 
            // textBoxT4
            // 
            this.textBoxT4.Location = new System.Drawing.Point(155, 84);
            this.textBoxT4.Name = "textBoxT4";
            this.textBoxT4.Size = new System.Drawing.Size(100, 20);
            this.textBoxT4.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 615);
            this.Controls.Add(this.buttonCompute);
            this.Controls.Add(this.textBoxWEnd);
            this.Controls.Add(this.textBoxKsi4);
            this.Controls.Add(this.textBoxT4);
            this.Controls.Add(this.textBoxL4);
            this.Controls.Add(this.textBoxT3);
            this.Controls.Add(this.textBoxWStart);
            this.Controls.Add(this.labelWEnd);
            this.Controls.Add(this.labelKsi4);
            this.Controls.Add(this.labelT4);
            this.Controls.Add(this.textBoxL3);
            this.Controls.Add(this.labelL4);
            this.Controls.Add(this.labelWStart);
            this.Controls.Add(this.labelT3);
            this.Controls.Add(this.labelL3);
            this.Controls.Add(this.textBoxT1);
            this.Controls.Add(this.labelT1);
            this.Controls.Add(this.textBoxT2);
            this.Controls.Add(this.labelT2);
            this.Controls.Add(this.textBoxL2);
            this.Controls.Add(this.labelL2);
            this.Controls.Add(this.textBoxL1);
            this.Controls.Add(this.labelL1);
            this.Controls.Add(this.textBoxL0);
            this.Controls.Add(this.labelL0);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label labelL0;
        private System.Windows.Forms.TextBox textBoxL0;
        private System.Windows.Forms.Label labelL1;
        private System.Windows.Forms.TextBox textBoxL1;
        private System.Windows.Forms.Label labelL2;
        private System.Windows.Forms.TextBox textBoxL2;
        private System.Windows.Forms.Label labelL3;
        private System.Windows.Forms.TextBox textBoxL3;
        private System.Windows.Forms.Label labelT2;
        private System.Windows.Forms.TextBox textBoxT2;
        private System.Windows.Forms.Label labelT3;
        private System.Windows.Forms.TextBox textBoxT3;
        private System.Windows.Forms.Label labelT1;
        private System.Windows.Forms.TextBox textBoxT1;
        private System.Windows.Forms.Label labelWStart;
        private System.Windows.Forms.Label labelWEnd;
        private System.Windows.Forms.TextBox textBoxWStart;
        private System.Windows.Forms.TextBox textBoxWEnd;
        private System.Windows.Forms.Button buttonCompute;
        private System.Windows.Forms.Label labelL4;
        private System.Windows.Forms.TextBox textBoxL4;
        private System.Windows.Forms.Label labelKsi4;
        private System.Windows.Forms.TextBox textBoxKsi4;
        private System.Windows.Forms.Label labelT4;
        private System.Windows.Forms.TextBox textBoxT4;
    }
}

