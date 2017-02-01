using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;
using Hubo.Shifts;
using Hubo.ApiRequestClasses;
using System.Collections.Generic;
using Hubo.Shifts.Dto;

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

        private AjaxResponse StartShift(ShiftStartRequest shift)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.StartShift(shift);
            if (result.Item1 > 0)
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

        [HttpPost] 
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> EndShiftAsync([FromBody] ShiftStopRequest shift)
        {
            return await Task<AjaxResponse>.Run(() => EndShift(shift));
        }

        private AjaxResponse EndShift(ShiftStopRequest shift)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.StopShift(shift);
            if (result.Item1 == 1)
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

        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> StartBreakAsync([FromBody] BreakStartRequest shiftBreak)
        {
            return await Task<AjaxResponse>.Run(() => StartBreak(shiftBreak));
        }

        private AjaxResponse StartBreak(BreakStartRequest shiftBreak)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.StartBreak(shiftBreak);
            if (result.Item1 > 0)
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

        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> EndBreakAsync([FromBody] BreakEndRequest shiftBreak)
        {
            return await Task<AjaxResponse>.Run(() => EndBreak(shiftBreak));
        }

        private AjaxResponse EndBreak(BreakEndRequest shiftBreak)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<int, string> result = shiftService.EndBreak(shiftBreak);

            if (result.Item1 == 1)
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

        [HttpPost]
        public async Task<AjaxResponse> GetWorkShiftsAsync([FromBody] int driverId)
        {
            return await Task<AjaxResponse>.Run(() => GetWorkShifts(driverId));
        }

        private AjaxResponse GetWorkShifts(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<List<WorkShiftDto>, string, int> result = shiftService.GetWorkShifts(driverId);

            if (result.Item3 == -1)
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }
            else
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }

            return ar;
        }

        [HttpPost]
        public async Task<AjaxResponse> GetDrivingShiftsAsync([FromBody] int shiftId)
        {
            return await Task<AjaxResponse>.Run(() => GetDrivingShifts(shiftId));
        }

        private AjaxResponse GetDrivingShifts(int shiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            ShiftAppService shiftService = new ShiftAppService();
            Tuple<List<DrivingShiftDto>, string, int> result = shiftService.GetDrivingShifts(shiftId);

            if(result.Item3 == -1)
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }
            else
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }

            return ar;
        }


    }
}

