using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;

namespace Repositories
{
    /// <summary>
    /// Repository trung gian xử lý nghiệp vụ liên quan đến Employee.
    /// Gọi các phương thức từ lớp DAO và triển khai IEmployeeRepository.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        // DAO tương tác trực tiếp với cơ sở dữ liệu
        private readonly EmployeeDAO EmployeeDAO = new EmployeeDAO();

        /// <summary>
        /// Xác thực thông tin đăng nhập của nhân viên.
        /// </summary>
        /// <param name="username">Tên người dùng.</param>
        /// <param name="password">Mật khẩu.</param>
        /// <returns>Employee nếu hợp lệ, ngược lại null.</returns>
        public Employee? Login(string username, string password)
        {
            return EmployeeDAO.Login(username, password);
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên.
        /// </summary>
        /// <returns>List<Employee></returns>
        public List<Employee> GetEmployees()
        {
            return EmployeeDAO.GetEmployees();
        }

        /// <summary>
        /// Thêm một nhân viên mới vào hệ thống.
        /// </summary>
        /// <param name="employee">Đối tượng Employee cần thêm.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool AddEmployee(Employee employee)
        {
            return EmployeeDAO.AddEmployee(employee);
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên.
        /// </summary>
        /// <param name="employee">Đối tượng Employee đã được chỉnh sửa.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool UpEmployee(Employee employee)
        {
            return EmployeeDAO.UpEmployee(employee);
        }

        /// <summary>
        /// Xoá một nhân viên dựa trên ID.
        /// </summary>
        /// <param name="employeeId">ID của nhân viên cần xoá.</param>
        /// <returns>True nếu xoá thành công, false nếu không tìm thấy hoặc lỗi.</returns>
        public bool DelEmployee(int employeeId)
        {
            try
            {
                // Kiểm tra sự tồn tại của nhân viên trước khi xoá
                var employee = EmployeeDAO.GetEmployees().FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    return EmployeeDAO.DelEmployee(employeeId);
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return false;
            }
        }
    }
}
