using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Routing
{
  public interface IRoutingBase<T, R,Tcontext> where R: IRepositoryBase<T,Tcontext> 
    where Tcontext:DbContext
  {
    Task MapBase();

  }
}
