using MVCFormsAuthentication.Helpers;
using MVCFormsAuthentication.Infrastructure.Interfaces;
using MVCFormsAuthentication.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVCFormsAuthentication.Infrastructure.Providers
{
    public class AuthenticationProvider : IAuthenticationProvider
    {

        #region Login
        /// <summary>
        /// Logins the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                return false;
            }

            //Put the validation Logic call the web api 

            if (!(userName == "kparekh" && password == "test"))
            {
                return false;
            }
            //First SignOut from the current user if already logged in
            FormsAuthenticationHelper.Logout();

            FFGPrincipalSerializationModel userData = new FFGPrincipalSerializationModel()
            {
                DisplayName = userName,
                Roles = new List<string>() { "User" },
                Id = new Guid()
            };

            FormsAuthenticationHelper.CreateAuthTicket(userName, userData);

            return true;
        }
        #endregion

        #region Logout

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            FormsAuthenticationHelper.Logout();
        }
        #endregion

        #region GetUserIPAddress
        /// <summary>
        /// Get the IP address of the user who access the application.
        /// </summary>
        /// <returns></returns>
        public string GetUserIPAddress()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion

        #region GetSessionId
        /// <summary>
        /// Get the current session id.
        /// </summary>
        /// <returns></returns>
        public string GetSessionId()
        {
            return HttpContext.Current.Session["UserSessionId"] != null ? HttpContext.Current.Session["UserSessionId"].ToString() : null;
        }
        #endregion
    }
}