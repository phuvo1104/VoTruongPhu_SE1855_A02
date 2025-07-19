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
using DataAccessLayer;
using Services;
using BusinessObject;

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for EmployeeManagementWindow.xaml
    /// </summary>
    public partial class EmployeeManagementWindow : Window
    {
        private readonly EmployeeService _employeeService = new EmployeeService();

        public EmployeeManagementWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            lvEmployee.ItemsSource = _employeeService.GetEmployees();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddEmployeeDialog(_employeeService);
            if (dlg.ShowDialog() == true)
            {
                LoadEmployees();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem is BusinessObject.Employee selectedEmployee)
            {
                var dlg = new UpdateEmployeeDialog(selectedEmployee, _employeeService);
                if (dlg.ShowDialog() == true)
                {
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to update.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvEmployee.SelectedItem is Employee selectedEmployee)
            {
                var result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (_employeeService.DelEmployee(selectedEmployee.EmployeeId))
                    {
                        MessageBox.Show("Employee deleted successfully.");
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete employee.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
