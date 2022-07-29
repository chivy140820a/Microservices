
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Infrastructures.Configurations
{
  public class OrderConfiguration : IEntityTypeConfiguration<OrderCatalog>
  {
    public void Configure(EntityTypeBuilder<OrderCatalog> builder)
    {

      builder.HasKey(x => x.Id);
      builder.Property(x => x.UserName);
    }
  }
}
