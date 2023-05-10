using Microsoft.EntityFrameworkCore;

namespace Limit_Order_Book.Entities
{
    public class DatabaseContxt : DbContext
    {
        public DatabaseContxt()
        {

        }
        public DatabaseContxt(DbContextOptions<DatabaseContxt> options)
            : base(options) 
        { 
        }

        public virtual DbSet<Orders> Orders { get; set; }
    }
}
