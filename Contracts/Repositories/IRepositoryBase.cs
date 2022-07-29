using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
  public interface IRepositoryBase<T,Context> where Context:DbContext
  {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> GetByGuidId(Guid id);
    Task<T> GetByIdNoTracking(int id);
    Task<T> GetByGuidIdNoTracking(Guid id);

    Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task Delete(T entity);
    Task BulkDelete(IEnumerable<T> lstEntity);
  }
}
