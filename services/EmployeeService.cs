using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;
using Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public Employee? Login(string username, string password)
        {
            return _employeeRepository.Login(username, password);
        }
        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public bool AddEmployee(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public bool UpEmployee(Employee employee)
        {
            return _employeeRepository.UpEmployee(employee);
        }
        public bool DelEmployee(int employeeId)
        {
            return _employeeRepository.DelEmployee(employeeId);

        }

    }
}

