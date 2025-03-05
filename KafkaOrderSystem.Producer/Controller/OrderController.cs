using Confluent.Kafka;
using KafkaOrderSystem.Producer.Models.Response.Order;
using KafkaOrderSystem.Shared.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KafkaOrderSystem.Producer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IProducer<Null, string> _orderProducer;

        public OrderController(IProducer<Null, string> orderProducer)
        {
            _orderProducer = orderProducer;
        }


        [HttpPost]
        public async Task<IActionResult> ProcessOrder([FromBody] OrderModel order, CancellationToken cancellationToken)
        {
            try
            {
                if(order.ProductName is null || order.Quantity <= 0)
                {
                    return BadRequest("Product name and quantity are required.");
                }

                var orderJson = JsonConvert.SerializeObject(order);
                var message = new Message<Null, string> { Value = orderJson };
                await _orderProducer.ProduceAsync("order-topic", message, cancellationToken);
                return Ok(new ProcessOrderResponse
                {
                    IsSuccess = true,
                    Message = "Order processed successfully"
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
