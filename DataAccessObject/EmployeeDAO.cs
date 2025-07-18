using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        LucySalesDataContext dbContext = new LucySalesDataContext();

        public Employee? Login (string username, string password)
        {
            return dbContext.Employees.FirstOrDefault(e => e.UserName == username && e.Password == password);
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
                return false;
            }
        }

        public bool UpEmployee(Employee employee)
        {
            try
            {
                var eEmployee = dbContext.Employees.Find(employee.EmployeeId);
                if (eEmployee != null)
                {
                    eEmployee.Name = employee.Name;
                    eEmployee.UserName = employee.UserName;
                    eEmployee.Password = employee.Password;
                    eEmployee.JobTitle = employee.JobTitle;
                    eEmployee.BirthDate = employee.BirthDate;
                    eEmployee.HireDate = employee.HireDate;
                    eEmployee.Address = employee.Address;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
        }

        public bool DelEmployee(int employeeId)
        {
            try
            {
                var employee = dbContext.Employees.Find(employeeId);
                if (employee != null)
                {
                    dbContext.Employees.Remove(employee);
                    dbContext.SaveChanges();
                    return true;
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
