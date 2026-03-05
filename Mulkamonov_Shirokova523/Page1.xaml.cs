using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mulkamonov_Shirokova_523.Pages
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtX.Text) ||
                    string.IsNullOrWhiteSpace(txtY.Text) ||
                    string.IsNullOrWhiteSpace(txtZ.Text))
                {
                    MessageBox.Show("Заполните все поля ввода!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string xText = txtX.Text.Replace('.', ',');
                string yText = txtY.Text.Replace('.', ',');
                string zText = txtZ.Text.Replace('.', ',');

                if (!double.TryParse(xText, out double x) ||
                    !double.TryParse(yText, out double y) ||
                    !double.TryParse(zText, out double z))
                {
                    MessageBox.Show("Введите корректные числовые значения!\nИспользуйте запятую для дробных чисел.",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double chislitel = 2 * Math.Cos(x - Math.PI / 6);
                double znamenatel = 0.5 + Math.Pow(Math.Sin(y), 2);

                if (Math.Abs(znamenatel) < 0.0000001)
                {
                    MessageBox.Show("Ошибка: деление на ноль!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double pervayaChast = chislitel / znamenatel;

                double znamenatel2 = 3 - (z * z) / 5;
                if (Math.Abs(znamenatel2) < 0.0000001)
                {
                    MessageBox.Show("Ошибка: деление на ноль!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double vtorayaChast = 1 + (z * z) / znamenatel2;
                double result = pervayaChast * vtorayaChast;

                txtResult.Text = result.ToString("F6");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            txtResult.Clear();
        }
    }
}