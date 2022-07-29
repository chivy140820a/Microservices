using Microsoft.Extensions.Options;
using Product.API.Entities;
using Product.API.RabbitMQ.Interfaces;
using Product.API.ViewModels;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Product.API.RabbitMQ
{
  public class RabbitMqSender : IRabbitMqSender
  {
    private readonly string queueName;
    private readonly IConnection connection;
    private readonly IModel channel;

    public RabbitMqSender(IOptions<RabbitMqConfig> cfg)
    {
      queueName = cfg.Value.QueueName;

      var factory = new ConnectionFactory() { HostName = cfg.Value.HostName };
      factory.UserName = cfg.Value.Username;
      factory.Password = cfg.Value.Password;
      connection = factory.CreateConnection();
      channel = connection.CreateModel();
      channel.QueueDeclare(queue: cfg.Value.QueueName,
                          durable: true,
                          exclusive: false,
                          autoDelete: false);
    }

    public void SendMessage(string message)
    {
    
      for (int i = 0; i < 10000; i++)
      {
        var product = new CatalogProduct()
        {
          Id = i,
          Name = $"Product{i}",
          Price = i,
          LastPrice = i,
          PathImage = "a"
        };
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(product));
        channel.BasicPublish(exchange: string.Empty,
            routingKey: queueName,
            basicProperties: properties,
            body: body);
      }

    }

    ~RabbitMqSender()
    {
      if (connection is not null)
      {
        channel.Close();
        connection.Close();
        channel.Dispose();
        connection.Dispose();
      }
    }
  }
}
