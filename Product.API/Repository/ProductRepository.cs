using Infrastructures.RepositoyImplm;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repository.Interfaces;

namespace Product.API.Repository
{
  public class ProductRepository : RepositoryBase<CatalogProduct, ProductContext>, IProductRepository
  {
    public ProductRepository(ProductContext dbContext) : base(dbContext)
    {
    }
  }
}
