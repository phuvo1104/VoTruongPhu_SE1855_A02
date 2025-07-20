using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    /// <summary>
    /// Repository xử lý logic trung gian cho thực thể Customer.
    /// Dùng để gọi DAO và triển khai giao diện ICustomerRepository.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        // DAO thao tác trực tiếp với cơ sở dữ liệu
        private readonly CustomerDAO cd = new CustomerDAO();

        /// <summary>
        /// Lấy danh sách toàn bộ khách hàng từ cơ sở dữ liệu.
        /// </summary>
        /// <returns>List<Customer></returns>
        public List<Customer> GetCustomers()
        {
            return cd.GetCustomers();
        }

        /// <summary>
        /// Thêm một khách hàng mới vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="newCustomer">Đối tượng Customer cần thêm.</param>
        /// <returns>true nếu thành công, ngược lại false.</returns>
        public bool AddCustomer(Customer newCustomer)
        {
            return cd.AddCustomer(newCustomer);
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng hiện tại.
        /// </summary>
        /// <param name="updatedCustomer">Khách hàng với dữ liệu đã chỉnh sửa.</param>
        /// <returns>true nếu thành công, ngược lại false.</returns>
        public bool UpCustomer(Customer updatedCustomer)
        {
            return cd.UpCustomer(updatedCustomer);
        }

        /// <summary>
        /// Xoá một khách hàng dựa trên ID.
        /// </summary>
        /// <param name="customerId">ID của khách hàng cần xoá.</param>
        /// <returns>true nếu thành công, ngược lại false.</returns>
        public bool DelCustomer(int customerId)
        {
            return cd.DelCustomer(customerId);
        }

        /// <summary>
        /// Tìm kiếm khách hàng dựa vào ID.
        /// </summary>
        /// <param name="customerId">ID của khách hàng cần tìm.</param>
        /// <returns>Đối tượng Customer nếu tìm thấy, ngược lại null.</returns>
        public Customer? SearchCustomerById(int customerId)
        {
            return cd.SearchCustomerById(customerId);
        }

        /// <summary>
        /// Đăng nhập khách hàng bằng số điện thoại.
        /// </summary>
        /// <param name="phone">Số điện thoại.</param>
        /// <returns>Đối tượng Customer nếu đúng, ngược lại null.</returns>
        public Customer? Login(string phone)
        {
            return cd.Login(phone);
        }
    }
}
