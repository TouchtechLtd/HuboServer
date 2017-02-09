﻿using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;
using Hubo.Shifts;
using System.Collections.Generic;
using Hubo.Shifts.Dto;
using Hubo.Breaks;
using Hubo.Breaks.Dto;

namespace Hubo.Api.Controllers
{
    public class BreakController : AbpApiController
    {
        private BreakAppService _breakAppService;

        public BreakController()
        {
            _breakAppService = new BreakAppService();
        }

        //NOTE: This was retriving through driveShiftId, would have had to make multiple calls

        //[Authorize]
        //[HttpGet]
        //public async Task<AjaxResponse> GetBreaksAsync()
        //{
        //    IEnumerable<string> driveShiftIds;
        //    if(Request.Headers.TryGetValues("DriveShiftId", out driveShiftIds))
        //    {
        //        string driveShiftId = driveShiftIds.FirstOrDefault();
        //        return await Task<AjaxResponse>.Run(() => GetBreaks(Int32.Parse(driveShiftId)));
        //    }
        //    AjaxResponse ar = new AjaxResponse();
        //    ar.Success = false;
        //    ar.Result = "Invalid Headers";
        //    return ar;
        //}

        //private AjaxResponse GetBreaks(int driveShiftId)
        //{
        //    AjaxResponse ar = new AjaxResponse();
        //    Tuple<List<BreakDto>, string, int> result = _breakAppService.GetBreaks(driveShiftId);

        //    if (result.Item3 == -1)
        //    {
        //        ar.Success = false;
        //        ar.Result = result.Item2;
        //    }
        //    else
        //    {
        //        ar.Success = true;
        //        ar.Result = result.Item1;
        //    }

        //    return ar;
        //}

        [Authorize]
        [HttpGet]
        public async Task<AjaxResponse> GetBreaksAsync()
        {
            IEnumerable<string> driverIds;
            if (Request.Headers.TryGetValues("DriverId", out driverIds))
            {
                string driverId = driverIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => GetBreaks(Int32.Parse(driverId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse GetBreaks(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<BreakDto>, string, int> result = _breakAppService.GetBreaks(driverId);

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

        [Authorize]
        [HttpPost]
        public async Task<AjaxResponse> StartBreakAsync ([FromBody] Break newBreak)
        {
            return await Task<AjaxResponse>.Run(() => StartBreak(newBreak));
        }

        private AjaxResponse StartBreak(Break newBreak)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _breakAppService.StartBreak(newBreak);

            if(result.Item1 > 0)
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

        [Authorize]
        [HttpPost]
        public async Task<AjaxResponse> StopBreakAsync ([FromBody] Break stopBreak)
        {
            return await Task<AjaxResponse>.Run(() => StopBreak(stopBreak));
        }

        private AjaxResponse StopBreak(Break stopBreak)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _breakAppService.StopBreak(stopBreak);

            if(result.Item1 == -1)
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }
            else
            {
                ar.Success = true;
            }

            return ar;
        }
    }
}
