using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessObject;
using Services;

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for AddOrderDialog.xaml
    /// </summary>
    public partial class AddOrderDialog : Window
    {
        private List<Customer> customers;
        private List<Employee> employees;
        private List<Product> products;
        private List<OrderDetail> orderDetails = new();

        public AddOrderDialog()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            customers = new CustomerService().GetCustomers().ToList();
            employees = new EmployeeService().GetEmployees().ToList();
            products = new ProductService().GetAllProducts().ToList();

            cbCustomer.ItemsSource = customers;
            cbEmployee.ItemsSource = employees;
            cbProduct.ItemsSource = products;

            OrderDetailsDataGrid.ItemsSource = orderDetails;
        }

        private void RemoveOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (OrderDetailsDataGrid.SelectedItem is OrderDetail selectedDetail)
            {
                orderDetails.Remove(selectedDetail);
                OrderDetailsDataGrid.Items.Refresh();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbCustomer.SelectedItem is not Customer customer ||
                cbEmployee.SelectedItem is not Employee employee ||
                dpDate.SelectedDate is not DateTime orderDate)
            {
                MessageBox.Show("Please fill all order information.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var order = new Order
            {
                CustomerId = customer.CustomerId,
                EmployeeId = employee.EmployeeId,
                OrderDate = orderDate,
                OrderDetails = orderDetails
            };

            // Save order logic here (e.g., new OrderService().AddOrder(order);)
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void cbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProduct.SelectedItem is Product product)
            {
                txtPrice.Text = product.UnitPrice?.ToString("0.##") ?? "0";
            }
        }

        private void AddOrderDetail()
        {
            if (cbProduct.SelectedItem is not Product product ||
                !int.TryParse(txtQuantity.Text, out int quantity) ||
                !decimal.TryParse(txtPrice.Text, out decimal price) ||
                !float.TryParse(txtDiscount.Text, out float discount))
            {
                MessageBox.Show("Invalid order detail input.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var detail = new OrderDetail
            {
                Product = product,
                ProductId = product.ProductId,
                Quantity = (short)quantity,
                UnitPrice = price,
                Discount = discount
            };

            orderDetails.Add(detail);
            OrderDetailsDataGrid.Items.Refresh();
        }
    }
}
