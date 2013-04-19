using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Domain
{
    public class EFCoreContext:DbContext
    {
        public EFCoreContext()
        {
            Database.SetInitializer<EFCoreContext>(null);
        }

        public DbSet<User> Users { get; set; }
    }
}
