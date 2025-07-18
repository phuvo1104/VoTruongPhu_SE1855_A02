﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDAO cd =  new CustomerDAO();
        public List<Customer> GetCustomers()
        {
            return cd.GetCustomers();
        }

        public Customer? Login(string phone)
        {
            return cd.Login(phone);
        }
        public bool AddCustomer(Customer newCustomer)
        {
            return cd.AddCustomer(newCustomer);
        }

        public bool DelCustomer(int customerId)
        {
            return cd.DelCustomer(customerId);
        }

        public Customer? SearchCustomerById(int customerId)
        {
            return cd.SearchCustomerById(customerId);
        }

        public bool UpCustomer(Customer updatedCustomer)
        {
            return cd.UpCustomer(updatedCustomer);
        }
    }
}
