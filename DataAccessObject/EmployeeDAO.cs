using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        // DbContext kết nối tới database
        private readonly LucySalesDataContext dbContext = new LucySalesDataContext();

        // -----------------------------------
        // 1. Đăng nhập (Login)
        // -----------------------------------
        public Employee? Login(string username, string password)
        {
            // Tìm nhân viên theo username và password
            return dbContext.Employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
        }

        // -----------------------------------
        // 2. Lấy danh sách nhân viên
        // -----------------------------------
        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        // -----------------------------------
        // 3. Thêm nhân viên mới
        // -----------------------------------
        public bool AddEmployee(Employee employee)
        {
            try
            {
                dbContext.Employees.Add(employee);  // Thêm vào DbSet
                dbContext.SaveChanges();            // Lưu thay đổi vào database
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi thêm nhân viên: {ex.Message}");
                return false;
            }
        }

        // -----------------------------------
        // 4. Cập nhật thông tin nhân viên
        // -----------------------------------
        public bool UpEmployee(Employee employee)
        {
            try
            {
                var eEmployee = dbContext.Employees.Find(employee.EmployeeId);  // Tìm nhân viên theo ID
                if (eEmployee != null)
                {
                    // Cập nhật thông tin
                    eEmployee.Name = employee.Name;
                    eEmployee.UserName = employee.UserName;
                    eEmployee.Password = employee.Password;
                    eEmployee.JobTitle = employee.JobTitle;
                    eEmployee.BirthDate = employee.BirthDate;
                    eEmployee.HireDate = employee.HireDate;
                    eEmployee.Address = employee.Address;

                    dbContext.SaveChanges();  // Lưu lại vào database
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi cập nhật nhân viên: {ex.Message}");
                return false;
            }
        }

        // -----------------------------------
        // 5. Xoá nhân viên
        // -----------------------------------
        public bool DelEmployee(int employeeId)
        {
            try
            {
                var employee = dbContext.Employees.Find(employeeId);  // Tìm theo ID
                if (employee != null)
                {
                    dbContext.Employees.Remove(employee);  // Xoá khỏi DbSet
                    dbContext.SaveChanges();              // Lưu thay đổi
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi xoá nhân viên: {ex.Message}");
                return false;
            }
        }
    }
}
