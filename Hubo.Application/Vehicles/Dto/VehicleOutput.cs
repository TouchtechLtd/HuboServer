using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;

namespace Hubo.Vehicles.Dto
{
    [AutoMap(typeof(Vehicle))]
    public class VehicleOutput : IInputDto
    {
        public string RegistrationNo { get; set; }
        public string MakeModel { get; set; }
        public string FleetNumber { get; set; }
        public long CompanyId { get; set; }
    }
}