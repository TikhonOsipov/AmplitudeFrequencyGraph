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
    public partial class Form3 : Form
    {
        double omegaStart, omegaEnd;
        int l0, l1, l2, l3, l4;

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.setData(data);
        }

        double T1, T2, T3, T4, ksi4;

        public void setFields(double omegaStart, double omegaEnd, double K, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            this.omegaStart = omegaStart;
            this.omegaEnd = omegaEnd;
            this.l0 = l0;
            this.l1 = l1;
            this.l2 = l2;
            this.l3 = l3;
            this.l4 = l4;
            this.T1 = T1;
            this.T2 = T2;
            this.T3 = T3;
            this.T4 = T4;
            this.ksi4 = ksi4;

            this.textBoxWStart.Text = omegaStart.ToString();
            this.textBoxWEnd.Text = omegaEnd.ToString();
            this.textBoxL0.Text = l0.ToString();
            this.textBoxL1.Text = l1.ToString();
            this.textBoxL2.Text = l2.ToString();
            this.textBoxL3.Text = l3.ToString();
            this.textBoxL4.Text = l4.ToString();
            this.textBoxT1.Text = T1.ToString();
            this.textBoxT2.Text = T2.ToString();
            this.textBoxT3.Text = T3.ToString();
            this.textBoxT4.Text = T4.ToString();
            this.textBoxKsi4.Text = ksi4.ToString();
        }

        public Form3()
        {
            InitializeComponent();
            this.labelWStart.Text = "ω1"; //ξω
            this.labelWEnd.Text = "ω2";
            this.labelKsi4.Text = "ξ4";
            this.chart.Series[0].LegendText = "Θ(ω)";

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

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" ||
                textBoxL0.Text == "" || textBoxL1.Text == "" || textBoxL2.Text == "" ||
                textBoxL3.Text == "" || textBoxL4.Text == "" || textBoxT1.Text == "" ||
                textBoxT2.Text == "" || textBoxT3.Text == "" || textBoxT4.Text == "" ||
                textBoxKsi4.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            this.button1.Enabled = true;

            double omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
            double omegaEnd = double.Parse(textBoxWEnd.Text.Replace(".", ","));
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
            data = new List<String>();

            double step = 0.01;

            omegas.Add(omegaStart);

            while (omegas[omegas.Count - 1] < omegaEnd)
            {
                omegas.Add(omegas[omegas.Count - 1] + step);
            }


            for (int i = 0; i < omegas.Count; i++)
            {
                double omega = omegas[i];
                afcs.Add(PFC(omega, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4));
            }

            this.chart.Series[0].Points.DataBindXY(omegas, afcs);
            this.chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;

            this.chart.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            this.chart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.Gainsboro;
            this.chart.ChartAreas[0].AxisX.MinorGrid.Interval = 1;

            this.chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;

            this.chart.ChartAreas[0].AxisX.LogarithmBase = 10;

            // with 10 as the base it will go to 1, 10, 100, 1000..
            //this.chart.ChartAreas[0].AxisX.Interval = 0.01;

            // this adds 4 tickmarks into each interval:
            //this.chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.25;

            // this add 8 gridlines into each interval:
            //this.chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.125;

            // this sets two i.e. adds one extra label per interval
            //this.chart.ChartAreas[0].AxisX.LabelStyle.Interval = 0.5;
            this.chart.ChartAreas[0].AxisX.LabelStyle.Format = "#0.#####";

            this.chart.ChartAreas[0].AxisX.Title = "ω, рад/с";
            this.chart.ChartAreas[0].AxisY.Title = "Θ(ω), град";

            this.chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;

            this.chart.ChartAreas[0].AxisY.Interval = 20;
            this.chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
        }

        private double radToDegree(double rad)
        {
            return rad * (180.0 / Math.PI);
        }

        private double PFC(double omega, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            double result = l0 * (Math.PI/2);
            result += l1 * Math.Atan(T1 * omega);
            result += l2 * Math.Atan(T2 * omega);
            result += l3 * Math.Atan(T3 * omega);
            result += l4 * Math.Atan((2 * ksi4 * T4 * omega)/(1 - Math.Pow(T4 * omega, 2)));

            //convert to degrees from radians
            result = radToDegree(result);

            String omegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", omega));
            String lgOmegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", Math.Log10(omega)));
            String functionFormat = String.Format("{0, 9}", String.Format("{0:F5}", result));
            Debug.WriteLine("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; Θ(ω) = " + functionFormat);
            data.Add("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; Θ(ω) = " + functionFormat);
            return result;
        }
    }
}
