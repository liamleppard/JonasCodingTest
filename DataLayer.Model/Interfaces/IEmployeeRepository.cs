﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetEmployeeByCode(string employeeCode);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> SaveEmployee(Employee employee);
        Task<bool> DeleteEmployeeByCode(string employeeCode);
    }
}
