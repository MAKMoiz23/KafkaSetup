using Confluent.Kafka;
using FluentAssertions;
using KafkaOrderSystem.Producer.Errors.Orders;
using KafkaOrderSystem.Producer.Models.Request.Order;
using NSubstitute;

namespace KafkaOrderSystem.Tests
{
    public class Producer_Order_Service_Test
    {
        //private readonly IProducer<Null, string> _producer;
        //private readonly Producer.Services.OrderService _orderService;
        //private readonly ApiDbContext _dbContext;

        //public Producer_Order_Service_Test()
        //{
        //    _producer = Substitute.For<IProducer<Null, string>>();
            //_dbContext = Substitute.For<ApiDbContext>();
            //_orderService = new Producer.Services.OrderService(_producer, default);
        //}

        //[Fact]
        //public async Task ProcessOrder_Should_ReturnFailure_WhenProductNameIsNull()
        //{
        //    // Arrange
        //    var orderModel = new CreateOrderRequest()
        //    {
        //        Items =
        //        [
        //            new() { ProductName = null, Quantity = 1 }
        //        ]
        //    };
        //    // Act
        //    var result = await _orderService.ProcessOrder(orderModel, default);

        //    // Assert
        //    result.IsSuccess.Should().BeFalse();
        //    result.Error.Should().Be(OrderErrors.InvalidOrder);
        //}

        //[Fact]
        //public async Task ProcessOrder_Should_ProduceMessage_WhenOrderIsValid()
        //{
        //    // Arrange
        //    var orderModel = new CreateOrderRequest() { 
        //        Items = 
        //        [
        //            new() { ProductName = "Product", Quantity = 1 }
        //        ] 
        //    };

        //    // Act
        //    var result = await _orderService.ProcessOrder(orderModel, default);

        //    // Assert
        //    result.IsSuccess.Should().BeTrue();
        //    await _producer.Received(1).ProduceAsync(
        //        Arg.Any<string>(),
        //        Arg.Any<Message<Null, string>>(),
        //        Arg.Any<CancellationToken>());
        //}

        //[Fact]

        //public async Task ProcessOrder_Should_ReturnFailure_WhenOrderItemsAreEmpty()
        //{
        //    // Arrange
        //    var orderModel = new CreateOrderRequest()
        //    {
        //        Items = []
        //    };
        //    // Act
        //    var result = await _orderService.ProcessOrder(orderModel, default);
        //    // Assert
        //    result.IsSuccess.Should().BeFalse();
        //    result.Error.Should().Be(OrderErrors.InvalidOrder);
        //}

        //public async Task ProcessOrder_Should_ReturnFailure_WhenOrderItemsAreNull()
        //{
        //    // Arrange
        //    var orderModel = new CreateOrderRequest()
        //    {
        //        Items = null
        //    };
        //    // Act
        //    var result = await _orderService.ProcessOrder(orderModel, default);
        //    // Assert
        //    result.IsSuccess.Should().BeFalse();
        //    result.Error.Should().Be(OrderErrors.InvalidOrder);
        //}

    }
}
