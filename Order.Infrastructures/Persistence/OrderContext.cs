
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Infrastructures.Configurations;

namespace Order.Infrastructures.Persistence
{
  public class OrderContext : DbContext
  {
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new OrderConfiguration());
      modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
      base.OnModelCreating(modelBuilder);
    }
    public DbSet<OrderCatalog> OrderCatalogs { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
  }
}
