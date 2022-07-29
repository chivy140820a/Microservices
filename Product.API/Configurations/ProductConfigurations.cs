using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.API.Entities;

namespace Product.API.Configurations
{
  public class ProductConfigurations : IEntityTypeConfiguration<CatalogProduct>
  {
    public void Configure(EntityTypeBuilder<CatalogProduct> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name);
      builder.Property(x => x.Price);
      builder.Property(x => x.LastPrice);
      builder.Property(x => x.PathImage);
    }
  }
}
