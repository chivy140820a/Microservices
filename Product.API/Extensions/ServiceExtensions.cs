

using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repository;
using Product.API.Repository.Interfaces;
using System.Configuration;

namespace Product.API.Extensions
{
  public static class ServiceExtensions
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ProductContext>(options =>
      {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
            builder =>
                builder.MigrationsAssembly(typeof(ProductContext).Assembly.FullName));

      });
      services.AddScoped<ProductContextSeed>();
      services.AddTransient<IProductRepository,ProductRepository>();
      return services;
    }
  }
}