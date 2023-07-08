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
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILoggerFactory logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger.CreateLogger("TodoApi.Controllers.CompanyController"); ;
        }

        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try
            {
                var items = await _companyService.GetAllCompanies();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return null;
            }
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try
            {
                var item = await _companyService.GetCompanyByCode(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return null;
            }

        }

        public async Task<bool> Post([FromBody] CompanyDto companyDto)
        {
            try
            {
                var companyInfo = _mapper.Map<CompanyInfo>(companyDto);
                return await _companyService.AddCompany(companyInfo);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return false;
            }
        }

        // PUT api/<controller>/5
        public async Task<bool> Put(string companyCode, [FromBody] CompanyDto companyDto)
        {
            try
            {
                var companyInfo = _mapper.Map<CompanyInfo>(companyDto);
                companyInfo.CompanyCode = companyCode;
                return await _companyService.UpdateCompany(companyInfo);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return false;
            }
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string companyCode)
        {
            try
            {
                return await _companyService.DeleteCompany(companyCode);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return false;
            }
        }
    }
}