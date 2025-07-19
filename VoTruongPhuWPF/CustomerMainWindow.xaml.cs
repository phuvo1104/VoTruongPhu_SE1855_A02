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
    // Add a view model for displaying order info in the ListView
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Details { get; set; }
    }

    /// <summary>
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        private List<OrderViewModel> _orderViewModels;
        private Customer _currentCustomer;
        private List<Order> _orders;
        private readonly OrderService _orderService = new OrderService();
        private readonly CustomerService _customerService = new CustomerService(); // Thêm trường này

        public CustomerMainWindow()
        {
            InitializeComponent();
            LoadCustomerData();
            LoadOrderData();
        }

        private void LoadCustomerData()
        {
            // Replace with actual customer retrieval logic
            _currentCustomer = new Customer
            {
                CustomerId = 1, // Assuming CustomerId is int in your model
                CompanyName = "Acme Corp",
                ContactName = "John Doe",
                ContactTitle = "Manager",
                Address = "123 Main St",
                Phone = "555-1234"
            };

            TxtCustomerId.Text = _currentCustomer.CustomerId.ToString();
            TxtCustomerId.IsEnabled = false; // Disable editing of CustomerId
            TxtCompanyName.Text = _currentCustomer.CompanyName;
            TxtContactName.Text = _currentCustomer.ContactName;
            TxtContactTitle.Text = _currentCustomer.ContactTitle;
            TxtAddress.Text = _currentCustomer.Address;
            TxtPhone.Text = _currentCustomer.Phone;
        }

        private void LoadOrderData()
        {
            // Truy vấn đơn hàng từ database qua service
            var allOrders = _orderService.GetOrders();
            // Lọc đơn hàng theo CustomerId hiện tại
            _orders = allOrders
                .Where(o => o.CustomerId == _currentCustomer.CustomerId)
                .ToList();

            // Project to view model for display
            _orderViewModels = _orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = (o.OrderDetails != null) ? o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity) : 0,
                Details = $"Items: {(o.OrderDetails != null ? o.OrderDetails.Count : 0)}"
            }).ToList();

            OrdersListView.ItemsSource = _orderViewModels;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            if (listView?.SelectedItem is OrderViewModel selectedOrder)
            {
                MessageBox.Show($"Selected Order ID: {selectedOrder.OrderId}\nDetails: {selectedOrder.Details}", "Order Details");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _currentCustomer.CompanyName = TxtCompanyName.Text;
            _currentCustomer.ContactName = TxtContactName.Text;
            _currentCustomer.ContactTitle = TxtContactTitle.Text;
            _currentCustomer.Address = TxtAddress.Text;
            _currentCustomer.Phone = TxtPhone.Text;

            // Save to database/service here
            bool result = _customerService.UpCustomer(_currentCustomer);
            if (result)
            {
                MessageBox.Show("Profile updated successfully!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to update profile.", "Update", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLogou_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }
    }
}
