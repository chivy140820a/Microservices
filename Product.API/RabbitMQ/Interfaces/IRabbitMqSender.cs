namespace Product.API.RabbitMQ.Interfaces
{
  public interface IRabbitMqSender
  {
    void SendMessage(string message);
  }
}
