using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Security;
using Nop.Core.Domain.Customers;

namespace Nop.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        private readonly IWorkContext _workContext;

        public HomeController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        [HttpsRequirement(SslRequirement.No)]
        public virtual IActionResult Index()
        {
            if (_workContext.CurrentCustomer.IsGuest())
            {
                return RedirectToRoute("Login");
            }
            return View();
        }
    }
}