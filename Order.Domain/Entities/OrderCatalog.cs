
namespace Order.Domain.Entities
{
  public class OrderCatalog
  {
    public int Id { get; set; }
    public string UserName { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
  }
}
