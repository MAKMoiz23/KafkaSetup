using KafkaOrderSystem.Producer.Services;
using Microsoft.AspNetCore.Mvc;
using KafkaOrderSystem.Producer.Models.Request.Order;

namespace KafkaOrderSystem.Producer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost("ProcessOrder")]
        public async Task<IActionResult> ProcessOrder([FromBody] CreateOrderRequest order, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _orderService.ProcessOrder(order, cancellationToken);
                return result.IsSuccess ? NoContent() : BadRequest(result.Error);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _orderService.GetAllOrders(cancellationToken);
                return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
