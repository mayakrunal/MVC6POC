using MVCFormsAuthentication.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVCFormsAuthentication.Infrastructure.Models
{
   

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MVCFormsAuthentication.Infrastructure.IFFGPrincipal" />
    public class FFGPrincipal : IFFGPrincipal
    {

        public IIdentity Identity { get; private set; }

        public List<string> Roles { get; set; }

        public string DisplayName { get; set; }

        public Guid Id { get; set; }

        public FFGPrincipal(string userName) :
            this(new GenericIdentity(userName))
        { }

        public FFGPrincipal(IIdentity identity)
        {
            Identity = identity;
            Roles = new List<string>();
        }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}