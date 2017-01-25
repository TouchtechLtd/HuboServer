using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace Hubo.Drivers.Dto
{
    [AutoMap(typeof(Vehicle))]
    public class VehicleOutput : IInputDto
    {
        public string RegistrationNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int StartingOdometer { get; set; }
        public int CurrentOdometer { get; set; }
        public long CompanyId { get; set; }
    }
}