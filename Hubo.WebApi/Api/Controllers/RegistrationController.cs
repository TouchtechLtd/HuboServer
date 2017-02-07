using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Drivers;


namespace Hubo.Api.Controllers
{
    public class RegistrationController : AbpApiController
    {
        private DriverAppService _driverService;

        public RegistrationController()
        {
            _driverService = new DriverAppService();
        }

        [HttpPost]
        public async Task<AjaxResponse> registerAsync([FromBody] Driver driver)
        {
            return await Task<AjaxResponse>.Run(() => registerDriver(driver));
        }

        
        private AjaxResponse registerDriver(Driver driver)
        {
            AjaxResponse ar = new AjaxResponse();
            var result = _driverService.RegisterDriver(driver);
            ar.Result = result;
            return ar;
        }

        


    }
}
