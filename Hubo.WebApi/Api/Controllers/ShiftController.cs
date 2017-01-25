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
        public async Task<int> StartShiftAsync([FromBody] Shift shift)
        {
            return await Task<int>.Run(() => StartShift(shift));
        }

        [HttpPost] 
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<int> EndShiftAsync([FromBody] Shift shift)
        {
            return await Task<int>.Run(() => EndShift(shift));
        }

        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<int> StartBreakAsync([FromBody] Break shiftBreak)
        {
            return await Task<int>.Run(() => StartBreak(shiftBreak));
        }

        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<int> EndBreakAsync([FromBody] Break shiftBreak)
        {
            return await Task<int>.Run(() => EndBreak(shiftBreak));
        }

        private int StartShift(Shift shift)
        {            
            ShiftAppService shiftService = new ShiftAppService();
            //return shiftService.StartShift(shift);
            return 0;
        }

        private int EndShift(Shift shift)
        {
            ShiftAppService shiftService = new ShiftAppService();
            //return shiftService.StopShift(shift);
            return 0;

        }

        private int StartBreak(Break shiftBreak)
        {
            ShiftAppService shiftService = new ShiftAppService();
            //return shiftService.StartBreak(shiftBreak);
            return 0;

        }

        private int EndBreak(Break shiftBreak)
        {
            ShiftAppService shiftService = new ShiftAppService();
            //return shiftService.EndBreak(shiftBreak);
            return 0;

        }
    }
}

