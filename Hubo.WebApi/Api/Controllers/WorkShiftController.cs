namespace Hubo.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Abp.Web.Models;
    using Abp.WebApi.Controllers;
    using Hubo.Api.Models;
    using Hubo.Companies;
    using Hubo.Shifts;
    using Hubo.Shifts.Dto;
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

    public class WorkShiftController : AbpApiController
    {
        private ShiftAppService _shiftService;

        public WorkShiftController()
        {
            _shiftService = new ShiftAppService();
        }

        //[Authorize]
        //[HttpPost]
        //// create a shift record and return the shift ID to the app
        //public async Task<AjaxResponse> StartShiftAsync([FromBody] WorkShift shift)
        //{
        //    return await Task<AjaxResponse>.Run(() => StartShift(shift));
        //}

        //private AjaxResponse StartShift(WorkShift shift)
        //{
        //    AjaxResponse ar = new AjaxResponse();
        //    Tuple<int, string> result = _shiftService.StartShift(shift);
        //    if (result.Item1 > 0)
        //    {
        //        ar.Result = result.Item1;
        //        ar.Success = true;
        //    }
        //    else
        //    {
        //        ar.Result = result.Item2;
        //        ar.Success = false;
        //    }

        //    return ar;
        //}

        [Authorize]
        [HttpPost]
        // create a shift record and return the shift ID to the app
        public async Task<AjaxResponse> StartShiftAsync([FromBody] WorkShift shift)
        {
            return await Task<AjaxResponse>.Run(() => StartShift(shift));
        }

        private AjaxResponse StartShift(WorkShift shift)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _shiftService.StartShift(shift);
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

        [Authorize]
        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> StopShiftAsync([FromBody] WorkShift shift)
        {
            return await Task<AjaxResponse>.Run(() => StopShift(shift));
        }

        private AjaxResponse StopShift(WorkShift shift)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _shiftService.StopShift(shift);
            if (result.Item1 == 1)
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }
            else
            {
                ar.Success = false;
                //ar.Result = result.Item2;
                ar.Result = "FAILURE!!";
            }
            return ar;

        }

        [Authorize]
        [HttpGet]
        public async Task<AjaxResponse> GetWorkShiftsAsync()
        {
            IEnumerable<string> driverIds;
            if (Request.Headers.TryGetValues("DriverId", out driverIds))
            {
                string driverId = driverIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => GetWorkShifts(Int32.Parse(driverId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse GetWorkShifts(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<WorkShiftDto>, string, int> result = _shiftService.GetWorkShifts(driverId);

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
        [HttpGet]
        public async Task<AjaxResponse> SendReportAsync()
        {
            IEnumerable<string> workShiftIds;
            if (Request.Headers.TryGetValues("WorkShiftId", out workShiftIds))
            {
                string workShiftId = workShiftIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => SendReport(Int32.Parse(workShiftId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse SendReport(int workShiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _shiftService.GeneratePdf(workShiftId);

            if (result.Item1 == 1)
            {
                ar.Success = true;
                ar.Result = result.Item2;
            }
            else
            {
                ar.Success = true;
                ar.Result = result.Item2;
            }

            return ar;
        }

        [Authorize]
        [HttpPost]
        // close off an opern shift by passing in shift ID and closing geo location and time
        public async Task<AjaxResponse> TestGenAsync()
        {
            return await Task<AjaxResponse>.Run(() => TestGen());
        }

        private AjaxResponse TestGen()
        {
            AjaxResponse ar = new AjaxResponse();
            int result = _shiftService.TestGen();
            ar.Success = true;
            return ar;
        }
    }
}

