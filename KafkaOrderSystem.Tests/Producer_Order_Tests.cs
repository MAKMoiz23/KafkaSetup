using Confluent.Kafka;
using FluentAssertions;
using KafkaOrderSystem.Producer.ApiResponse;
using KafkaOrderSystem.Producer.Controller;
using KafkaOrderSystem.Producer.Errors.Orders;
using KafkaOrderSystem.Producer.Models.Request.Order;
using KafkaOrderSystem.Producer.Models.Response.Order;
using KafkaOrderSystem.Producer.Services;
using KafkaOrderSystem.Shared.Models.Order;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace KafkaOrderSystem.Tests
{
    public class Producer_Order_Tests
    {
        private readonly IOrderService _orderService;
        private readonly OrderController _orderController;

        public Producer_Order_Tests()
        {
            _orderService = Substitute.For<IOrderService>();
            _orderController = new OrderController(_orderService);
        }

        [Fact]
        public async Task ProcessOrder_Should_ReturnOk_WhenServiceReturnsSuccess()
        {
            // Arrange
            var orderModel = new CreateOrderRequest
            {
                Items =
                [
                    new() { ProductName = "Product 1", Quantity = 1 },
                    new() { ProductName = "Product 2", Quantity = 2 }
                ]
            };
            _orderService.ProcessOrder(orderModel, Arg.Any<CancellationToken>())
                .Returns(Result.Success(new ProcessOrderResponse { Message = "Order processed successfully" }));

            // Act
            var result = await _orderController.ProcessOrder(orderModel, default);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task ProcessOrder_Should_ReturnBadRequest_WhenServiceReturnsFailure()
        {
            // Arrange
            var orderModel = new CreateOrderRequest()
            {
                Items =
                [
                    new() { ProductName = null, Quantity = 1 }
                ]
            };
            _orderService.ProcessOrder(orderModel, Arg.Any<CancellationToken>())
                .Returns(Result.Failure(OrderErrors.InvalidOrder));

            // Act
            var result = await _orderController.ProcessOrder(orderModel, default);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

    }
}
