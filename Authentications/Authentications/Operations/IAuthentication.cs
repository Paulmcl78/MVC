using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentications.Models;

namespace Authentications.Operations
{
    public interface IAuthentication
    {
        bool AuthenticateUser(LogOnModel userModel);
    }
}
