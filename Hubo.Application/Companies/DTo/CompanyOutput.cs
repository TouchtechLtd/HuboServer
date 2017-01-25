using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace Hubo.Companies.Dto
{
    [AutoMap(typeof(Company))]
    public class CompanyOutput : IInputDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}