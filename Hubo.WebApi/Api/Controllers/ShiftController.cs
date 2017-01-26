using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;
using Hubo.Shifts;
using Hubo.ApiRequestClasses;

namespace Hubo.Api.Controllers
{
    public class ShiftController : AbpApiController
    {

        public ShiftController()
        {

        }

        [HttpPost]
        // create a shift record and return the shift ID to the app
        public async Task<AjaxResponse> StartShiftAsync([FromBody] ShiftStartRequest shift)
        {
            return await Task<AjaxResponse>.Run(() => StartShift(shift));
        }

        [HttpPost] 
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> EndShiftAsync([FromBody] ShiftStopRequest shift)
        {
            return await Task<AjaxResponse>.Run(() => EndShift(shift));
        }

        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> StartBreakAsync([FromBody] BreakStartRequest shiftBreak)
        {
            return await Task<AjaxResponse>.Run(() => StartBreak(shiftBreak));
        }

        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> EndBreakAsync([FromBody] BreakEndRequest shiftBreak)
        {
            return await Task<AjaxResponse>.Run(() => EndBreak(shiftBreak));
        }

        private AjaxResponse StartShift(ShiftStartRequest shift)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int,string> result = shiftService.StartShift(shift);
            if(result.Item1>0)
            {
                ar.Result = result.Item1;
                ar.Success = true;
            }
            else
            {
                ar.Result = result.Item2;
                ar.Success = false;
            }
            return ar;
        }

        private AjaxResponse EndShift(ShiftStopRequest shift)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.StopShift(shift);
            if(result.Item1==1)
            {
                ar.Success = true;                                
            }
            else
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }            
            return ar;

        }

        private AjaxResponse StartBreak(BreakStartRequest shiftBreak)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.StartBreak(shiftBreak);
            if(result.Item1>0)
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }
            else
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }
            return ar;
        }

        private AjaxResponse EndBreak(BreakEndRequest shiftBreak)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.EndBreak(shiftBreak);
            
            if(result.Item1 == 1)
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }
            else
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }
            return ar;

        }
    }
}

