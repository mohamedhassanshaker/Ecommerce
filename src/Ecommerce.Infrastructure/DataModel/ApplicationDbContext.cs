using Ecommerce.Domian.CartAggregate;
using Ecommerce.Domian.CartAggregate.Entities;
using Ecommerce.Domian.OrderAggregate;
using Ecommerce.Domian.OrderAggregate.Entities;
using Ecommerce.Infrastructure.DataModel.DataSeeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Ecommerce.Infrastructure.DataModel;
public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    //public DbSet<Cart> Carts { get; set; }
    //public DbSet<CartItem> CartItems { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
       
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

}
