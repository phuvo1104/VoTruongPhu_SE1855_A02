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
using Services;
using BusinessObject;

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for LoginEmployeeWindow.xaml
    /// </summary>
    public partial class LoginEmployeeWindow : Window
    {
        private readonly EmployeeService _employeeService = new EmployeeService();

        public LoginEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = TxtUserName.Text.Trim();
            string password = TxtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var employee = _employeeService.Login(username, password);
            if (employee != null)
            {
                EmployeeMainWindow mainWindow = new EmployeeMainWindow(_employeeService);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Invalid username or password.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }
    }
}
