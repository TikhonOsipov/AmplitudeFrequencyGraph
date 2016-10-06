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
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            double omegaStart = double.Parse(textBoxWStart.Text);
            double omegaEnd = double.Parse(textBoxWEnd.Text);
            double K = double.Parse(textBoxK.Text);
            int l0 = int.Parse(textBoxL0.Text);
            int l1 = int.Parse(textBoxL1.Text);
            int l2 = int.Parse(textBoxL2.Text);
            int l3 = int.Parse(textBoxL3.Text);
            int l4 = int.Parse(textBoxL4.Text);
            double T1 = double.Parse(textBoxT1.Text);
            double T2 = double.Parse(textBoxT2.Text);
            double T3 = double.Parse(textBoxT3.Text);
            double T4 = double.Parse(textBoxT4.Text);
            double ksi4 = double.Parse(textBoxKsi4.Text);

            this.chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            this.chart.ChartAreas[0].AxisX.Minimum = omegaStart;
            this.chart.ChartAreas[0].AxisX.Maximum = omegaEnd;

            List<double> omegas = new List<double>();
            List<double> afcs = new List<double>();

            int counter = 2;

            omegas.Add(omegaStart);

            while(omegas[omegas.Count - 1] < omegaEnd)
            {
                omegas.Add(omegaStart * counter);
                counter++;
            }


            for(int i = 0; i < omegas.Count; i++)
            {
                double omega = omegas[i];
                afcs.Add(AFC(omega, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4));
            }

            chart.Series[0].Points.DataBindXY(omegas, afcs);
        }

        private double AFC(double omega, double K, int l0, int l1, int l2, int l3, 
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            double result = 20 * Math.Log10(K);
            result += l0 * 20 * Math.Log10(omega);
            result += l1 * 20 * Math.Log10(Math.Sqrt(1 + (T1 * omega) * (T1 * omega)));
            result += l2 * 20 * Math.Sqrt(1 + (T2 * omega) * (T2 * omega));
            result += l3 * 20 * Math.Sqrt(1 + (T3 * omega) * (T3 * omega));
            result += l4 * 20 * Math.Sqrt((1 - T4 * omega * omega) * (1 - T4 * omega * omega) + 
                (2 * ksi4 * T4 * omega) * (2 * ksi4 * T4 * omega));
            Debug.WriteLine("omega: " + omega + ": result = " + result);
            return result ;
        }
    }
}
