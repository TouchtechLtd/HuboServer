using Abp.Domain.Repositories;
using AutoMapper;
using Hubo.Companies.Dto;
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

        public Tuple<List<CompanyOutput>, string, int> GetCompanyList(int driverId)
        {
            Tuple<List<Company>, string, int> result = _companyRepository.GetCompanyList(driverId);
            List<CompanyOutput> listCompanyDtoOutput = new List<CompanyOutput>();
            foreach(Company company in result.Item1)
            {                
                listCompanyDtoOutput.Add(Mapper.Map<Company, CompanyOutput>(company));
            }

            return Tuple.Create(listCompanyDtoOutput, result.Item2, result.Item3);
        }
    }
}
