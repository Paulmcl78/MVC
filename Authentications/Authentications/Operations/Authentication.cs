using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Domain;
using Authentications.Models;
using Authentications.Operations;

namespace Authentication.Operations
{
    public class Authentication : IAuthentication
    {
        private IUserRepo _repo;

        public Authentication(IUserRepo Repo)
        {
            _repo = Repo;
        }

        public bool AuthenticateUser(LogOnModel userModel)
        {
            User user = _repo.Users.FirstOrDefault(u => u.UserName == userModel.UserName);

            if (user == null)
            {
                return false;
            }

            if (!user.Password.Equals(userModel.Password))
            {
                return false;
            }

            return true;

        }
    }
}
