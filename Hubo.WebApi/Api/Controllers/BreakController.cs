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
        public BreakController()
        {

        }

        [HttpPost]
        public async Task<AjaxResponse> GetBreaksAsync([FromBody] int shiftId)
        {
            return await Task<AjaxResponse>.Run(() => GetBreaks(shiftId));
        }

        private AjaxResponse GetBreaks(int shiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            BreakAppService breakService = new BreakAppService();
            Tuple<List<BreakDto>, string, int> result = breakService.GetBreaks(shiftId);

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
            BreakAppService breakService = new BreakAppService();
            Tuple<int, string> result = breakService.StartBreak(newBreak);

            return ar;
        }
    }
}
