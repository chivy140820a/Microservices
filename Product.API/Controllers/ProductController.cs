using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.RabbitMQ.Interfaces;

namespace Product.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IRabbitMqSender _sender;
    public ProductController(IRabbitMqSender sender)
    {
      _sender = sender;
    }
    [HttpGet("SendTest")]
    public IActionResult SendTest()
    {
      _sender.SendMessage("demo");
      return Ok();
    }
  }
}
