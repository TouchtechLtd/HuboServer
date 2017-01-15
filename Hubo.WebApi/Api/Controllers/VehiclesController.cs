
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using Hubo.EntityFramework;
using Hubo.Vehicles;

namespace Hubo.Api.Controllers
{
    public class VehiclesController : AbpApiController
    {

        public VehiclesController()
        {
            
        }

        [HttpGet]
        public string HelloWorld()
        {
            return "Hello World";
        }


        // registration, make, model, odo, company
        [HttpPost]
        public async Task<AjaxResponse> registerVehicleAsync([FromBody] Vehicle vehicle)
        {
            Vehicle v = vehicle;
            return await Task<AjaxResponse>.Run(() => registerVehicle(vehicle));
        }

        //[HttpPost]
        //public async Task<AjaxResponse> getVehiclesFromCompanyAsync()
        //{

        //}


        // accept incoming JSON string, converted to Vehicle object, and saved
        private AjaxResponse registerVehicle(Vehicle vehicle)
        {
            AjaxResponse ar = new AjaxResponse();

            VehicleAppService vehicleService = new VehicleAppService();
            var result = vehicleService.RegisterVehicle(vehicle);

            ar.Result = result;

            return ar;
        }






    }
}
