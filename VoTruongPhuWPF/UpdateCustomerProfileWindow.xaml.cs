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

namespace VoTruongphuWPF
{
    /// <summary>
    /// Interaction logic for UpdateCustomerProfileWindow.xaml
    /// </summary>
    public partial class UpdateCustomerProfileWindow : Window
    {
        private readonly ICustomerService _customerService;
        private readonly Customer _customer;

        public UpdateCustomerProfileWindow(Customer customer, ICustomerService customerService)
        {
            InitializeComponent();
            _customer = customer;
            _customerService = customerService;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            txtCustomerId.Text = _customer.CustomerId.ToString();
            txtCompanyName.Text = _customer.CompanyName;
            txtContactName.Text = _customer.ContactName;
            txtContactTitle.Text = _customer.ContactTitle;
            txtAddress.Text = _customer.Address;
            txtPhone.Text = _customer.Phone;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _customer.CompanyName = txtCompanyName.Text;
            _customer.ContactName = txtContactName.Text;
            _customer.ContactTitle = txtContactTitle.Text;
            _customer.Address = txtAddress.Text;
            _customer.Phone = txtPhone.Text;

            // Use the correct method name as defined in ICustomerService
            _customerService.UpCustomer(_customer);
            MessageBox.Show("Customer profile updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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