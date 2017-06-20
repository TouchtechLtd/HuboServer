namespace Hubo.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Abp.Web.Models;
    using Abp.WebApi.Controllers;
    using Hubo.EntityFramework;
    using Hubo.Vehicles;
    using Hubo.Vehicles.Dto;
    using System.Drawing.Imaging;
    using System.Reflection;
    using System.Windows.Forms;

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

        [Authorize]
        [HttpPost]
        public async Task<AjaxResponse> regoPhotoAsync([FromBody] RegoString base64Photo)
        {
            return await Task<AjaxResponse>.Run(() => regoPhoto(base64Photo));
        }

        private async Task<AjaxResponse> regoPhoto(RegoString base64Photo)
        {
            AjaxResponse ar = new AjaxResponse();
            byte[] imageBytes = Convert.FromBase64String(base64Photo.RegoText);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            base64Photo.RegoImage = image;
            image.Save(@"C://HuboPictures//writelines.jpeg", ImageFormat.Jpeg);

            List<string> results = await _vehicleService.MicrosoftOCRCallAsync(image);
            ar.Result = results;

            return ar;
        }

        [Authorize]
        [HttpPost]
        public async Task<AjaxResponse> registerVehicleAsync([FromBody] Vehicle vehicle)
        {
            return await Task<AjaxResponse>.Run(() => registerVehicle(vehicle));
        }

        private AjaxResponse registerVehicle(Vehicle vehicle)
        {
            AjaxResponse ar = new AjaxResponse();

            Tuple<int, string> result = _vehicleService.RegisterVehicle(vehicle);

            if (result.Item1 == -1)
            {
                ar.Result = result.Item2;
                ar.Success = false;
            }
            else
            {
                ar.Result = result.Item1;
            }

            return ar;
        }






    }
}
