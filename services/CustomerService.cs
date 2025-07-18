using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Repositories;
using BusinessObject;
namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;
        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public Customer? Login(string phone)
        {
            return _customerRepository.Login(phone);
        }
        public bool AddCustomer(Customer newCustomer)
        {
            return _customerRepository.AddCustomer(newCustomer);
        }

        public bool DelCustomer(int customerId)
        {
            return _customerRepository.DelCustomer(customerId);
        }

        public Customer? SearchCustomerById(int customerId)
        {
            return _customerRepository.SearchCustomerById(customerId);
        }

        public bool UpCustomer(Customer updatedCustomer)
        {
            return _customerRepository.UpCustomer(updatedCustomer);
        }
    }
}
