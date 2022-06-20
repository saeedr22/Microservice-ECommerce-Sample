using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Data
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrdersDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
