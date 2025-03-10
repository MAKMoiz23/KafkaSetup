using Confluent.Kafka;
using KafkaOrderSystem.Shared.Models.Order;
using Newtonsoft.Json;

namespace KafkaOrderSystem.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumer<string, string> _orderConsumer;

        public Worker(ILogger<Worker> logger, IConsumer<string, string> orderConsumer)
        {
            _logger = logger;
            _orderConsumer = orderConsumer;
            _orderConsumer.Subscribe("order-topic");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consumer service started at: {time}", DateTimeOffset.Now);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _orderConsumer.Consume(stoppingToken);

                        if (consumeResult?.Message == null)
                        {
                            _logger.LogWarning("Received null message from Kafka.");
                            continue;
                        }

                        var order = JsonConvert.DeserializeObject<OrderModel>(consumeResult.Message.Value);

                        if (order is null)
                        {
                            _logger.LogError("Failed to deserialize message: {Message}", consumeResult.Message.Value);
                            continue;
                        }

                        _logger.LogInformation("Processed Order: {OrderNo} - No. of Products: {NoOfProducts}",
                            order.OrderNo, order.NoOfproducts);

                        await Task.Delay(500, stoppingToken); // Simulate async work

                        _orderConsumer.Commit(consumeResult);
                    }
                    catch (ConsumeException ex)
                    {
                        _logger.LogError("Kafka consume error: {Reason}", ex.Error.Reason);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unexpected error occurred.");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Cancellation requested, stopping consumer service.");
            }
            finally
            {
                _orderConsumer.Close();
                _logger.LogInformation("Consumer service stopped at: {time}", DateTimeOffset.Now);
            }
        }
    }
}
