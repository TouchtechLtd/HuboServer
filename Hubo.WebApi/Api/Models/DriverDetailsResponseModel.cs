using Hubo.Drivers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Api.Models
{
    public class DriverDetailsResponseModel
    {
        public DriverOutput driverInfo { get; set; }
        public List<LicenceOutputDto> listOfLicences { get; set; }
    }
}
