using Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConfiger
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts):base(opts)
        {
            
        }
        public DbSet<Order> OrderTable { get; set; }
        public DbSet<OrderItem> OrderItemTable { get; set; }

    }
}
