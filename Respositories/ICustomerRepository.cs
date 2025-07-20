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
    /// Giao diện repository cho thao tác liên quan đến Customer.
    /// Triển khai bởi lớp thao tác dữ liệu khách hàng như CustomerRepository.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Lấy danh sách tất cả khách hàng.
        /// </summary>
        List<Customer> GetCustomers();

        /// <summary>
        /// Tìm khách hàng theo ID.
        /// </summary>
        Customer? SearchCustomerById(int customerId);

        /// <summary>
        /// Tìm khách hàng theo số điện thoại (dùng để login).
        /// </summary>
        Customer? Login(string phone);

        /// <summary>
        /// Thêm một khách hàng mới.
        /// </summary>
        bool AddCustomer(Customer newCustomer);

        /// <summary>
        /// Xoá khách hàng theo ID.
        /// </summary>
        bool DelCustomer(int customerId);

        /// <summary>
        /// Cập nhật thông tin khách hàng.
        /// </summary>
        bool UpCustomer(Customer updatedCustomer);
    }
}
