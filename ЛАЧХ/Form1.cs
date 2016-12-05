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
            commonData = CommonData.getInstance();
            formatLabels();
        }

        CommonData commonData;
        Form3 form3;

        private int nextLog10ForTable;

        private List<double> omegas, afcs;
        private List<String> data;

        double omegaStart, omegaEnd, K;
        int l0, l1, l2, l3, l4;
        double T1, T2, T3, T4, ksi4;

        double step;

        double firstOmega;

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        //открыть окно с таблицей для первого набора данных
        private void button1_Click(object sender, EventArgs e)
        {
            calculateTable(omegaStart, omegaEnd, data);
            Form2 form2 = new Form2();
            form2.Show();
            form2.setData(data);
        }

        //open table (0)
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void chart_Click(object sender, EventArgs e)
        {
            FormAfcGraph formAfcGraph = new FormAfcGraph();
            if(omegas != null && afcs != null)
            {
                formAfcGraph.setData(omegas, afcs);
                formAfcGraph.Show();
            }
        }

        //открыть окно с таблицей для второго набора данных
        private void openTable1_Click(object sender, EventArgs e)
        {
            
        }

        //открыть окно с таблицей для третьего набора данных
        private void openTable2_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCompute_Click_1(object sender, EventArgs e)
        {
            buttonCompute_Click(sender, e);
        }


        //кнопка "вкл/выкл графиков"
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        //подготовка полей
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
            xAxis.Title = "lg(ω), рад/с";
            yAxis.Title = "L(ω), дБ";

            xAxis.Minimum = omegaStart;
            xAxis.Maximum = omegaEnd;
        }

        private void insertDataInFields()
        {
            this.textBoxWStart.Text = commonData.getOmegaStart().ToString();
            this.textBoxWEnd.Text = commonData.getOmegaEnd().ToString();
            this.textBoxK.Text = commonData.getK().ToString();
            this.textBoxL0.Text = commonData.getL0().ToString();
            this.textBoxL1.Text = commonData.getL1().ToString();
            this.textBoxL2.Text = commonData.getL2().ToString();
            this.textBoxL3.Text = commonData.getL3().ToString();
            this.textBoxL4.Text = commonData.getL4().ToString();
            this.textBoxT1.Text = commonData.getT1().ToString();
            this.textBoxT2.Text = commonData.getT2().ToString();
            this.textBoxT3.Text = commonData.getT3().ToString();
            this.textBoxT4.Text = commonData.getT4().ToString();
            this.textBoxKsi4.Text = commonData.getXi4().ToString();
        }

        //ввод первого набора данных
        private void initVariables()
        {
            omegaStart = double.Parse(textBoxWStart.Text.Replace(".", ","));
            if (omegaStart > 0) nextLog10ForTable = (int) Math.Log10(omegaStart);
            firstOmega = omegaStart;
            step = 0.01 / 100;
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
            commonData.setFields(omegaStart, omegaEnd, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4);
        }

        public void updateCommonData()
        {
            this.commonData = CommonData.getInstance();
            insertDataInFields();
        }

        private Boolean dataIsCorrect(double K, int l0, int l1, int l2, int l3,
            int l4, double T1, double T2, double T3, double T4, double ksi4)
        {
            return (l0 == 0 || l0 == 1 || l0 == -1 || l0 == 2 || l0 == -2) &&
                (l1 == 0 || l1 == 1 || l1 == -1) &&
                (l2 == 0 || l2 == 1 || l2 == -1) &&
                (l3 == 0 || l3 == 1 || l3 == -1) &&
                (l4 == 0 || l4 == 1 || l4 == -1) &&
                (T1 >= 0.01 && T1 <= 100) && (T2 >= 0.01 && T2 <= 100) &&
                (T3 >= 0.01 && T3 <= 100) && (T4 >= 0.01 && T4 <= 100) &&
                (ksi4 >= 0 && ksi4 <= 1) &&
                (K >= 0.1 && K <= 200);
        }

        //формирование списка omegas
        private void initOmegas()
        {
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
        }

        //кнопка "построить график"
        private void buttonCompute_Click(object sender, EventArgs e)
        {
            //проверка на заполненность полей: если хотя бы одно не заполнено, выведет ошибку
            if (textBoxWStart.Text == "" || textBoxWEnd.Text == "" || textBoxK.Text == "" ||
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
                //активация кнопок таблицы и вкл/выкл графиков
                this.button1.Enabled = true;

                //ввод из полей
                initVariables();

                if (!dataIsCorrect(K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                    return;
                }

                omegas = new List<double>(); //массив значений omega
                data = new List<String>(); //массив строк для вывода в таблицу
                afcs = new List<double>(); //массив значений L(omega)

                //формирование массива omegas
                initOmegas();

                //формирование массива значений L(omega) и вывод на график
                for (int i = 0; i < omegas.Count; i++)
                {
                    double omega = omegas[i];
                    double afcValue = AFC(omega, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4);
                    afcs.Add(afcValue);   
                }

                this.chart.Series[0].Points.DataBindXY(omegas, afcs);
                formatChartArea(this.chart.ChartAreas[0]);
            } catch
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
            }
        }

        //функция для вычисления ЛАЧХ
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

        //открыть окно для вычисления ФЧХ
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (form3 == null) form3 = new Form3();
                form3.Show();
                initVariables();
                form3.setForm1(this);
                form3.BringToFront();
                form3.updateCommonData();
            } catch (Exception)
            {
                form3 = new Form3();
                form3.Show();
                initVariables();
                form3.setForm1(this);
                form3.BringToFront();
                form3.updateCommonData();
            }
        }

        private void calculateTable(double omegaStart, double omegaEnd, List<String> list)
        {
            String omegaFormat, lgOmegaFormat, functionFormat;
            double omega;

            int omegaStartLog10 = (int)Math.Log10(omegaStart);
            int omegaEndLog10 = (int)Math.Log10(omegaEnd);
            for(int i = omegaStartLog10; i < omegaEndLog10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    omega = j * Math.Pow(10, i);

                    omegaFormat = String.Format("{0, 6}", String.Format("{0, 5}", omega));
                    lgOmegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", Math.Log10(omega)));
                    functionFormat = String.Format("{0, 9}", String.Format("{0:F5}", AFC(omega, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4)));
                    list.Add("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; L(ω) = " + functionFormat);
                }
            }

            omega = Math.Pow(10, omegaEndLog10);
            omegaFormat = String.Format("{0, 6}", String.Format("{0, 5}", omega));
            lgOmegaFormat = String.Format("{0, 9}", String.Format("{0:F5}", Math.Log10(omega)));
            functionFormat = String.Format("{0, 9}", String.Format("{0:F5}", AFC(omega, K, l0, l1, l2, l3, l4, T1, T2, T3, T4, ksi4)));
            list.Add("ω: " + omegaFormat + "; lg(ω) = " + lgOmegaFormat + "; L(ω) = " + functionFormat);
        }
    }
}
