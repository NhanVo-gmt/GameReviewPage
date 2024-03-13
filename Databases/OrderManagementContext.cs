using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Contexts 
{
    public class OrderManagementContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products {get; set;}

        public OrderManagementContext (DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}