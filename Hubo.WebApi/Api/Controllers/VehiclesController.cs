
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using Hubo.EntityFramework;
using Hubo.Vehicles;
using System.Collections.Generic;
using Hubo.Vehicles.Dto;

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

        [HttpPost]
        public async Task<AjaxResponse> getVehiclesAsync([FromBody] int companyId)
        {
            return await Task<AjaxResponse>.Run(() => getVehicles(companyId));
        }

        private AjaxResponse getVehicles(int companyId)
        {
            AjaxResponse ar = new AjaxResponse();         
            VehicleAppService vehicleService = new VehicleAppService();
            Tuple<List<VehicleOutput>, string, int> result = vehicleService.GetVehicles(companyId);

            if(result.Item3 == -1)
            {
                ar.Success = false;
                ar.Result = result.Item2;
                return ar;
            }

            ar.Success = true;
            ar.Result = result.Item1;
            return ar;            
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
