using Confluent.Kafka;
using KafkaOrderSystem.Consumer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IConsumer<string, string>>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<IConsumer<string, string>>>();

    var config = new ConsumerConfig
    {
        GroupId = builder.Configuration.GetValue<string>("Kafka:GroupId"),
        BootstrapServers = builder.Configuration.GetValue<string>("Kafka:BootstrapServers"),
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = false, 
        AllowAutoCreateTopics = true 
    };

    logger.LogInformation("Kafka Consumer configured with GroupId: {GroupId} and BootstrapServers: {BootstrapServers}",
                          config.GroupId, config.BootstrapServers);

    return new ConsumerBuilder<string, string>(config).Build();
});


var host = builder.Build();
host.Run();
