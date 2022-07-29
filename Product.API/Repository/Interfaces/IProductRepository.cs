using Contracts.Repositories;
using Product.API.Entities;
using Product.API.Persistence;

namespace Product.API.Repository.Interfaces
{
  public interface IProductRepository:IRepositoryBase<CatalogProduct,ProductContext>
  {

  }
}
