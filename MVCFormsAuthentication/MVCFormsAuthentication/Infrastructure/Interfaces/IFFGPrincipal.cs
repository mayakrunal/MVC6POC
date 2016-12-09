using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MVCFormsAuthentication.Infrastructure.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Security.Principal.IPrincipal" />
    public interface IFFGPrincipal : IPrincipal
    {
        List<string> Roles { get; set; }
        string DisplayName { get; set; }
        Guid Id { get; set; }
    }
}
