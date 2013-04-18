using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain
{
    public class UserRepo :IUserRepo
    {
        private EfDbContext context = new EfDbContext();

        public IQueryable<User> Users { get { return context.Users; } }


        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
