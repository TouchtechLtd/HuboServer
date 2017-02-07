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

        [HttpPost]
        public async Task<AjaxResponse> GetBreaksAsync([FromBody] int driveShiftId)
        {
            return await Task<AjaxResponse>.Run(() => GetBreaks(driveShiftId));
        }

        private AjaxResponse GetBreaks(int driveShiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<BreakDto>, string, int> result = _breakAppService.GetBreaks(driveShiftId);

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

        [HttpPost]
        public async Task<AjaxResponse> StopBreakAsync ([FromBody] int breakId)
        {
            return await Task<AjaxResponse>.Run(() => StopBreak(breakId));
        }

        private AjaxResponse StopBreak(int breakId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _breakAppService.StopBreak(breakId);

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
