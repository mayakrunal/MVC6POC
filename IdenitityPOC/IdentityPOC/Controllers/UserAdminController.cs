using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityPOC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserAdminController : Controller
    {
        // GET: UserAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}