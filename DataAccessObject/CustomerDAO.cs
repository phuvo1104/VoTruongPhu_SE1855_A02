using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        LucySalesDataContext dbContext = new LucySalesDataContext();
        public List<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }
        public Customer? Login(string phone)
        {
            return dbContext.Customers.FirstOrDefault(p => p.Phone == phone);
        }
        public Customer? SearchCustomerById(int customerId)
        {
            return dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public bool AddCustomer(Customer newCustomer)
        {
            try
            {
                dbContext.Customers.Add(newCustomer);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DelCustomer(int customerId)
        {
            var customer = dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer != null)
            {
                dbContext.Remove(customer);
                return dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool UpCustomer(Customer upCustomer)
        {
            try
            {
                var eCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerId == upCustomer.CustomerId);
                if (eCustomer != null)
                {
                    eCustomer.CompanyName = upCustomer.CompanyName;
                    eCustomer.ContactName = upCustomer.ContactName;
                    eCustomer.ContactTitle = upCustomer.ContactTitle;
                    eCustomer.Address = upCustomer.Address;
                    eCustomer.Phone = upCustomer.Phone;
                    dbContext.SaveChanges();
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
