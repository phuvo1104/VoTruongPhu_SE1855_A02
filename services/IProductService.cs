﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Services
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProductByCategoryId(int categoryId);
        public Product? GetProductById(int productId);
        public bool AddProduct(Product product);
        public bool DelProduct(int productId);
        public bool UpProduct(Product product);
    }
}
