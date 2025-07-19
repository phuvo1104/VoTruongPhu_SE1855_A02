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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Services;
using BusinessObject;

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        private readonly CustomerService _customerService = new CustomerService();

        public CustomerManagementWindow()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            lvCustomer.ItemsSource = _customerService.GetCustomers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustomerId.Text, out int customerId))
            {
                var customer = new Customer
                {
                    CustomerId = customerId,
                    CompanyName = txtCompanyName.Text,
                    ContactName = txtContactName.Text,
                    ContactTitle = txtContactTitle.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };
                if (_customerService.AddCustomer(customer))
                {
                    MessageBox.Show("Customer added successfully.");
                    LoadCustomers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to add customer.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Customer ID.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustomerId.Text, out int customerId))
            {
                var customer = new Customer
                {
                    CustomerId = customerId,
                    CompanyName = txtCompanyName.Text,
                    ContactName = txtContactName.Text,
                    ContactTitle = txtContactTitle.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };
                if (_customerService.UpCustomer(customer))
                {
                    MessageBox.Show("Customer updated successfully.");
                    LoadCustomers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to update customer.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Customer ID.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustomerId.Text, out int customerId))
            {
                if (_customerService.DelCustomer(customerId))
                {
                    MessageBox.Show("Customer deleted successfully.");
                    LoadCustomers();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to delete customer.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Customer ID.");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustomerId_Search.Text, out int customerId))
            {
                var customer = _customerService.SearchCustomerById(customerId);
                if (customer != null)
                {
                    lvCustomer.ItemsSource = new List<Customer> { customer };
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                    lvCustomer.ItemsSource = null;
                }
            }
            else
            {
                MessageBox.Show("Invalid Customer ID.");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            LoadCustomers();
        }

        private void ClearFields()
        {
            txtCustomerId.Text = "";
            txtCompanyName.Text = "";
            txtContactName.Text = "";
            txtContactTitle.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtCustomerId_Search.Text = "";
            lvCustomer.SelectedItem = null;
        }

        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomer.SelectedItem is Customer customer)
            {
                txtCustomerId.Text = customer.CustomerId.ToString();
                txtCompanyName.Text = customer.CompanyName;
                txtContactName.Text = customer.ContactName;
                txtContactTitle.Text = customer.ContactTitle;
                txtAddress.Text = customer.Address;
                txtPhone.Text = customer.Phone;
            }
        }
    }
}