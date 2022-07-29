namespace OnlineShop.API.Entities
{
  public class OrderDetails
  {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TotalProduct { get; set; }
    public int TotalPrice { get; set; }
  }
}
