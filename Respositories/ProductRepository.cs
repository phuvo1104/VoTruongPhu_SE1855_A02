using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO ProductDAO = new ProductDAO();
        public bool AddProduct(Product product)
        {
            return ProductDAO.AddProduct(product);
        }

        public Product? GetProductById(int productId)
        {
            return ProductDAO.GetProductById(productId);
        }
        public bool DelProduct(int productId)
        {
            return ProductDAO.DelProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return ProductDAO.GetAllProducts();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return ProductDAO.GetProductByCategoryId(categoryId);
        }

        public bool UpProduct(Product product)
        {
            return ProductDAO.UpProduct(product);
        }
    }
}
