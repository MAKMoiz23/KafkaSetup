using Confluent.Kafka;
using KafkaOrderSystem.Producer.ApiResponse;
using KafkaOrderSystem.Producer.Database;
using KafkaOrderSystem.Producer.Entities;
using KafkaOrderSystem.Producer.Errors.Orders;
using KafkaOrderSystem.Producer.Models.Request.Order;
using KafkaOrderSystem.Producer.Models.Response.Order;
using KafkaOrderSystem.Shared.Models.Order;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace KafkaOrderSystem.Producer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProducer<Null, string> _orderProducer;
        private readonly ApiDbContext _dbContext;

        public OrderService(IProducer<Null, string> orderProducer, ApiDbContext dbContext)
        {
            _orderProducer = orderProducer;
            _dbContext = dbContext;
        }

        public async Task<Result> ProcessOrder(CreateOrderRequest order, CancellationToken cancellationToken){
            try{
                if (order.Items is null || !order.Items.Any() || order.Items.Any(i => i.ProductName is null || i.Quantity <= 0))
                {
                    return Result.Failure(OrderErrors.InvalidOrder);
                }

                Entities.Order o = new()
                {
                    OrderItems = order.Items.Select(i => new OrderItems
                    {
                        ProductName = i.ProductName,
                        Quantity = i.Quantity
                    }).ToList()
                };

                await _dbContext.Orders.AddAsync(o, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                OrderModel om = new()
                {
                    OrderNo = o.OrderNo,
                    NoOfproducts = o.OrderItems.Count(),
                };

                var orderJson = JsonConvert.SerializeObject(om);
                var message = new Message<Null, string> { Value = orderJson };

                await _orderProducer.ProduceAsync("order-topic", message, cancellationToken);
                return Result.Success();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> GetAllOrders(CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _dbContext.Orders
                    .Include(o => o.OrderItems)
                    .ToListAsync(cancellationToken);

                IEnumerable<GetOrderResponse> res = orders.Select(o => new GetOrderResponse
                {
                    Id = o.Id,
                    OrderNo = $"OR-{o.OrderNo:D6}",
                    Items = o.OrderItems.Select(oi => new GetOrderItemResponse
                    {
                        Id = oi.Id,
                        ProductName = oi.ProductName,
                        Quantity = oi.Quantity
                    })
                });

                return Result.Success(res);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
