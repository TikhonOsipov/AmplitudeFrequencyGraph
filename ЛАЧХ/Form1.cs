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

namespace ЛАЧХ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.chart.Series[0].LegendText = "L(ω)";
            this.chart.Series[1].LegendText = "L(ω)";
            this.chart.Series[2].LegendText = "L(ω)";

            formatLabels();
        }

        private void formatLabels() {
            this.labelWStart.Text = "ω1"; //ξω
            this.labelWEnd.Text = "ω2";
            this.labelKsi4.Text = "ξ4";
            this.labelKsi4_1.Text = "ξ4";
            this.labelKsi4_2.Text = "ξ4";

            //L_0 ranges
            this.labelL0range.Text = "0; ±1; ±2";
            this.labelL1range.Text = "0; ±1";
            this.labelL2range.Text = "0; ±1";
            this.labelL3range.Text = "0; ±1";
            this.labelL4range.Text = "0; ±1";
            //L_1 ranges
            this.labelL0_1range.Text = "0; ±1; ±2";
            this.labelL1_1range.Text = "0; ±1";
            this.labelL2_1range.Text = "0; ±1";
            this.labelL3_1range.Text = "0; ±1";
            this.labelL4_1range.Text = "0; ±1";
            //L_2 ranges
            this.labelL0_2range.Text = "0; ±1; ±2";
            this.labelL1_2range.Text = "0; ±1";
            this.labelL2_2range.Text = "0; ±1";
            this.labelL3_2range.Text = "0; ±1";
            this.labelL4_2range.Text = "0; ±1";

            //T_0 ranges
            this.labelT1range.Text = "0,01...100";
            this.labelT2range.Text = "0,01...100";
            this.labelT3range.Text = "0,01...100";
            this.labelT4range.Text = "0,01...100";
            //T_1 ranges
            this.labelT1_1range.Text = "0,01...100";
            this.labelT2_1range.Text = "0,01...100";
            this.labelT3_1range.Text = "0,01...100";
            this.labelT4_1range.Text = "0,01...100";
            //T_2 ranges
            this.labelT1_2range.Text = "0,01...100";
            this.labelT2_2range.Text = "0,01...100";
            this.labelT3_2range.Text = "0,01...100";
            this.labelT4_2range.Text = "0,01...100";

            this.labelXIrange.Text = "0...1";
            this.labelXI_1range.Text = "0...1";
            this.labelXI_2range.Text = "0...1";
        }

        private List<double> omegas;
        private List<String> data, data1, data2;

        double omegaStart, omegaEnd, K;
        int l0, l1, l2, l3, l4;
        double T1, T2, T3, T4, ksi4;

        double step;

        double firstOmega;

        double K1, T1_1, T2_1, T3_1, T4_1, ksi4_1;

        int l0_1, l1_1, l2_1, l3_1, l4_1;

        double K2, T1_2, T2_2, T3_2, T4_2, ksi4_2;
        int l0_2, l1_2, l2_2, l3_2, l4_2;

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        //open table (0)
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        //open table (1)
        private void openTable1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.setData(data1);
        }

        //open table (2)
        private void openTable2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.setData(data2);
        }

        private void buttonCompute_Click_1(object sender, EventArgs e)
        {
            buttonCompute_Click(sender, e);
        }


        //on/off graphics
        private void button3_Click(object sender, EventArgs e)
        {
            //check input fields
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" || textBoxK1.Text == "" ||
                textBoxL0_1.Text == "" || textBoxL1_1.Text == "" || textBoxL2_1.Text == "" ||
                textBoxL3_1.Text == "" || textBoxL4_1.Text == "" || textBoxT1_1.Text == "" ||
                textBoxT2_1.Text == "" || textBoxT3_1.Text == "" || textBoxT4_1.Text == "" ||
                textBoxKsi4_1.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            //check input fields
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" || textBoxK1.Text == "" ||
               textBoxL0_2.Text == "" || textBoxL1_2.Text == "" || textBoxL2_2.Text == "" ||
               textBoxL3_2.Text == "" || textBoxL4_2.Text == "" || textBoxT1_2.Text == "" ||
               textBoxT2_2.Text == "" || textBoxT3_2.Text == "" || textBoxT4_2.Text == "" ||
               textBoxKsi4_2.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (button3.Text == "ВКЛ") {
                button3.Text = "ВЫКЛ";
                this.openTable1.Enabled = true;
                this.openTable2.Enabled = true;
            } else if (button3.Text == "ВЫКЛ") {
                button3.Text = "ВКЛ";
                this.openTable1.Enabled = false;
                this.openTable2.Enabled = false;
                this.chart.Series[1].Points.Clear();
                this.chart.Series[2].Points.Clear();
                return;
            }

            K1 = double.Parse(textBoxK1.Text.Replace(".", ","));
            l0_1 = int.Parse(textBoxL0_1.Text.Replace(".", ","));
            l1_1 = int.Parse(textBoxL1_1.Text.Replace(".", ","));
            l2_1 = int.Parse(textBoxL2_1.Text.Replace(".", ","));
            l3_1 = int.Parse(textBoxL3_1.Text.Replace(".", ","));
            l4_1 = int.Parse(textBoxL4_1.Text.Replace(".", ","));
            T1_1 = double.Parse(textBoxT1_1.Text.Replace(".", ","));
            T2_1 = double.Parse(textBoxT2_1.Text.Replace(".", ","));
            T3_1 = double.Parse(textBoxT3_1.Text.Replace(".", ","));
            T4_1 = double.Parse(textBoxT4_1.Text.Replace(".", ","));
            ksi4_1 = double.Parse(textBoxKsi4_1.Text.Replace(".", ","));

            K2 = double.Parse(textBoxK2.Text.Replace(".", ","));
            l0_2 = int.Parse(textBoxL0_2.Text.Replace(".", ","));
            l1_2 = int.Parse(textBoxL1_2.Text.Replace(".", ","));
            l2_2 = int.Parse(textBoxL2_2.Text.Replace(".", ","));
            l3_2 = int.Parse(textBoxL3_2.Text.Replace(".", ","));
            l4_2 = int.Parse(textBoxL4_2.Text.Replace(".", ","));
            T1_2 = double.Parse(textBoxT1_2.Text.Replace(".", ","));
            T2_2 = double.Parse(textBoxT2_2.Text.Replace(".", ","));
            T3_2 = double.Parse(textBoxT3_2.Text.Replace(".", ","));
            T4_2 = double.Parse(textBoxT4_2.Text.Replace(".", ","));
            ksi4_2 = double.Parse(textBoxKsi4_2.Text.Replace(".", ","));

            data1 = new List<String>();
            data2 = new List<String>();
            List<double> afcs1 = new List<double>();
            List<double> afcs2 = new List<double>();

            for (int i = 0; i < omegas.Count; i++)
            {
                double omega = omegas[i];
                double afcValue1 = AFC(omega, K1, l0_1, l1_1, l2_1, l3_1, l4_1, T1_1, T2_1, T3_1, T4_1, ksi4_1);
                double afcValue2 = AFC(omega, K2, l0_2, l1_2, l2_2, l3_2, l4_2, T1_2, T2_2, T3_2, T4_2, ksi4_2);
                afcs1.Add(AFC(omega, K1, l0_1, l1_1, l2_1, l3_1, l4_1, T1_1, T2_1, T3_1, T4_1, ksi4_1));
                afcs2.Add(AFC(omega, K2, l0_2, l1_2, l2_2, l3_2, l4_2, T1_2, T2_2, T3_2, T4_2, ksi4_2));
                formatOutput(omega, afcValue1, data1);
                formatOutput(omega, afcValue2, data2);
            }

            this.chart.Series[1].Points.DataBindXY(omegas, afcs1);
            this.chart.Series[2].Points.DataBindXY(omegas, afcs2);
        }

        private void formatChartArea(ChartArea chartArea)
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
            yAxis.Title = "L(ω), дБ";

            xAxis.Minimum = omegaStart;
            xAxis.Maximum = omegaEnd;
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" || textBoxK.Text == "" ||
                textBoxL0.Text == "" || textBoxL1.Text == "" || textBoxL2.Text == "" ||
                textBoxL3.Text == "" || textBoxL4.Text == "" || textBoxT1.Text == "" ||
                textBoxT2.Text == "" || textBoxT3.Text == "" || textBoxT4.Text == "" ||
                textBoxKsi4.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            this.button1.Enabled = true;
            this.button3.Enabled = true;

            omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
            firstOmega = omegaStart;
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

            omegas = new List<double>();
            List<double> afcs = new List<double>();
            data = new List<String>();

            if (textBoxStep.Text == "") {
                step = 0.0001;
            }
            else {
                step = double.Parse(textBoxStep.Text.Replace(".", ","));
            }

            omegas.Add(omegaStart);

            while (omegas[omegas.Count - 1] < omegaEnd)
            {
                if (omegas[omegas.Count - 1] / firstOmega >= 10)
                {
                    firstOmega = omegas[omegas.Count - 1];
                    step *= 10;
                }
                omegas.Add(omegas[omegas.Count - 1] + step);
            }


            for (int i = 0; i < omegas.Count; i++) {
                double omega = omegas[i];
                double afcValue = AFC(omega, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4);
                afcs.Add(afcValue);
                formatOutput(omega, afcValue, data);
            }

            this.chart.Series[0].Points.DataBindXY(omegas, afcs);
            formatChartArea(this.chart.ChartAreas[0]);
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
            form3.setFields(omegaStart, omegaEnd, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4);
            form3.setFields1(l0_1, l1_1, l2_1, l3_1, l4_1, T1_1, T2_1, T3_1, T4_1, ksi4_1);
            form3.setFields2(l0_2, l1_2, l2_2, l3_2, l4_2, T1_2, T2_2, T3_2, T4_2, ksi4_2);
        }

        private void formatOutput(double omega, double function, List<String> list)
        {
            String omegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", omega));
            String lgOmegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", Math.Log10(omega)));
            String functionFormat = String.Format("{0, 9}", String.Format("{0:F5}", function));
            Debug.WriteLine("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; Θ(ω) = " + functionFormat);
            list.Add("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; Θ(ω) = " + functionFormat);
        }
    }
}
