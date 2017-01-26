using System.Collections.Generic;

namespace Hubo
{
    public class LoginResponse
    {
        public object Driver { get; set;}   
        public List<CompanyAndVehicles> CompaniesAndVehicle { get; set; }
    }

    public class CompanyAndVehicles
    {
        public object Company { get; set; }
        public List<object> Vehicles { get; set; }
    }
}
