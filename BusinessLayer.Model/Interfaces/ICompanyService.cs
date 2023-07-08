using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        Task<bool> AddCompany(CompanyInfo companyInfo);
        Task<bool> UpdateCompany(CompanyInfo companyInfo);
        Task<bool> DeleteCompany(string companyCode);
    }
}