using System.Threading.Tasks;
using System.Web.Http;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using System;
using System.Linq;
using Hubo.Companies;

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
        public async Task<AjaxResponse> getCompanyListAsync([FromBody] string driverId)
        {
            return await Task<AjaxResponse>.Run(() => getCompanyList(driverId));
        }



        private AjaxResponse getCompanyList(string driverId)
        {
            AjaxResponse ar = new AjaxResponse();

            CompanyAppService companyService = new CompanyAppService();
            var result = companyService.GetCompanyList(driverId);

            /*
            if (!checkUserNameAndEmail(driver.email, driver.userName))
            {
                return errorResponse(1001, "The email address or user name supplied is already registered");
            }
            */
            

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

