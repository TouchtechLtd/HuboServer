﻿using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;
using System.Collections.Generic;
using Newtonsoft.Json;
using Hubo.Companies.Dto;

namespace Hubo.Api.Controllers
{
    public class CompanyController : AbpApiController
    {
        private CompanyAppService _companyAppService;

        public CompanyController()
        {
            _companyAppService = new CompanyAppService();
        }

        [Authorize]
        [HttpGet]
        public async Task<AjaxResponse> getCompanyListAsync()
        {
            IEnumerable<string> driverIds;
            if (Request.Headers.TryGetValues("DriverId", out driverIds))
            {
                string driverId = driverIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => getCompanyList(Int32.Parse(driverId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse getCompanyList(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<CompanyOutput>, string, int> result = _companyAppService.GetCompanyList(driverId);

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

        // create a custom error object to return in an AjaxResponse
        private AjaxResponse errorResponse(int code, string message)
        {
            AjaxResponse ar = new AjaxResponse();
            ErrorInfo info = new ErrorInfo();

            info.Code = code;
            info.Message = message;

            ar.Error = info;
            ar.Success = false;
            ar.Result = null;

            return ar;
        }
    }
}

