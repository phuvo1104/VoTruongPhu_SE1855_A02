using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Services
{
    public interface IEmployeeService
    {
        public Employee? Login(string username, string password);
        public List<Employee> GetEmployees();
        public bool AddEmployee(Employee employee);
        public bool UpEmployee(Employee employee);
        public bool DelEmployee(int employeeId);
    }
}
