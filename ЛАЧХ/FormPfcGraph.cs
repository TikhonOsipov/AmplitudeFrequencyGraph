using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ЛАЧХ
{
    public partial class FormPfcGraph : Form
    {
        public FormPfcGraph()
        {
            InitializeComponent();
            this.chart.Series[0].LegendText = "Θ(ω)";
        }

        public void setData(List<double> omegas, List<double> pfcs)
        {
            this.chart.Series[0].Points.DataBindXY(omegas, pfcs);
            formatChartArea(this.chart.ChartAreas[0], omegas[0], omegas[omegas.Count - 1]);
        }

        //подготовка графика к работе
        private void formatChartArea(ChartArea chartArea, double min, double max)
        {
            Axis xAxis = chartArea.AxisX;
            Axis yAxis = chartArea.AxisY;

            xAxis.IsLogarithmic = true;
            xAxis.LogarithmBase = 10;

            xAxis.LabelStyle.Enabled = true;
            xAxis.MinorGrid.Enabled = true;
            xAxis.MinorGrid.LineColor = Color.Gainsboro;
            xAxis.MinorGrid.Interval = 1;

            xAxis.MajorGrid.Enabled = true;
            xAxis.MajorGrid.LineColor = Color.Gainsboro;
            xAxis.MajorGrid.LineColor = Color.Gainsboro;

            xAxis.LabelStyle.Format = "#0.#####";
            xAxis.Title = "ω, рад/с";
            yAxis.Title = "Θ(ω), град";
            yAxis.Interval = 20;
            yAxis.MajorGrid.LineColor = Color.Gainsboro;

            xAxis.Minimum = min;
            xAxis.Maximum = max;
        }
    }
}
