using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repository.Interfaces;
using Product.API.Routing.ItemRoutings.Interfaces;

namespace Product.API.Routing.ItemRoutings
{
  public class ProductRouting : RoutingBase<CatalogProduct, IProductRepository, ProductContext>, IProductRouting
  {
    public ProductRouting(WebApplication app, IProductRepository repository) : base(app, repository)
    {
    }

    public async Task MapAll()
    {
      await MapBase();
    }
  }
}
