using Services;
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
    /// Interaction logic for LoginCustomerWindow.xaml
    /// </summary>
    public partial class LoginCustomerWindow : Window
    {
        private readonly ICustomerService _customerService = new CustomerService();

        public LoginCustomerWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = TxtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter your phone number.", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var customer = _customerService.Login(phone);
            if (customer != null)
            {
                CustomerMainWindow mainWindow = new CustomerMainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Invalid phone number.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
