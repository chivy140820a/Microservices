
using Microsoft.EntityFrameworkCore;
using Product.API.Configurations;
using Product.API.Entities;

namespace Product.API.Persistence
{
  public class ProductContext:DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
      
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ProductConfigurations());
      base.OnModelCreating(modelBuilder);
    }
    public DbSet<CatalogProduct> CatalogProducts { get; set; }
  }
}
