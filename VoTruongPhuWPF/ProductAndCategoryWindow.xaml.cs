using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;
using Services;

namespace VoTruongPhuWPF
{
    public partial class ProductAndCategoryWindow : Window
    {
        private readonly ProductService _productService = new ProductService();
        private readonly CategoryService _categoryService = new CategoryService();
        private Product _selectedProduct = null;

        public ProductAndCategoryWindow()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetCategories();
            tvCategory.Items.Clear();
            foreach (var cat in categories)
            {
                var item = new TreeViewItem { Header = cat.CategoryName, Tag = cat.CategoryId };
                tvCategory.Items.Add(item);
            }
        }

        private void LoadProducts(int? categoryId = null)
        {
            var products = _productService.GetProducts();
            if (categoryId.HasValue)
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            lvProduct.ItemsSource = products;
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvCategory.SelectedItem is TreeViewItem item && item.Tag is int categoryId)
            {
                LoadProducts(categoryId);
            }
            else
            {
                LoadProducts();
            }
            ClearForm();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem is Product product)
            {
                _selectedProduct = product;
                txtName.Text = product.ProductName;
                txtSupplierId.Text = product.SupplierId.ToString();
                txtCategoryId.Text = product.CategoryId.ToString();
                txtQuantityPerUnit.Text = product.QuantityPerUnit;
                txtPrice.Text = product.UnitPrice.ToString();
                txtQuantity.Text = product.UnitsInStock.ToString();
                txtUnitsOnOrder.Text = product.UnitsOnOrder.ToString();
                txtReorderLevel.Text = product.ReorderLevel.ToString();
                chkDiscontinued.IsChecked = product.Discontinued;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtSupplierId.Text, out int supplierId) ||
                !int.TryParse(txtCategoryId.Text, out int categoryId) ||
                !decimal.TryParse(txtPrice.Text, out decimal price) ||
                !short.TryParse(txtQuantity.Text, out short unitsInStock) ||
                !short.TryParse(txtUnitsOnOrder.Text, out short unitsOnOrder) ||
                !short.TryParse(txtReorderLevel.Text, out short reorderLevel))
            {
                MessageBox.Show("Invalid input. Please check your data.");
                return;
            }

            var product = new Product
            {
                ProductId = _selectedProduct?.ProductId ?? 0,
                ProductName = txtName.Text,
                SupplierId = supplierId,
                CategoryId = categoryId,
                QuantityPerUnit = txtQuantityPerUnit.Text,
                UnitPrice = price,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                Discontinued = chkDiscontinued.IsChecked == true
            };

            bool result;
            if (_selectedProduct == null)
            {
                result = _productService.AddProduct(product);
                MessageBox.Show(result ? "Product added." : "Failed to add product.");
            }
            else
            {
                result = _productService.UpProduct(product);
                MessageBox.Show(result ? "Product updated." : "Failed to update product.");
            }
            LoadProducts();
            ClearForm();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }
            var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                bool result = _productService.DelProduct(_selectedProduct.ProductId);
                MessageBox.Show(result ? "Product deleted." : "Failed to delete product.");
                LoadProducts();
                ClearForm();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            lvProduct.SelectedItem = null;
        }

        private void ClearForm()
        {
            _selectedProduct = null;
            txtName.Text = "";
            txtSupplierId.Text = "";
            txtCategoryId.Text = "";
            txtQuantityPerUnit.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtUnitsOnOrder.Text = "";
            txtReorderLevel.Text = "";
            chkDiscontinued.IsChecked = false;
        }
    }
}
