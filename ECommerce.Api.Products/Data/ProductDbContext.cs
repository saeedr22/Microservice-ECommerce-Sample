using System;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}