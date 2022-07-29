using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Order.Infrastructures.Viewmodel;

namespace Order.Infrastructures
{
  public class QueueWorker : BackgroundService
  {
    private IModel channel;
    private IConnection connection;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
      var factory = new ConnectionFactory() { HostName = "rabbitmq", DispatchConsumersAsync = true };
      factory.UserName = "guest";
      factory.Password = "guest";

      var queueName = "SampleQueue";

      connection = factory.CreateConnection();
      channel = connection.CreateModel();
      // We will also have to declare the queue here,
      // because this application might start first so we will make sure that 
      channel.QueueDeclare(queue: queueName,
                           durable: true,
                           exclusive: false,
                           autoDelete: false,
                           arguments: null);
      channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
      var consumer = new AsyncEventingBasicConsumer(channel);
      // Callback
      consumer.Received += ReceiveData;
      // Start receiving messages
      channel.BasicConsume(queue: queueName,
               autoAck: false,
               consumer: consumer);
      return Task.CompletedTask;
    }

    private Task ReceiveData(object sender, BasicDeliverEventArgs @event)
    {
      var payload = JsonSerializer.Deserialize<CatalogProductViewModel>(Encoding.UTF8.GetString(@event.Body.ToArray()));
      Console.WriteLine("Received: " + payload.Name);
      channel.BasicAck(deliveryTag: @event.DeliveryTag, multiple: false);
      return Task.CompletedTask;
    }

    ~QueueWorker()
    {
      channel.Close();
      connection.Close();
      channel.Dispose();
      connection.Dispose();

    }
  }
}
