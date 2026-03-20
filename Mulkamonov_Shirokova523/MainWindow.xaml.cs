using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Mulkamonov_Shirokova_523
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Page1());
        }

        private void btnPage1_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Page1());
        }

        private void btnPage2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Page2());
        }

        private void btnPage3_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Page3());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?",
                "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}