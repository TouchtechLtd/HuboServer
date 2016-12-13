using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace Hubo.Drivers.Dto
{
    [AutoMap(typeof(Driver))]
    public class CreateDriverInput : IInputDto
    {
        [Required]
        public int UserId { get; set; }

        public string LicenceNo { get; set; }
        public string LicenceVersion { get; set; }
    }
}