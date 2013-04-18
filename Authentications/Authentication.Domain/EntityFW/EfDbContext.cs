using System.Data.Entity;

namespace Authentication.Domain
{
    public class EfDbContext:DbContext
    {
        public EfDbContext()
        {
            Database.SetInitializer<EfDbContext>(null);
        }
        public DbSet<User> Users { get; set; }
    }
}
