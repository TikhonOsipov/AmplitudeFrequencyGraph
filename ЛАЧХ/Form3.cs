using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ЛАЧХ
{
    public partial class Form3 : Form
    {
        double omegaStart, omegaEnd;
        int l0, l1, l2, l3, l4;
        double T1, T2, T3, T4, ksi4;

        double firstOmega;
        double step;

        double T1_1, T2_1, T3_1, T4_1, ksi4_1;
        int l0_1, l1_1, l2_1, l3_1, l4_1;

        private void buttonCompute_Click_1(object sender, EventArgs e)
        {
            buttonCompute_Click(sender, e);
        }

        double T1_2, T2_2, T3_2, T4_2, ksi4_2;

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        int l0_2, l1_2, l2_2, l3_2, l4_2;

        List<double> omegas;
        private List<String> data, data1, data2;

        //открыть окно с таблицей для первого набора данных
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.setData(data);
        }

        //открыть окно с таблицей для второго набора данных
        private void openTable1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.setData(data1);
        }

        //открыть окно с таблицей для третього набора данных
        private void openTable2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.setData(data2);
        }

        //ввод второго набора данных
        private void initVariables2()
        {
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
        }

        //ввод третього набора данных
        private void initVariables3()
        {
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
        }

        private void toggleGraphics_Click(object sender, EventArgs e)
        {
            //check input fields
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" ||
                textBoxL0_1.Text == "" || textBoxL1_1.Text == "" || textBoxL2_1.Text == "" ||
                textBoxL3_1.Text == "" || textBoxL4_1.Text == "" || textBoxT1_1.Text == "" ||
                textBoxT2_1.Text == "" || textBoxT3_1.Text == "" || textBoxT4_1.Text == "" ||
                textBoxKsi4_1.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            //check input fields
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" || 
               textBoxL0_2.Text == "" || textBoxL1_2.Text == "" || textBoxL2_2.Text == "" ||
               textBoxL3_2.Text == "" || textBoxL4_2.Text == "" || textBoxT1_2.Text == "" ||
               textBoxT2_2.Text == "" || textBoxT3_2.Text == "" || textBoxT4_2.Text == "" ||
               textBoxKsi4_2.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (toggleGraphics.Text == "ВКЛ") {
                toggleGraphics.Text = "ВЫКЛ";
                this.openTable1.Enabled = true;
                this.openTable2.Enabled = true;
            }
            else if (toggleGraphics.Text == "ВЫКЛ") {
                toggleGraphics.Text = "ВКЛ";
                this.openTable1.Enabled = false;
                this.openTable2.Enabled = false;
                this.chart.Series[1].Points.Clear();
                this.chart.Series[2].Points.Clear();
                return;
            }
            data1 = new List<String>();
            data2 = new List<String>();

            initVariables2();
            initVariables3();

            List<double> afcs1 = new List<double>();
            List<double> afcs2 = new List<double>();

            for (int i = 0; i < omegas.Count; i++)
            {
                double omega = omegas[i];
                double pfcValue1 = PFC(omega, l0_1, l1_1, l2_1, l3_1, l4_1, T1_1, T2_1, T3_1, T4_1, ksi4_1);
                double pfcValue2 = PFC(omega, l0_2, l1_2, l2_2, l3_2, l4_2, T1_2, T2_2, T3_2, T4_2, ksi4_2);
                afcs1.Add(pfcValue1);
                afcs2.Add(pfcValue2);
                formatOutput(omega, pfcValue1, data1);
                formatOutput(omega, pfcValue2, data2);
            }

            this.chart.Series[1].Points.DataBindXY(omegas, afcs1);
            this.chart.Series[2].Points.DataBindXY(omegas, afcs2);
        }

        public void setFields(double omegaStart, double omegaEnd, int l0, int l1, int l2, int l3,
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

        // ------- set fields (1) -------
        public void setFields1(int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            this.l0_1 = l0;
            this.l1_1 = l1;
            this.l2_1 = l2;
            this.l3_1 = l3;
            this.l4_1 = l4;
            this.T1_1 = T1;
            this.T2_1 = T2;
            this.T3_1 = T3;
            this.T4_1 = T4;
            this.ksi4_1 = ksi4;

            this.textBoxL0_1.Text = l0_1.ToString();
            this.textBoxL1_1.Text = l1_1.ToString();
            this.textBoxL2_1.Text = l2_1.ToString();
            this.textBoxL3_1.Text = l3_1.ToString();
            this.textBoxL4_1.Text = l4_1.ToString();
            this.textBoxT1_1.Text = T1_1.ToString();
            this.textBoxT2_1.Text = T2_1.ToString();
            this.textBoxT3_1.Text = T3_1.ToString();
            this.textBoxT4_1.Text = T4_1.ToString();
            this.textBoxKsi4_1.Text = ksi4_1.ToString();
        }

        // ------- set fields (2) -------
        public void setFields2(int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            this.l0_2 = l0;
            this.l1_2 = l1;
            this.l2_2 = l2;
            this.l3_2 = l3;
            this.l4_2 = l4;
            this.T1_2 = T1;
            this.T2_2 = T2;
            this.T3_2 = T3;
            this.T4_2 = T4;
            this.ksi4_2 = ksi4;

            this.textBoxL0_2.Text = l0_2.ToString();
            this.textBoxL1_2.Text = l1_2.ToString();
            this.textBoxL2_2.Text = l2_2.ToString();
            this.textBoxL3_2.Text = l3_2.ToString();
            this.textBoxL4_2.Text = l4_2.ToString();
            this.textBoxT1_2.Text = T1_2.ToString();
            this.textBoxT2_2.Text = T2_2.ToString();
            this.textBoxT3_2.Text = T3_2.ToString();
            this.textBoxT4_2.Text = T4_2.ToString();
            this.textBoxKsi4_2.Text = ksi4_2.ToString();
        }

        public Form3()
        {
            InitializeComponent();
            this.chart.Series[0].LegendText = "Θ(ω)";
            this.chart.Series[1].LegendText = "Θ(ω)";
            this.chart.Series[2].LegendText = "Θ(ω)";
            formatLabels();
        }

        private void formatLabels()
        {
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

        //подготовка графика к работе
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
            yAxis.Title = "Θ(ω), град";
            yAxis.Interval = 20;
            yAxis.MajorGrid.LineColor = Color.Gainsboro;

            xAxis.Minimum = omegaStart;
            xAxis.Maximum = omegaEnd;
        }

        //кнопка "построить график"
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
            this.toggleGraphics.Enabled = true;

            //ввод данных
            double omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
            firstOmega = omegaStart;
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

            omegas = new List<double>();
            List<double> afcs = new List<double>();
            data = new List<String>();

            if(textBoxStep.Text == "") {
                step = 0.0001;
            } else {
                step = double.Parse(textBoxStep.Text.Replace(".", ","));
            }

            omegas.Add(omegaStart);

            //формирование списка omegas
            while (omegas[omegas.Count - 1] < omegaEnd)
            {
                if (omegas[omegas.Count - 1] / firstOmega >= 10) {
                    firstOmega = omegas[omegas.Count - 1];
                    step *= 10;
                }
                omegas.Add(omegas[omegas.Count - 1] + step);
            }


            for (int i = 0; i < omegas.Count; i++)
            {
                double omega = omegas[i];
                double pfcValue = PFC(omega, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4);
                formatOutput(omega, pfcValue, data);
                afcs.Add(pfcValue);
            }

            this.chart.Series[0].Points.DataBindXY(omegas, afcs);
            formatChartArea(this.chart.ChartAreas[0]);
        }

        //преобразование радиан в градусы
        private double radToDegree(double rad)
        {
            return rad * (180.0 / Math.PI);
        }

        //функция для вычисления ЛФЧХ
        private double PFC(double omega, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            double result = l0 * (Math.PI / 2);
            result += l1 * Math.Atan(T1 * omega);
            result += l2 * Math.Atan(T2 * omega);
            result += l3 * Math.Atan(T3 * omega);
            result += l4 * Math.Atan((2 * ksi4 * T4 * omega) / (1 - Math.Pow(T4 * omega, 2)));

            //преобразование радиан в градусы
            result = radToDegree(result);
            return result;
        }

        //форматирование вывода
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
