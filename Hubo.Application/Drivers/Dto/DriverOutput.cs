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
        public long UserId { get; set; }
        public int PhoneNumber { get; set; }
        public string LicenceNumber { get; set; }
        public string LicenceVersion { get; set; }
        public string LicenceEndorsement { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}