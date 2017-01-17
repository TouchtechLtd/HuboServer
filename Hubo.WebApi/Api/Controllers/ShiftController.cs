using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;
using Hubo.Shifts;

namespace Hubo.Api.Controllers
{
    public class ShiftController : AbpApiController
    {

        public ShiftController()
        {

        }

        [HttpPost]
        // create a shift record and return the shift ID to the app
        public async Task<int> startShiftAsync([FromBody] Shift shift)
        {
            return await Task<int>.Run(() => startShift(shift));
        }

        [HttpPost] 
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<int> endShiftAsync([FromBody] Shift shift)
        {
            return await Task<int>.Run(() => endShift(shift));
        }


        private int startShift(Shift shift)
        {            
            ShiftAppService shiftService = new ShiftAppService();
            return shiftService.StartShift(shift);
        }

        private int endShift(Shift shift)
        {
            ShiftAppService shiftService = new ShiftAppService();
            return shiftService.StopShift(shift);
        }

        
    }
}

