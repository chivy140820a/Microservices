using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.RepositoyImplm
{
  public abstract class RepositoryBase<T,Context> : IRepositoryBase<T,Context> where T : class where Context:DbContext
  {
    private Context _dbContext;

    public RepositoryBase(Context dbContext)
    {
      _dbContext = dbContext;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }
    public virtual async Task<T> GetByGuidId(Guid id)
    {
      return await _dbContext.Set<T>().FindAsync(id);
    }
    public virtual async Task<T> GetByIdNoTracking(int id)
    {
      var et = await _dbContext.Set<T>().FindAsync(id);
      if (et != null)
      {
         _dbContext.Entry(et).State = EntityState.Detached;
      }
      return et;
    }

    public virtual async Task<T> GetByGuidIdNoTracking(Guid id)
    {
      var et = await _dbContext.Set<T>().FindAsync(id);
      if (et != null)
      {
        _dbContext.Entry(et).State = EntityState.Detached;
      }
      return et;
    }
  
    public virtual async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
    {
      return await _dbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> Create(T entity)
    {
      var obj = await _dbContext.Set<T>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();
      return obj.Entity;
    }

    public virtual async Task<T> Update(T entity)
    {
      _dbContext.Entry(entity).State = EntityState.Detached;
      _dbContext.Set<T>().Update(entity);
      await _dbContext.SaveChangesAsync();
      return entity;
    }

    public virtual async Task Delete(T entity)
    {
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }

    public virtual async Task BulkDelete(IEnumerable<T> lstEntity)
    {
      _dbContext.Set<T>().RemoveRange(lstEntity);
      await _dbContext.SaveChangesAsync();
    }

  
  }
}
