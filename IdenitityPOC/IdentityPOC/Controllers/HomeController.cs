using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityPOC.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        #endregion

        #region Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        } 
        #endregion
    }
}