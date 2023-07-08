using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var items = await _employeeService.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            var item = await _employeeService.GetEmployeeByCode(employeeCode);
            return _mapper.Map<EmployeeDto>(item);
        }

        public async Task Post([FromBody] EmployeeDto employeeDto)
        {
            var employeeInfo = _mapper.Map<EmployeeInfo>(employeeDto);
            await _employeeService.AddEmployee(employeeInfo);
        }

        // PUT api/<controller>/5
        public async Task Put(string employeeCode, [FromBody] EmployeeDto employeeDto)
        {
            var employeeInfo = _mapper.Map<EmployeeInfo>(employeeDto);
            employeeInfo.EmployeeCode = employeeCode;
            await _employeeService.UpdateEmployee(employeeInfo);
        }

        // DELETE api/<controller>/5
        public async Task Delete(string employeeCode)
        {
            await _employeeService.DeleteEmployee(employeeCode);
        }
    }
}