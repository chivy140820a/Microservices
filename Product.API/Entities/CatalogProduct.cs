namespace Product.API.Entities
{
  public class CatalogProduct
  {
    public int Id { get; set; }
    public string Name { get; set; }  
    public decimal Price { get; set; }
    public decimal LastPrice { get; set; }
    public string PathImage { get; set; }
  }
}
