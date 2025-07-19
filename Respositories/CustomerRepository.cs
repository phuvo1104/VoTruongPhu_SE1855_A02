using System;
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
        private readonly CustomerDAO cd = new CustomerDAO();

        // Lấy danh sách khách hàng
        public List<Customer> GetCustomers()
        {
            return cd.GetCustomers();
        }

        // Thêm khách hàng
        public bool AddCustomer(Customer newCustomer)
        {
            return cd.AddCustomer(newCustomer);
        }

        // Cập nhật thông tin khách hàng
        public bool UpCustomer(Customer updatedCustomer)
        {
            return cd.UpCustomer(updatedCustomer);
        }

        // Xoá khách hàng
        public bool DelCustomer(int customerId)
        {
            return cd.DelCustomer(customerId);
        }

        // Tìm kiếm khách hàng theo ID
        public Customer? SearchCustomerById(int customerId)
        {
            return cd.SearchCustomerById(customerId);
        }

        // Đăng nhập bằng số điện thoại
        public Customer? Login(string phone)
        {
            return cd.Login(phone);
        }
    }
}
