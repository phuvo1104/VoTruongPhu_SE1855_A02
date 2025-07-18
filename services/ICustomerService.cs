using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Services
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomers();
        public Customer? Login(string phone);
        public Customer? SearchCustomerById(int customerId);
        public bool AddCustomer(Customer newCustomer);
        public bool DelCustomer(int customerId);
        public bool UpCustomer(Customer updatedCustomer);
    }
}
