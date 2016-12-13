using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Vehicles.DTo
{
    [AutoMap(typeof(Vehicle))]
    public class CreateVehicleInput : IInputDto
    {
        [Required]
        public int UserId { get; set; }

        public string LicenceNo { get; set; }
        public string LicenceVersion { get; set; }
    }
}
