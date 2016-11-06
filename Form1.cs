using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace AmplitudeFrequencyGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.labelWStart.Text = "ω1"; //ξω
            this.labelWEnd.Text = "ω2";
            this.labelKsi4.Text = "ξ4";
            this.chart.Series[0].LegendText = "L(ω)";

            this.labelL0range.Text = "0; ±1; ±2";
            this.labelL1range.Text = "0; ±1";
            this.labelL2range.Text = "0; ±1";
            this.labelL3range.Text = "0; ±1";
            this.labelL4range.Text = "0; ±1";

            this.labelT1range.Text = "0,01...100";
            this.labelT2range.Text = "0,01...100";
            this.labelT3range.Text = "0,01...100";
            this.labelT4range.Text = "0,01...100";

            this.labelXIrange.Text = "0...1";
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            if(textBoxWStart.Text == "" || textBoxWEnd.Text ==  "" || textBoxK.Text == "" || 
                textBoxL0.Text == "" || textBoxL1.Text == "" || textBoxL2.Text == "" || 
                textBoxL3.Text == "" || textBoxL4.Text == "" || textBoxT1.Text == "" || 
                textBoxT2.Text == "" || textBoxT3.Text == "" || textBoxT4.Text == "" || 
                textBoxKsi4.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            double omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
            double omegaEnd = double.Parse(textBoxWEnd.Text.Replace(".", ","));
            double K = double.Parse(textBoxK.Text.Replace(".", ","));
            int l0 = int.Parse(textBoxL0.Text.Replace(".", ","));
            int l1 = int.Parse(textBoxL1.Text.Replace(".", ","));
            int l2 = int.Parse(textBoxL2.Text.Replace(".", ","));
            int l3 = int.Parse(textBoxL3.Text.Replace(".", ","));
            int l4 = int.Parse(textBoxL4.Text.Replace(".", ","));
            double T1 = double.Parse(textBoxT1.Text.Replace(".", ","));
            double T2 = double.Parse(textBoxT2.Text.Replace(".", ","));
            double T3 = double.Parse(textBoxT3.Text.Replace(".", ","));
            double T4 = double.Parse(textBoxT4.Text.Replace(".", ","));
            double ksi4 = double.Parse(textBoxKsi4.Text.Replace(".", ","));

            this.chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            this.chart.ChartAreas[0].AxisX.Minimum = omegaStart;
            this.chart.ChartAreas[0].AxisX.Maximum = omegaEnd;

            List<double> omegas = new List<double>();
            List<double> afcs = new List<double>();

            double step = 0.01;

            omegas.Add(omegaStart);

            while (omegas[omegas.Count - 1] < omegaEnd)
            {
                omegas.Add(omegas[omegas.Count - 1] + step);
            }


            for(int i = 0; i < omegas.Count; i++)
            {
                double omega = omegas[i];
                afcs.Add(AFC(omega, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4));
            }

            this.chart.Series[0].Points.DataBindXY(omegas, afcs);
            this.chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            this.chart.ChartAreas[0].AxisX.LogarithmBase = 10;

            // with 10 as the base it will go to 1, 10, 100, 1000..
            this.chart.ChartAreas[0].AxisX.Interval = 0.5;

            // this adds 4 tickmarks into each interval:
            this.chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.25;

            // this add 8 gridlines into each interval:
            this.chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.125;

            // this sets two i.e. adds one extra label per interval
            this.chart.ChartAreas[0].AxisX.LabelStyle.Interval = 0.5;
            this.chart.ChartAreas[0].AxisX.LabelStyle.Format = "#0.0";

            this.chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            this.chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;

        }

        private double AFC(double omega, double K, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            double result = 20 * Math.Log10(K);
            result += l0 * 20 * Math.Log10(omega);
            result += l1 * 20 * Math.Log10(Math.Sqrt(1 + (T1 * omega) * (T1 * omega)));
            result += l2 * 20 * Math.Sqrt(1 + (T2 * omega) * (T2 * omega));
            result += l3 * 20 * Math.Sqrt(1 + (T3 * omega) * (T3 * omega));
            result += l4 * 20 * Math.Sqrt(Math.Pow(1 - Math.Pow(T4 * omega, 2), 2) +
                Math.Pow(2 * ksi4 * T4 * omega, 2));
            Debug.WriteLine("omega: " + omega + ": log10(omega) = " + Math.Log10(omega) + "; result = " + result);
            return result;
        }
    }
}
