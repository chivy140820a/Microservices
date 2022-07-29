namespace Order.Domain.Entities
{
  public class OrderDetail
  {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TotalProduct { get; set; }
    public int TotalPrice { get; set; }
    public int OrderId { get; set; }
    public OrderCatalog OrderCatalog { get; set; }
  }
}
