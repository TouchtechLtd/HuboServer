using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;
using Hubo.Shifts;
using Hubo.Shifts.Dto;
using System.Collections.Generic;
using Hubo.Api.Models;

namespace Hubo.Api.Controllers
{
    public class DayShiftController : AbpApiController
    {
        private ShiftAppService _shiftService;

        public DayShiftController()
        {
            _shiftService = new ShiftAppService();
        }

        [Authorize]
        [HttpPost]
        // create a shift record and return the shift ID to the app
        public async Task<AjaxResponse> StartDayAsync([FromBody] int driverId)
        {
            return await Task<AjaxResponse>.Run(() => StartDay(driverId));
        }

        private AjaxResponse StartDay(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _shiftService.StartDay(driverId);
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
    }
}

