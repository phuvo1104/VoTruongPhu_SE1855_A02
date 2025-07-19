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
    /// Interaction logic for OrderManagementWindow.xaml
    /// </summary>
    public partial class OrderManagementWindow : Window
    {
        private readonly OrderDetailService _orderDetailService = new OrderDetailService();
        private readonly ProductService _productService = new ProductService();

        public OrderManagementWindow()
        {
            InitializeComponent();
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            var orderDetails = _orderDetailService.GetOrderDetails();
            var products = _productService.GetProducts();

            var displayList = orderDetails.Select(od => new
            {
                ProductName = products.FirstOrDefault(p => p.ProductId == od.ProductId)?.ProductName ?? "Unknown",
                Quantity = od.Quantity,
                UnitPrice = od.UnitPrice,
                Discount = od.Discount,
                OrderId = od.OrderId,
                ProductId = od.ProductId
            }).ToList();

            lvOrder.ItemsSource = displayList;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddOrderDialog();
            if (dlg.ShowDialog() == true)
            {
                LoadOrderDetails();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvOrder.SelectedItem;
            if (selected != null)
            {
                var dlg = new UpdateOrderDialog();
                if (dlg.ShowDialog() == true)
                {
                    LoadOrderDetails();
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = lvOrder.SelectedItem;
            if (selected != null)
            {
                var orderIdProp = selected.GetType().GetProperty("OrderId");
                var productIdProp = selected.GetType().GetProperty("ProductId");
                if (orderIdProp != null && productIdProp != null)
                {
                    int orderId = (int)orderIdProp.GetValue(selected);
                    int productId = (int)productIdProp.GetValue(selected);

                    var result = MessageBox.Show("Are you sure you want to delete this order?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        _orderDetailService.DelOrderDetail(orderId, productId);
                        LoadOrderDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an order to delete.");
            }
        }
    }
}
