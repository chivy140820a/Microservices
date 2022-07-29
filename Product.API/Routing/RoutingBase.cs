using Contracts.Repositories;
using Contracts.Routing;
using Microsoft.EntityFrameworkCore;

namespace Product.API.Routing
{
  public class RoutingBase<T, R, TContext> : IRoutingBase<T, R, TContext> where R : IRepositoryBase<T, TContext>
    where TContext : DbContext
  {
    protected WebApplication app { get; set; }

    protected readonly R repository;
    public RoutingBase(WebApplication app, R repository)
    {
      this.app = app;
      this.repository = repository;
    }

    public async Task MapBase()
    {

      app.MapGet($"/api/{typeof(T).Name}/GetAll", async (R repository) =>
      {
        var result = await repository.GetAll();
        return Results.Ok(result);
      });

      app.MapGet($"/api/{typeof(T).Name}/GetById", async (int id, HttpContext http, R repository) =>
      {
        try
        {
          var item = await repository.GetById(id);
          if (item == null) return Results.NotFound($"Not found item with id : {id}");
          return Results.Ok(item);
        }
        catch (Exception ex)
        {
          Results.StatusCode(500);
          return Results.Problem(ex.ToString());
        }

      });

      app.MapPost($"/api/{typeof(T).Name}/PostAsync", async (T model, HttpContext http, R repository) =>
      {
        try
        {
          var item = await repository.Create(model);
          return Results.Ok(item);
        }
        catch (Exception ex)
        {
          return Results.Problem(ex.ToString());
        }
      });

      app.MapPut($"/api/{typeof(T).Name}/PutAsync", async (int id, T model, HttpContext http, R repository) =>
      {
        try
        {
          var item = await repository.GetByIdNoTracking(id);
          if (item == null) return Results.BadRequest($"Not found item with id : {id}");
          await repository.Update(model);
          return Results.Ok(model);
        }
        catch (Exception ex)
        {
          return Results.Problem(ex.ToString());
        }

      });

      app.MapDelete($"/api/{typeof(T).Name}/Delete", async (int id, HttpContext http, R repository) =>
      {
        try
        {
          var item = await repository.GetById(id);
          if (item == null) return Results.NotFound($"Not found item with id : {id}");
          await repository.Delete(item);
          return Results.Ok(item);
        }
        catch (Exception ex)
        {
          return Results.Problem(ex.ToString());
        }

      });

      app.MapDelete($"/api/{typeof(T).Name}/BulkDelete", async (string ids, HttpContext http, R repository) =>
      {
        try
        {
          List<T> lstDelete = new();
          IEnumerable<string> lstObjects = ids.Split(",").ToList();
          foreach (var obj in lstObjects)
          {
            int id;
            if (!Int32.TryParse(obj, out id)) return Results.Problem($"Problem with {ids}");
            var existsItem = await repository.GetById(id);
            if (existsItem == null) return Results.NotFound($"Not found item with id : {obj}");
            lstDelete.Add(existsItem);
          }
          await repository.BulkDelete(lstDelete);
          return Results.Ok();
        }
        catch (Exception ex)
        {
          return Results.Problem(ex.ToString());
        }

      });

    }
  }
}
