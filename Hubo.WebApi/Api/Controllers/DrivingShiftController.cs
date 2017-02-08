﻿using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Hubo.DrivingShifts;
using Hubo.Shifts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hubo.Api.Controllers
{
    public class DrivingShiftController : AbpApiController
    {
        private DrivingShiftAppService _drivingShiftAppService;
        public DrivingShiftController()
        {
            _drivingShiftAppService = new DrivingShiftAppService();
        }

        [Authorize]
        [HttpGet]
        public async Task<AjaxResponse> GetDrivingShiftsAsync()
        {
            IEnumerable<string> shiftIds;
            if (Request.Headers.TryGetValues("ShiftId", out shiftIds))
            {
                string shiftId = shiftIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => GetDrivingShifts(Int32.Parse(shiftId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;

        }

        private AjaxResponse GetDrivingShifts(int shiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<DrivingShiftDto>, string, int> result = _drivingShiftAppService.GetDrivingShifts(shiftId);

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
        public async Task<AjaxResponse> StartDrivingAsync([FromBody] DrivingShift shift)
        {
            return await Task<AjaxResponse>.Run(() => StartDriving(shift));
        }

        private AjaxResponse StartDriving(DrivingShift shift)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _drivingShiftAppService.StartDriving(shift);

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
        [HttpPut]
        public async Task<AjaxResponse> StopDrivingAsync()
        {
            IEnumerable<string> drivingShiftIds;
            if (Request.Headers.TryGetValues("DriverShiftId", out drivingShiftIds))
            {
                string drivingShiftId = drivingShiftIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => StopDriving(Int32.Parse(drivingShiftId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse StopDriving(int drivingShiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _drivingShiftAppService.StopDriving(drivingShiftId);

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

        [Authorize]
        [HttpPost]
        public async Task<AjaxResponse> InsertGeoPointAsync(GeoData geoData)
        {
            return await Task<AjaxResponse>.Run(() => InsertGeoPoint(geoData));
        }

        private AjaxResponse InsertGeoPoint(GeoData geoData)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _drivingShiftAppService.InsertGeoData(geoData);
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
    }
}
