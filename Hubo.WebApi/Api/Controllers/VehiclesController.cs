
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
        private VehicleAppService _vehicleService;

        public VehiclesController()
        {
            _vehicleService = new VehicleAppService();
        }

        [HttpPost]
        public async Task<AjaxResponse> getVehiclesAsync([FromBody] int companyId)
        {
            return await Task<AjaxResponse>.Run(() => getVehicles(companyId));
        }

        private AjaxResponse getVehicles(int companyId)
        {
            AjaxResponse ar = new AjaxResponse();         
            Tuple<List<VehicleOutput>, string, int> result = _vehicleService.GetVehicles(companyId);

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

        [HttpPost]
        public async Task<AjaxResponse> registerVehicleAsync([FromBody] Vehicle vehicle)
        {
            return await Task<AjaxResponse>.Run(() => registerVehicle(vehicle));
        }

        private AjaxResponse registerVehicle(Vehicle vehicle)
        {
            AjaxResponse ar = new AjaxResponse();

            var result = _vehicleService.RegisterVehicle(vehicle);

            ar.Result = result;

            return ar;
        }






    }
}
