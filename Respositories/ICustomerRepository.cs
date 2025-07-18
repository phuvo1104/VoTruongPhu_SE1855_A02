using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
namespace Repositories
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();
        public Customer? SearchCustomerById(int customerId);
        public Customer? Login(string phone);
        public bool AddCustomer(Customer newCustomer);
        public bool DelCustomer(int customerId);
        public bool UpCustomer(Customer updatedCustomer);
    }
}
