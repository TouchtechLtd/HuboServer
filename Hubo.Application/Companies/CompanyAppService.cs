using Abp.Domain.Repositories;
using Hubo.EntityFramework;
using Hubo.Respositories;
using System;
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

        public object GetCompanyList(string driverId)
        {
            var result = _companyRepository.GetCompanyList(driverId);

            return result;
        }
    }
}
