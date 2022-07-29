using Product.API.Extensions;
using Product.API.RabbitMQ;
using Product.API.RabbitMQ.Interfaces;
using Product.API.Routing.RoutingWrapper;
using Product.API.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureServices(builder.Configuration);
var rabbitMqConfig = builder.Configuration.GetSection("RabbitMqConfig");
builder.Services.Configure<RabbitMqConfig>(rabbitMqConfig);
builder.Services.AddScoped<IRabbitMqSender, RabbitMqSender>();
builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
      builder =>
      {
        builder.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
});

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
var routing = new RoutingWrapper(app, builder.Services.BuildServiceProvider());

routing.MapAll();

app.Run();
