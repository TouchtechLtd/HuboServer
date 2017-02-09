using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.ApiResponseClasses
{
    public class LoginResponse
    {
        public long Id { get; set; }
        public long DriverId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string EmailAddress { get; set; }

        public string Token { get; set; }
    }
}
