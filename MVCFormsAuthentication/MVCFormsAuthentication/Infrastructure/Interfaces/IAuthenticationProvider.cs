using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFormsAuthentication.Infrastructure.Interfaces
{
    public interface IAuthenticationProvider
    {
        bool Login(string userName, string password);

        void Logout();

        string GetUserIPAddress();

        string GetSessionId();
    }
}
