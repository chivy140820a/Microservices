using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructures.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructures
{
  public static class ConfigureServices
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<OrderContext>(options =>
      {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
            builder =>
                builder.MigrationsAssembly(typeof(OrderContext).Assembly.FullName));

      });
     
      return services;
    }
  }
}
