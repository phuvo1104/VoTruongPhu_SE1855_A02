using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDAO ed = new EmployeeDAO();
        public Employee? Login(string username, string password)
        {
            return ed.Login(username, password);
        }

        public List<Employee> GetEmployees()
        {
            return ed.GetEmployees();
        }

        public bool AddEmployee(Employee employee)
        {
            return ed.AddEmployee(employee);
        }

        public bool UpEmployee(Employee employee)
        {
            return ed.UpEmployee(employee);
        }

        public bool DelEmployee(int employeeId)
        {
            try
            {
                var employee = ed.GetEmployees().FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    ed.DelEmployee(employeeId);
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
