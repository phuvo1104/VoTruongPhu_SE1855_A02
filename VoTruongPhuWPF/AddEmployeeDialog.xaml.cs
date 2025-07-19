using System;
using System.Windows;
using BusinessObject;
using Services;

namespace VoTruongPhuWPF
{
    public partial class AddEmployeeDialog : Window
    {
        private readonly IEmployeeService _employeeService;

        public AddEmployeeDialog(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Name, Username, and Password are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var employee = new Employee
                {
                    // If Id is auto-generated, you can skip this or parse if needed
                    Name = txtName.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    Password = txtPassword.Password,
                    JobTitle = txtJobTitle.Text.Trim(),
                    BirthDate = dpBirthDate.SelectedDate,
                    HireDate = dpHireDate.SelectedDate,
                    Address = txtAddress.Text.Trim()
                };

                _employeeService.AddEmployee(employee);
                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}