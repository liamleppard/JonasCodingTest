using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await Task.Run(() => _employeeDbWrapper.FindAll());
        }

        public async Task<Employee> GetEmployeeByCode(string employeeCode)
        {
            return await Task.Run(() => _employeeDbWrapper.Find(t => t.EmployeeCode.Equals(employeeCode))?.FirstOrDefault());
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            return await Task.Run(() => _employeeDbWrapper.Insert(employee));
        }

        public async Task<bool> DeleteEmployeeByCode(string employeeCode)
        {
            var employee = await Task.Run(() => _employeeDbWrapper.Find(t => t.EmployeeCode.Equals(employeeCode))?.FirstOrDefault());
            if (employee != null)
            {
                return await Task.Run(() => _employeeDbWrapper.Delete(t => t.EmployeeCode.Equals(employeeCode)));
            }

            return false;
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            var existingEmployee = _employeeDbWrapper.Find(t =>
                t.SiteId.Equals(employee.SiteId) &&
                t.EmployeeCode.Equals(employee.EmployeeCode) &&
                t.EmployeeCode.Equals(employee.EmployeeCode))?.FirstOrDefault();

            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.OccupationName = employee.OccupationName;
                existingEmployee.EmployeeStatus = employee.EmployeeStatus;
                existingEmployee.EmailAddress = employee.EmailAddress;
                existingEmployee.PhoneNumber = employee.PhoneNumber;
                existingEmployee.LastModified = employee.LastModified;

                return await Task.Run(() => _employeeDbWrapper.Update(existingEmployee));
            }

            return await Task.Run(() => _employeeDbWrapper.Insert(employee));
        }
    }
}