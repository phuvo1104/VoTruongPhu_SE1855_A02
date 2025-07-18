using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        LucySalesDataContext context = new LucySalesDataContext();

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public Product? GetProductById(int productId)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

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
                return false;
            }
        }

        public bool DelProduct(int productId) {
            try
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
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
                return false;
            }
        }

        public bool UpProduct(Product product)
        {
            try
            {
                var eProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
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
                return false;
            }
        }
    }
}
