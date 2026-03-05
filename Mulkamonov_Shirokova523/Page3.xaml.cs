using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Mulkamonov_Shirokova_523.Pages
{
    public partial class Page3 : Page
    {
        private Chart chart;
        private WindowsFormsHost host;

        public Page3()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CreateChart();
        }

        private void CreateChart()
        {
            try
            {
                host = new WindowsFormsHost();

                chart = new Chart();
                chart.Dock = System.Windows.Forms.DockStyle.Fill;

                ChartArea area = new ChartArea("MainArea");
                chart.ChartAreas.Add(area);

                area.AxisX.Title = "x";
                area.AxisY.Title = "y";
                area.AxisX.MajorGrid.LineColor = Color.LightGray;
                area.AxisY.MajorGrid.LineColor = Color.LightGray;

                Legend legend = new Legend();
                chart.Legends.Add(legend);

                Series series = new Series();
                series.Name = "График функции";
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 3;
                series.Color = Color.Blue;
                chart.Series.Add(series);

                host.Child = chart;

                chartContainer.Content = host;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании графика: " + ex.Message);
            }
        }

        private double CalculateY(double x, double a, double b, double c)
        {
            if (Math.Abs(x) < 0.0000001)
                return double.NaN;

            double term1 = (0.01 * b * c) / x;
            double underSqrt = Math.Pow(a, 3) * x;

            if (underSqrt < 0)
                return double.NaN;

            double term2 = Math.Cos(Math.Sqrt(underSqrt));
            return term1 + term2;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtA.Text) ||
                    string.IsNullOrWhiteSpace(txtB.Text) ||
                    string.IsNullOrWhiteSpace(txtC.Text) ||
                    string.IsNullOrWhiteSpace(txtX0.Text) ||
                    string.IsNullOrWhiteSpace(txtXk.Text) ||
                    string.IsNullOrWhiteSpace(txtDx.Text))
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }

                double a = double.Parse(txtA.Text.Replace('.', ','));
                double b = double.Parse(txtB.Text.Replace('.', ','));
                double c = double.Parse(txtC.Text.Replace('.', ','));
                double x0 = double.Parse(txtX0.Text.Replace('.', ','));
                double xk = double.Parse(txtXk.Text.Replace('.', ','));
                double dx = double.Parse(txtDx.Text.Replace('.', ','));

                if (dx <= 0 || x0 >= xk)
                {
                    MessageBox.Show("Проверьте интервал и шаг!");
                    return;
                }

                lstResults.Items.Clear();
                lstResults.Items.Add("x\t\ty");
                lstResults.Items.Add("-----------------");

                for (double x = x0; x <= xk; x += dx)
                {
                    double y = CalculateY(x, a, b, c);

                    if (double.IsNaN(y))
                        lstResults.Items.Add($"{x:F2}\tне определено");
                    else
                        lstResults.Items.Add($"{x:F2}\t{y:F4}");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода! Используйте запятую для дробных чисел.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnGraph_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtA.Text) ||
                    string.IsNullOrWhiteSpace(txtB.Text) ||
                    string.IsNullOrWhiteSpace(txtC.Text) ||
                    string.IsNullOrWhiteSpace(txtX0.Text) ||
                    string.IsNullOrWhiteSpace(txtXk.Text) ||
                    string.IsNullOrWhiteSpace(txtDx.Text))
                {
                    MessageBox.Show("Сначала введите данные!");
                    return;
                }

                double a = double.Parse(txtA.Text.Replace('.', ','));
                double b = double.Parse(txtB.Text.Replace('.', ','));
                double c = double.Parse(txtC.Text.Replace('.', ','));
                double x0 = double.Parse(txtX0.Text.Replace('.', ','));
                double xk = double.Parse(txtXk.Text.Replace('.', ','));
                double dx = double.Parse(txtDx.Text.Replace('.', ','));

                chart.Series[0].Points.Clear();

                int pointCount = 0;
                for (double x = x0; x <= xk; x += dx)
                {
                    double y = CalculateY(x, a, b, c);

                    if (!double.IsNaN(y) && !double.IsInfinity(y))
                    {
                        chart.Series[0].Points.AddXY(x, y);
                        pointCount++;
                    }
                }

                if (pointCount == 0)
                {
                    MessageBox.Show("Нет точек для построения графика!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при построении графика: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "1";
            txtB.Text = "1";
            txtC.Text = "1";
            txtX0.Text = "0,1";
            txtXk.Text = "2";
            txtDx.Text = "0,1";
            lstResults.Items.Clear();
            chart?.Series[0]?.Points.Clear();
        }
    }
}