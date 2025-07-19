using System;
using System.Windows;
using BusinessObject;
using Services;

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for UpdateEmployeeDialog.xaml
    /// </summary>
    public partial class UpdateEmployeeDialog : Window
    {
        private Employee _currentEmployee;
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeDialog(Employee employee, IEmployeeService employeeService)
        {
            InitializeComponent();
            _currentEmployee = employee;
            _employeeService = employeeService;
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            txtId.Text = _currentEmployee.EmployeeId.ToString();
            txtName.Text = _currentEmployee.Name;
            txtUserName.Text = _currentEmployee.UserName;
            txtPassword.Password = _currentEmployee.Password ?? string.Empty;
            txtJobTitle.Text = _currentEmployee.JobTitle ?? string.Empty;
            dpBirthDate.SelectedDate = _currentEmployee.BirthDate;
            dpHireDate.SelectedDate = _currentEmployee.HireDate;
            txtAddress.Text = _currentEmployee.Address ?? string.Empty;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _currentEmployee.Name = txtName.Text;
            _currentEmployee.UserName = txtUserName.Text;
            _currentEmployee.Password = txtPassword.Password;
            _currentEmployee.JobTitle = txtJobTitle.Text;
            _currentEmployee.BirthDate = dpBirthDate.SelectedDate;
            _currentEmployee.HireDate = dpHireDate.SelectedDate;
            _currentEmployee.Address = txtAddress.Text;

            _employeeService.UpEmployee(_currentEmployee);
            MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
