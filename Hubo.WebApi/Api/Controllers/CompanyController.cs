using System.Threading.Tasks;
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

        public CompanyController()
        {

        }

        [HttpGet]
        public string HelloWorld()
        {
            return "HelloWorld";
        }

        [HttpPost]
        public async Task<AjaxResponse> getCompanyListAsync([FromBody] int driverId)
        {
            return await Task<AjaxResponse>.Run(() => getCompanyList(driverId));
        }

        private AjaxResponse getCompanyList(int driverId)
        {
            AjaxResponse ar = new AjaxResponse();
            CompanyAppService companyService = new CompanyAppService();
            Tuple<List<CompanyOutput>, string, int> result = companyService.GetCompanyList(driverId);

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

