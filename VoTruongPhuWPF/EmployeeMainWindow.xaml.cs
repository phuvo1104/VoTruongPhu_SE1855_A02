using BusinessObject;
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
    /// Interaction logic for EmployeeMainWindow.xaml
    /// </summary>
    public partial class EmployeeMainWindow : Window
    {
        private readonly EmployeeService _employeeService;

        public EmployeeMainWindow(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeComponent();
        }

        private void BtnManageCustomer_Click(object sender, RoutedEventArgs e)
        {
            var win = new CustomerManagementWindow();
            win.ShowDialog();
        }

        private void BtnManageProduce_Click(object sender, RoutedEventArgs e)
        {
            var win = new ProductAndCategoryWindow();
            win.ShowDialog();
        }

        private void BtnManageProfile_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = GetSelectedEmployee(); // Assuming a method to get the selected employee
            var dlg = new UpdateEmployeeDialog(selectedEmployee, _employeeService);
            dlg.ShowDialog();
        }

        private void BtnProcessOrders_Click(object sender, RoutedEventArgs e)
        {
            var win = new OrderManagementWindow();
            win.ShowDialog();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            var win = new ReportWindow();
            win.ShowDialog();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private Employee GetSelectedEmployee()
        {
            // Placeholder for logic to retrieve the selected employee
            return new Employee(); // Replace with actual implementation
        }
    }
}
