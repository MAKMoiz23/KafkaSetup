using KafkaOrderSystem.Producer.ApiResponse;
using KafkaOrderSystem.Producer.Models.Request.Order;

namespace KafkaOrderSystem.Producer.Services
{
    public interface IOrderService
    {
        Task<Result> GetAllOrders(CancellationToken cancellationToken);
        Task<Result> ProcessOrder(CreateOrderRequest order, CancellationToken cancellationToken);
    }
}
