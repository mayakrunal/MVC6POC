using MVCFormsAuthentication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCFormsAuthentication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // this method is called after a user authenticates with forms authentication.
        // We make a call here to a helper method that sets the thread principal/identity to the authenticated users identity
        // we can then use System.Threading.Thread.CurrentPrincipal to check for authorization when accessing sensitive areas in the server side code
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthenticationHelper.SetCurrentPrincipal();
            }
        }
    }
}
