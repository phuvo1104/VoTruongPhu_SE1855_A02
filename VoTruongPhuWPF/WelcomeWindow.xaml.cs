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
using System.Windows.Shapes;

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_click(object sender, RoutedEventArgs e)
        {
            LoginCustomerWindow loginCustomerWindow = new LoginCustomerWindow();
            loginCustomerWindow.Show();
            this.Close();
        }

        private void btnEmployee_click(object sender, RoutedEventArgs e)
        {
            LoginEmployeeWindow loginEmployeeWindow = new LoginEmployeeWindow();
            loginEmployeeWindow.Show();
            this.Close();
        }
    }
}
