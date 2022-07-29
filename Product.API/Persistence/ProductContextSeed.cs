using Product.API.Entities;

namespace Product.API.Persistence
{
  public class ProductContextSeed
  {
    public static async Task SeedProductAsync(ProductContext productContext)
    {
      if (!productContext.CatalogProducts.Any())
      {
        productContext.AddRange(getCatalogProducts());
        await productContext.SaveChangesAsync();
      }
    }

    private static IEnumerable<CatalogProduct> getCatalogProducts()
    {
      return new List<CatalogProduct>
        {
            new()
            {
               Name = $"Product1",
               Price=1,
               LastPrice=1,
               PathImage = "demo"
            },
            new()
            {
               Name = $"Product1",
               Price=1,
               LastPrice=1,
               PathImage = "demo"
            }
        };
    }
  }
}
