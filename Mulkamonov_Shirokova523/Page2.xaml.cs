using System;
using System.Windows;
using System.Windows.Controls;

namespace Mulkamonov_Shirokova_523.Pages
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private double GetFx(double x)
        {
            if (rbSh.IsChecked == true)
                return Math.Sinh(x);
            else if (rbX2.IsChecked == true)
                return x * x;
            else
                return Math.Exp(x);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtY.Text))
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }

                double x = double.Parse(txtX.Text.Replace('.', ','));
                double y = double.Parse(txtY.Text.Replace('.', ','));
                double fx = GetFx(x);

                double result;
                if (x * y > 0)
                    result = Math.Pow(fx + y, 2) - Math.Sqrt(fx * y);
                else if (x * y < 0)
                    result = Math.Pow(fx + y, 2) + Math.Sqrt(Math.Abs(fx * y));
                else
                    result = Math.Pow(fx + y, 2) + 1;

                txtResult.Text = result.ToString("F4");
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtResult.Clear();
            rbSh.IsChecked = true;
        }
    }
}