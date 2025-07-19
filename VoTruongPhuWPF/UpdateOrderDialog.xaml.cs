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
    /// Interaction logic for UpdateOrderDialog.xaml
    /// </summary>
    public partial class UpdateOrderDialog : Window
    {
        public UpdateOrderDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void RemoveOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add logic to remove the selected order detail from the DataGrid
            MessageBox.Show("RemoveOrderDetail_Click called.");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add logic to save the updated order
            MessageBox.Show("SaveButton_Click called.");
        }
    }
}
