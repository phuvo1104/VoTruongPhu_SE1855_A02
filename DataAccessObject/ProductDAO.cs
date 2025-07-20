using BusinessObject; // Import lớp Product từ tầng Business Object
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// DAO (Data Access Object) cho bảng Products.
    /// Lớp này cung cấp các phương thức CRUD để làm việc với dữ liệu sản phẩm.
    /// </summary>
    public class ProductDAO
    {
        // DbContext để truy cập cơ sở dữ liệu
        LucySalesDataContext context = new LucySalesDataContext();

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        /// <summary>
        /// Lấy danh sách sản phẩm theo mã danh mục (CategoryId)
        /// </summary>
        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return context.Products
                          .Where(p => p.CategoryId == categoryId)
                          .ToList();
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một sản phẩm theo mã sản phẩm (ProductId)
        /// </summary>
        public Product? GetProductById(int productId)
        {
            return context.Products
                          .FirstOrDefault(p => p.ProductId == productId);
        }

        /// <summary>
        /// Thêm một sản phẩm mới vào cơ sở dữ liệu
        /// </summary>
        public bool AddProduct(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa một sản phẩm theo ProductId
        /// </summary>
        public bool DelProduct(int productId)
        {
            try
            {
                var product = context.Products
                                     .FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin một sản phẩm
        /// </summary>
        public bool UpProduct(Product product)
        {
            try
            {
                var eProduct = context.Products
                                      .FirstOrDefault(p => p.ProductId == product.ProductId);
                if (eProduct != null)
                {
                    eProduct.ProductName = product.ProductName;
                    eProduct.SupplierId = product.SupplierId;
                    eProduct.CategoryId = product.CategoryId;
                    eProduct.QuantityPerUnit = product.QuantityPerUnit;
                    eProduct.UnitPrice = product.UnitPrice;
                    eProduct.UnitsInStock = product.UnitsInStock;
                    eProduct.UnitsOnOrder = product.UnitsOnOrder;
                    eProduct.ReorderLevel = product.ReorderLevel;
                    eProduct.Discontinued = product.Discontinued;

                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }
    }
}
