using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace Hubo.Drivers.Dto
{
    [AutoMap(typeof(Driver))]
    public class DriverOutput : IInputDto
    {
        public long Id { get; set; }

        public string LicenceNo { get; set; }
        public string LicenceVersion { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobilePh { get; set; }
    }
}