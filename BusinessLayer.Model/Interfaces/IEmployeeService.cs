using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllEmployees();
        Task<EmployeeInfo> GetEmployeeByCode(string employeeCode);
        Task<bool> AddEmployee(EmployeeInfo employeeInfo);
        Task<bool> UpdateEmployee(EmployeeInfo employeeInfo);
        Task<bool> DeleteEmployee(string employeeCode);
    }
}
