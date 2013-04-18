using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain
{
    public interface IUserRepo
    {
        IQueryable<User> Users { get; }

        void SaveUser(User user);

        void DeleteUser(User user);
    }
}
