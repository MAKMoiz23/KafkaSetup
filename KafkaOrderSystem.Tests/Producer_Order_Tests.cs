using Confluent.Kafka;
using FluentAssertions;
using KafkaOrderSystem.Producer.Controller;
using KafkaOrderSystem.Shared.Models.Order;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace KafkaOrderSystem.Tests
{
    public class Producer_Order_Tests
    {
        private readonly IProducer<Null, string> _orderProducer;
        private readonly OrderController _orderController;

        public Producer_Order_Tests()
        {
            _orderProducer = Substitute.For<IProducer<Null, string>>();
            _orderController = new OrderController(_orderProducer);
        }

        [Fact]
        public async Task Handle_Should_ReturnBaadRequest_WheninputIsInvalid()
        {
            //Arrange
            OrderModel orderModel = new OrderModel();

            //Act
            var result = await _orderController.ProcessOrder(orderModel, default);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Handle_Should_ReturnOk_WhenInputIsValid()
        {
            //Arrange
            OrderModel orderModel = new OrderModel
            {
                ProductName = "Product",
                Quantity = 1
            };
            //Act
            var result = await _orderController.ProcessOrder(orderModel, default);
            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Handle_Should_CallProduceAsync_WhenInputIsValid()
        {
            //Arrange
            OrderModel orderModel = new OrderModel
            {
                ProductName = "Product",
                Quantity = 1
            };
            //Act
            await _orderController.ProcessOrder(orderModel, default);
            //Assert
            await _orderProducer.Received(1).ProduceAsync("order-topic", Arg.Any<Message<Null, string>>(), default);
        }

    }
}
