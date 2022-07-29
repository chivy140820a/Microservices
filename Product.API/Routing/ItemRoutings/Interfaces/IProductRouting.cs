using Contracts.Routing;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repository.Interfaces;

namespace Product.API.Routing.ItemRoutings.Interfaces
{
  public interface IProductRouting: IRoutingBase<CatalogProduct, IProductRepository, ProductContext>
  {
    Task MapAll();
  }
}
