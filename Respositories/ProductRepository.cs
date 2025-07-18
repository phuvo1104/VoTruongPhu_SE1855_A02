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
        ProductDAO pd = new ProductDAO();
        public bool AddProduct(Product product)
        {
            return pd.AddProduct(product);
        }

        public Product? GetProductById(int productId)
        {
            return pd.GetProductById(productId);
        }
        public bool DelProduct(int productId)
        {
            return pd.DelProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return pd.GetAllProducts();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return pd.GetProductByCategoryId(categoryId);
        }

        public bool UpProduct(Product product)
        {
            return pd.UpProduct(product);
        }
    }
}
