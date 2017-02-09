using System;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Authorization.Users;
using Abp.UI;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Hubo.Api.Models;
using Hubo.Authorization.Roles;
using Hubo.MultiTenancy;
using Hubo.Users;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Hubo.Drivers;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Hubo.ApiResponseClasses;
using System.Linq;
using Hubo.Drivers.Dto;

namespace Hubo.Api.Controllers
{
    public class AccountController : AbpApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        private readonly UserManager _userManager;
        private DriverAppService _driverService;

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            
        }

        public AccountController(UserManager userManager)
        {
            _userManager = userManager;
            _driverService = new DriverAppService();
        }

        [HttpGet]
        public async Task<AjaxResponse> GetDriverDetailsAsync()
        {
            IEnumerable<string> userIds;
            if(Request.Headers.TryGetValues("UserId", out userIds))
            {
                string userId = userIds.FirstOrDefault();
                return await Task<AjaxResponse>.Run(() => GetDriverDetails(Int32.Parse(userId)));
            }
            AjaxResponse ar = new AjaxResponse();
            ar.Success = false;
            ar.Result = "Invalid Headers";
            return ar;
        }

        private AjaxResponse GetDriverDetails(int userId)
        {
            AjaxResponse ar = new AjaxResponse();

            Tuple<DriverOutput,List<LicenceOutputDto>, int, string> driverResult = _driverService.GetDriverDetails(userId);
            
            if(driverResult.Item3 < 1)
            {
                ar.Success = false;
                ar.Result = driverResult.Item3;
            }
            else
            {
                DriverDetailsResponseModel response = new DriverDetailsResponseModel();
                response.driverInfo = driverResult.Item1;
                response.listOfLicences = driverResult.Item2;
                ar.Result = response;
            }

            return ar;
        }

        [HttpPost]
        public async Task<AjaxResponse> Authenticate(LoginModel loginModel)
        {
            CheckModelState();

            var loginResult = await GetLoginResultAsync(
                loginModel.UsernameOrEmailAddress,
                loginModel.Password,
                loginModel.TenancyName
                );            

            var ticket = new AuthenticationTicket(loginResult.Identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromDays(60));
            string token = OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            LoginResponse response = new LoginResponse();
            response.Id = loginResult.User.Id;
            response.FirstName = loginResult.User.Name;
            response.SurName = loginResult.User.Surname;
            response.EmailAddress = loginResult.User.EmailAddress;
            response.DriverId = _driverService.GetDriverId(loginResult.User.Id);
            response.Token = token;

            AjaxResponse ar = new AjaxResponse();
            ar.Result = response;
            return ar;
        }

        private async Task<AbpUserManager<Tenant, Role, User>.AbpLoginResult> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _userManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private Exception CreateExceptionForFailedLoginAttempt(AbpLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case AbpLoginResultType.Success:
                    return new ApplicationException("Don't call this method with a success result!");
                case AbpLoginResultType.InvalidUserNameOrEmailAddress:
                case AbpLoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case AbpLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException(L("LoginFailed"), L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                case AbpLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("TenantIsNotActive", tenancyName));
                case AbpLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case AbpLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), "Your email address is not confirmed. You can not login"); //TODO: localize message
                default: //Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            }
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException("Invalid request!");
            }
        }
    }
}
