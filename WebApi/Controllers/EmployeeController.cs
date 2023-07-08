using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILoggerFactory logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger.CreateLogger("TodoApi.Controllers.EmployeeController");
        }

        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            try
            {
                var items = await _employeeService.GetAllEmployees();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return null;
            }
        }

        // GET api/<controller>/5
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            try
            {
                var item = await _employeeService.GetEmployeeByCode(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return null;
            }
        }

        public async Task<bool> Post([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var employeeInfo = _mapper.Map<EmployeeInfo>(employeeDto);
                return await _employeeService.AddEmployee(employeeInfo);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return false;
            }
        }

        // PUT api/<controller>/5
        public async Task<bool> Put(string employeeCode, [FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var employeeInfo = _mapper.Map<EmployeeInfo>(employeeDto);
                employeeInfo.EmployeeCode = employeeCode;
                return await _employeeService.UpdateEmployee(employeeInfo);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return false;
            }
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string employeeCode)
        {
            try
            {
                return await _employeeService.DeleteEmployee(employeeCode);
            }

            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return false;
            }
        }
    }
}