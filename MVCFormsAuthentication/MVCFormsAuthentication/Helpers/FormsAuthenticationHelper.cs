using MVCFormsAuthentication.Infrastructure.Models;
using System;
using System.Configuration;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVCFormsAuthentication.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class FormsAuthenticationHelper
    {

        #region CreateAuthTicket
        /// <summary>
        /// Creates the authentication ticket which will sign in the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userData">The user data.</param>
        public static void CreateAuthTicket(string userName, FFGPrincipalSerializationModel userData)
        {
            CreateAuthTicket(userName, SerializeUserData(userData));
        }

        /// <summary>
        /// Creates the authentication ticket which will sign in the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userData">The user data.</param>
        /// <exception cref="System.Security.SecurityException">Hi there, if you can't log in, it's because you have the domain set for forms authentication.  Nix it and you will once again be able to log in.</exception>
        public static void CreateAuthTicket(string userName, string userData)
        {
            var ctx = HttpContext.Current;
            if (ctx == null)
                return;

            var httpRequest = ctx.Request;
            if (httpRequest == null)
                return;

            // allow custom setting of authentication domain to allow pass-thru authentication of sub-domains
            string authDomain = ConfigurationManager.AppSettings["AuthenticationDomain"];
            //string authDomain = FFG.Properties.Settings.Default.AuthenticationDomain;

            if (string.IsNullOrWhiteSpace(authDomain))
            {
                authDomain = FormsAuthentication.CookieDomain;
            }

            // create the auth cookie
            var cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(
                    new FormsAuthenticationTicket(
                        1,  // version
                        userName,   // name
                        DateTime.Now, // created
                        DateTime.Now.Add(FormsAuthentication.Timeout),  // expires
                        false, // persisted
                        userData // data
                    )
                )
            )
            {
                Domain = authDomain,
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL
            };

            //	if the AuthenticationDomain configuration setting isn't provided, fall back
            if (string.IsNullOrEmpty(authDomain) || (httpRequest.Url != null && httpRequest.Url.Host == "localhost"))
            {
                if (System.Diagnostics.Debugger.IsAttached && !string.IsNullOrEmpty(FormsAuthentication.CookieDomain))
                    throw new System.Security.SecurityException("Hi there, if you can't log in, it's because you have the domain set for forms authentication.  Nix it and you will once again be able to log in.");
            }
            ctx.Response.Cookies.Add(cookie);
        }

        #endregion

        #region Logout
        /// <summary>
        /// Log out a user from the active session. This clear the session cookies and authentication cookies.
        /// </summary>
        public static void Logout()
        {
            var ctx = HttpContext.Current;
            // Clear session cookie 
            ctx.Response.Cookies.Clear();
            // make sure every login gets a new session id created.
            ctx.Session.Clear();
            ctx.Session.Abandon();
            FormsAuthentication.SignOut();
        }
        #endregion

        #region SetCurrentPrincipal
        /// <summary>
        /// Sets the current principal.
        /// </summary>
        public static void SetCurrentPrincipal()
        {
            var context = HttpContext.Current;
            HttpCookie authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var userData = DeserializeUserData(authTicket.UserData);

                FFGPrincipal thisUser = new FFGPrincipal(context.User.Identity);

                if (userData != null)
                {
                    thisUser.DisplayName = userData.DisplayName;
                    thisUser.Roles.AddRange(userData.Roles);
                };

                HttpContext.Current.User = thisUser;
            }
        }
        #endregion

        #region Serialize / Deserialize User Data

        /// <summary>
        /// Serializes the user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns></returns>
        public static string SerializeUserData(FFGPrincipalSerializationModel userData)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(userData);
        }

        /// <summary>
        /// Deserializes the user data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static FFGPrincipalSerializationModel DeserializeUserData(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<FFGPrincipalSerializationModel>(data);
        }
        #endregion

        #region GetLoggedInUserName
        /// <summary>
        /// Gets the name of the logged in user.
        /// </summary>
        /// <returns></returns>
        public static string GetLoggedInUserName()
        {
            var user = HttpContext.Current.User as FFGPrincipal;

            return user != null ? user.DisplayName : string.Empty;
        }
        #endregion

        #region GetLoggedInUserID
        /// <summary>
        /// Gets the logged in user identifier.
        /// </summary>
        /// <returns></returns>
        public static Guid GetLoggedInUserID()
        {
            var user = HttpContext.Current.User as FFGPrincipal;
            return user.Id;
        }
        #endregion

        #region GetLoggedInUser
        /// <summary>
        /// Gets the logged in user.
        /// </summary>
        /// <returns></returns>
        public static FFGPrincipal GetLoggedInUser()
        {
            return HttpContext.Current.User as FFGPrincipal;
        }
        #endregion

    }
}