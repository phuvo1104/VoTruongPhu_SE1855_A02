using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public Product? GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public bool DelProduct(int productId)
        {
            return _productRepository.DelProduct(productId);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return _productRepository.GetProductByCategoryId(categoryId);
        }

        public bool UpProduct(Product product)
        {
            return _productRepository.UpProduct(product);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
