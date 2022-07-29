using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Infrastructures.Configurations
{
  public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
  {
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {

      builder.HasKey(x => x.Id);
      builder.Property(x => x.ProductId);
      builder.Property(x => x.TotalPrice);
      builder.Property(x => x.TotalProduct);
      builder.Property(x => x.OrderId);
      builder.HasOne(x => x.OrderCatalog).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
    }
  }
}
