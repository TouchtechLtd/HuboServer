
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using Hubo.EntityFramework;
using Hubo.Vehicles;
using System.Collections.Generic;
using Hubo.Vehicles.Dto;
using System.Linq;

namespace Hubo.Api.Controllers
{
    public class VehiclesController : AbpApiController
    {
        private VehicleAppService _vehicleService;

        public VehiclesController()
        {
            _vehicleService = new VehicleAppService();
        }

        [Authorize]
        [HttpGet]
        public async Task<AjaxResponse> getVehiclesByDriverAsync()
        {
            IEnumerable<string> driverIds;
            if(Request.Headers.TryGetValues("DriverId", out driverIds))
            {
                string driverId = driverIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => getVehiclesByDriver(Int32.Parse(driverId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse getVehiclesByDriver(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<VehicleOutput>, string, int> result = _vehicleService.GetVehiclesByDriver(driverId);

            if (result.Item3 == -1)
            {
                ar.Success = false;
                ar.Result = result.Item2;
                return ar;
            }

            ar.Success = true;
            ar.Result = result.Item1;
            return ar;
        }


        //May no longer be needed as we grab all the vehicles and store them with the driver information

        //[Authorize]
        //[HttpGet]
        //public async Task<AjaxResponse> getVehiclesByCompanyAsync()
        //{
        //    IEnumerable<string> companyIds;
        //    if (Request.Headers.TryGetValues("CompanyId", out companyIds))
        //    {
        //        string companyId = companyIds.FirstOrDefault();
        //        return await Task<AjaxResponse>.Run(() => getVehiclesByCompany(Int32.Parse(companyId)));
        //    }
        //    AjaxResponse ar = new AjaxResponse();
        //    ar.Success = false;
        //    ar.Result = "Invalid Headers";
        //    return ar;
        //}

        //private AjaxResponse getVehiclesByCompany(int companyId)
        //{
        //    AjaxResponse ar = new AjaxResponse();         
        //    Tuple<List<VehicleOutput>, string, int> result = _vehicleService.GetVehiclesByCompany(companyId);

        //    if(result.Item3 == -1)
        //    {
        //        ar.Success = false;
        //        ar.Result = result.Item2;
        //        return ar;
        //    }

        //    ar.Success = true;
        //    ar.Result = result.Item1;
        //    return ar;            
        //}

        [Authorize]
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
