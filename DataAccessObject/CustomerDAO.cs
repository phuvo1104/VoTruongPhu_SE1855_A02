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
        // Khởi tạo DbContext (kết nối đến DB)
        LucySalesDataContext dbContext = new LucySalesDataContext();

        // 1. Lấy danh sách toàn bộ khách hàng
        public List<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }

        // 2. Đăng nhập bằng số điện thoại
        public Customer? Login(string phone)
        {
            return dbContext.Customers.FirstOrDefault(p => p.Phone == phone);
        }

        // 3. Tìm khách hàng theo ID
        public Customer? SearchCustomerById(int customerId)
        {
            return dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        // 4. Thêm khách hàng mới
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
                // Log lỗi (nếu cần)
                return false;
            }
        }

        // 5. Cập nhật thông tin khách hàng
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
                // Log lỗi (nếu cần)
                return false;
            }
        }

        // 6. Xóa khách hàng theo ID
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
    }
}
