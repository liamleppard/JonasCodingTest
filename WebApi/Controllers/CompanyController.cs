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
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = await _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        public async Task Post([FromBody] CompanyDto companyDto)
        {
            var companyInfo = _mapper.Map<CompanyInfo>(companyDto);
            await _companyService.AddCompany(companyInfo);
        }

        // PUT api/<controller>/5
        public async Task Put(string companyCode, [FromBody] CompanyDto companyDto)
        {
            var companyInfo = _mapper.Map<CompanyInfo>(companyDto);
            companyInfo.CompanyCode = companyCode;
            await _companyService.UpdateCompany(companyInfo);
        }

        // DELETE api/<controller>/5
        public async Task Delete(string companyCode)
        {
            await _companyService.DeleteCompany(companyCode);
        }
    }
}