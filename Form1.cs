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
using System.Windows.Forms.DataVisualization.Charting;

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

        private List<String> data;

        double omegaStart, omegaEnd, K;
        int l0, l1, l2, l3, l4;
        double T1, T2, T3, T4, ksi4;

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
            this.button1.Enabled = true;

            omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
            omegaEnd = double.Parse(textBoxWEnd.Text.Replace(".", ","));
            K = double.Parse(textBoxK.Text.Replace(".", ","));
            l0 = int.Parse(textBoxL0.Text.Replace(".", ","));
            l1 = int.Parse(textBoxL1.Text.Replace(".", ","));
            l2 = int.Parse(textBoxL2.Text.Replace(".", ","));
            l3 = int.Parse(textBoxL3.Text.Replace(".", ","));
            l4 = int.Parse(textBoxL4.Text.Replace(".", ","));
            T1 = double.Parse(textBoxT1.Text.Replace(".", ","));
            T2 = double.Parse(textBoxT2.Text.Replace(".", ","));
            T3 = double.Parse(textBoxT3.Text.Replace(".", ","));
            T4 = double.Parse(textBoxT4.Text.Replace(".", ","));
            ksi4 = double.Parse(textBoxKsi4.Text.Replace(".", ","));

            this.chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            this.chart.ChartAreas[0].AxisX.Minimum = omegaStart;
            this.chart.ChartAreas[0].AxisX.Maximum = omegaEnd;

            List<double> omegas = new List<double>();
            List<double> afcs = new List<double>();
            data = new List<String>();

            double step = 0.1;

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

            Axis xAxis = this.chart.ChartAreas[0].AxisX;
            Axis yAxis = this.chart.ChartAreas[0].AxisY;

            xAxis.LabelStyle.Enabled = true;
            xAxis.MinorGrid.Enabled = true;
            xAxis.MinorGrid.LineColor = Color.Gainsboro;
            xAxis.MinorGrid.Interval = 1;

            xAxis.MajorGrid.Enabled = true;

            xAxis.LogarithmBase = 10;

            // with 10 as the base it will go to 1, 10, 100, 1000..
            //this.chart.ChartAreas[0].AxisX.Interval = 0.5;

            // this adds 4 tickmarks into each interval:
            //this.chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.25;

            // this add 8 gridlines into each interval:
            //this.chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.125;

            // this sets two i.e. adds one extra label per interval
            //this.chart.ChartAreas[0].AxisX.LabelStyle.Interval = 0.5;


            xAxis.LabelStyle.Format = "#0.#####";

            xAxis.MajorGrid.LineColor = Color.Gainsboro;
            xAxis.MajorGrid.LineColor = Color.Gainsboro;

            xAxis.IsLabelAutoFit = false;

            List<double> xs = new List<double>() { 1, 2, 4, 8, 10, 20, 40, 80, 100, 200, 500, 1000 };
            double spacer = 0.5d;

            for (int i = 0; i < xs.Count; i++)
            {
                CustomLabel cl = new CustomLabel();
                cl.FromPosition = Math.Log10(xs[i]) * spacer;
                cl.ToPosition = Math.Log10(xs[i]) / spacer;
                if (xs[i] <= 1)
                {
                    cl.FromPosition = 0f;
                    cl.ToPosition = 0.01f;
                }
                cl.Text = xs[i] + "";
                xAxis.CustomLabels.Add(cl);

            }

            xAxis.Title = "ω, рад/с";
            yAxis.Title = "L(ω), дБ";
        }

        private double AFC(double omega, double K, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            double result = 20 * Math.Log10(K);
            result += l0 * 20 * Math.Log10(omega);
            result += l1 * 20 * Math.Log10(Math.Sqrt(1 + (T1 * omega) * (T1 * omega)));
            result += l2 * 20 * Math.Log10(Math.Sqrt(1 + (T2 * omega) * (T2 * omega)));
            result += l3 * 20 * Math.Log10(Math.Sqrt(1 + (T3 * omega) * (T3 * omega)));
            result += l4 * 20 * Math.Log10(Math.Sqrt(Math.Pow(1 - Math.Pow(T4 * omega, 2), 2) +
                Math.Pow(2 * ksi4 * T4 * omega, 2)));

            String omegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", omega));
            String lgOmegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", Math.Log10(omega)));
            String functionFormat = String.Format("{0, 9}", String.Format("{0:F5}", result));
            Debug.WriteLine("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; L(ω) = " + functionFormat);
            data.Add("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; L(ω) = " + functionFormat);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.setData(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.setFields(omegaStart, omegaEnd, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4);
        }
    }
}
