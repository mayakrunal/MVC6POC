using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFormsAuthentication.Infrastructure.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FFGPrincipalSerializationModel
    {
        public List<string> Roles { get; set; }
        public string DisplayName { get; set; }
        public Guid Id { get; set; }
    }
}