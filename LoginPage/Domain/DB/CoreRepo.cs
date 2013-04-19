using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LoginPage.Domain.DB
{
    public class CoreRepo : ICoreRepo
    {
        private EFCoreContext _db = new EFCoreContext();

        public IQueryable<User> users
        {
            get { return _db.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                _db.Users.Add(user);
            }
            else
            {
                _db.Entry(user).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }

        public void deleteUser(User user)
        {
            if (user == null) return;

            _db.Users.Remove(user);

            _db.SaveChanges();
        }
    }
}
