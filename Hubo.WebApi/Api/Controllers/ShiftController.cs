using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;

namespace Hubo.Api.Controllers
{
    public class ShiftController : AbpApiController
    {

        public ShiftController()
        {

        }

        [HttpPost]
        // create a shift record and return the shift ID to the app
        public async Task<AjaxResponse> startShiftAsync([FromBody] Shift shift)
        {
            return await Task<AjaxResponse>.Run(() => startShift(shift));
        }

        [HttpPost] 
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> endShiftAsync([FromBody] Shift shift)
        {
            return await Task<AjaxResponse>.Run(() => endShift(shift));
        }


        private AjaxResponse startShift(Shift shift)
        {
            AjaxResponse ar = new AjaxResponse();

          

            return ar;
        }

        private AjaxResponse endShift(Shift shift)
        {
            AjaxResponse ar = new AjaxResponse();



            return ar;
        }

        
    }
}

