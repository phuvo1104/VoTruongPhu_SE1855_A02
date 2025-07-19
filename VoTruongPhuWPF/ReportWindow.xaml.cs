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
            // Example: Generate dummy data for demonstration
            var start = dpStartDate.SelectedDate ?? DateTime.Now.AddDays(-7);
            var end = dpEndDate.SelectedDate ?? DateTime.Now;
            var reportData = new List<SaleReportItem>
            {
                new SaleReportItem
                {
                    Period = $"{start:yyyy-MM-dd} - {end:yyyy-MM-dd}",
                    TotalSales = 12345.67m,
                    OrderCount = 42,
                    AverageOrder = 293.94m
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
