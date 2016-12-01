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

        private void buttonCompute_Click_1(object sender, EventArgs e)
        {
            buttonCompute_Click(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        List<double> omegas, afcs;
        private List<String> data;

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
            
        }

        //открыть окно с таблицей для третього набора данных
        private void openTable2_Click(object sender, EventArgs e)
        {
            
        }

        private void chart_Click(object sender, EventArgs e)
        {
            FormPfcGraph formPfcGraph = new FormPfcGraph();
            if (omegas != null && afcs != null)
            {
                formPfcGraph.setData(omegas, afcs);
                formPfcGraph.Show();
            }
        }

        private void toggleGraphics_Click(object sender, EventArgs e)
        {
            
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

        public Form3()
        {
            InitializeComponent();
            this.chart.Series[0].LegendText = "Θ(ω)";
            formatLabels();
        }

        private void formatLabels()
        {
            this.labelWStart.Text = "ω1"; //ξω
            this.labelWEnd.Text = "ω2";
            this.labelKsi4.Text = "ξ4";

            //L_0 ranges
            this.labelL0range.Text = "0; ±1; ±2";
            this.labelL1range.Text = "0; ±1";
            this.labelL2range.Text = "0; ±1";
            this.labelL3range.Text = "0; ±1";
            this.labelL4range.Text = "0; ±1";

            //T_0 ranges
            this.labelT1range.Text = "0,01...100";
            this.labelT2range.Text = "0,01...100";
            this.labelT3range.Text = "0,01...100";
            this.labelT4range.Text = "0,01...100";

            this.labelXIrange.Text = "0...1";
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

        private Boolean dataIsCorrect(int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            return (l0 == 0 || l0 == 1 || l0 == -1 || l0 == 2 || l0 == -2) &&
                (l1 == 0 || l1 == 1 || l1 == -1) &&
                (l2 == 0 || l2 == 1 || l2 == -1) &&
                (l3 == 0 || l3 == 1 || l3 == -1) &&
                (l4 == 0 || l4 == 1 || l4 == -1) &&
                (T1 >= 0.01 && T1 <= 100) && (T2 >= 0.01 && T2 <= 100) && 
                (T3 >= 0.01 && T3 <= 100) && (T4 >= 0.01 && T4 <= 100) &&
                (ksi4 >= 0 && ksi4 <= 1);
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

            try
            {
                this.button1.Enabled = true;

                //ввод данных
                double omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
                firstOmega = omegaStart;
                step = 0.01 / 100;
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

                if(!dataIsCorrect(l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                    return;
                }

                omegas = new List<double>();
                afcs = new List<double>();
                data = new List<String>();

                omegas.Add(omegaStart);

                //формирование списка omegas
                while (omegas[omegas.Count - 1] < omegaEnd)
                {
                    if (omegas[omegas.Count - 1] / firstOmega >= 10)
                    {
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
            } catch
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
            }
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

            if (omega >= 1 / T4 && omega < omegaEnd) result -= 180;
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
