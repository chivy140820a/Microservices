using Product.API.Repository.Interfaces;
using Product.API.Routing.ItemRoutings;
using Product.API.Routing.ItemRoutings.Interfaces;

namespace Product.API.Routing.RoutingWrapper
{
  public interface IRoutingWrapper
  {
    void MapAll();
    IProductRouting ProductRouting { get; }

  }
  public class RoutingWrapper : IRoutingWrapper
  {
    private IProductRouting _productRouting;
    private IServiceProvider _provider;
    private WebApplication app { get; set; }
    public RoutingWrapper(WebApplication app, IServiceProvider provider)
    {
      _provider = provider;
      this.app = app;
    }
    public IProductRouting ProductRouting
    {
      get
      {
        if (_productRouting == null)
        {
          _productRouting = new ProductRouting(app, _provider.GetRequiredService<IProductRepository>());
        }

        return _productRouting;
      }
    }

    public void MapAll()
    {
      ProductRouting.MapAll();
    }
  }
}
