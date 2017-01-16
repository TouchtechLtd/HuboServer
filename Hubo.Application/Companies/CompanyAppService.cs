using Abp.Domain.Repositories;
using Hubo.EntityFramework;
using Hubo.Respositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hubo.Companies
{
    public class CompanyAppService
    {
        private CompanyRepository _companyRepository;

        public CompanyAppService()
        {
            _companyRepository = new EntityFramework.CompanyRepository();
        }

        public List<Company> GetCompanyList(Driver driver)
        {
            List<Company> result = new List<Company>();
            result = _companyRepository.GetCompanyList(driver);

            return result;
        }
    }
}
