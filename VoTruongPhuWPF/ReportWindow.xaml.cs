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

namespace VoTruongPhuWPF
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            var start = dpStartDate.SelectedDate ?? DateTime.Now.AddDays(-7);
            var end = dpEndDate.SelectedDate ?? DateTime.Now;

            // Use your OrderService to get all orders in the date range
            var orderService = new OrderService();
            var orders = orderService.GetOrders()
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .ToList();

            decimal totalSales = 0;
            int orderCount = orders.Count;
            foreach (var order in orders)
            {
                if (order.OrderDetails != null)
                {
                    totalSales += order.OrderDetails.Sum(od => od.UnitPrice * od.Quantity);
                }
            }
            decimal averageOrder = orderCount > 0 ? totalSales / orderCount : 0;

            var reportData = new List<SaleReportItem>
            {
                new SaleReportItem
                {
                    Period = $"{start:yyyy-MM-dd} - {end:yyyy-MM-dd}",
                    TotalSales = totalSales,
                    OrderCount = orderCount,
                    AverageOrder = averageOrder
                }
            };

            lvSaleReport.ItemsSource = reportData;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class SaleReportItem
    {
        public string Period { get; set; }
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
        public decimal AverageOrder { get; set; }
    }
}
