using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Hubo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : HuboControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}