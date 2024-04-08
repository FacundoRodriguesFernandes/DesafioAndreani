using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Kafka.Services;

public interface IPedidoConsumerService
{
    Task ConsumeAsync(CancellationToken stoppingToken);
}

public class PedidoConsumerService : IPedidoConsumerService
{
    private readonly IConsumer<Ignore, string> _consumer;

    private readonly ILogger<PedidoConsumerService> _logger;

    public PedidoConsumerService(IConfiguration configuration, ILogger<PedidoConsumerService> logger)
    {
        _logger = logger;

        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = "PedidoGroup",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
    }

    public async Task ConsumeAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe("PedidoCreado");

        while (!stoppingToken.IsCancellationRequested)
        {
            ProcessKafkaMessage(stoppingToken);

            Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        _consumer.Close();
    }

    public void ProcessKafkaMessage(CancellationToken stoppingToken)
    {
        try
        {
            var consumeResult = _consumer.Consume(stoppingToken);

            var message = consumeResult.Message.Value;

            _logger.LogInformation($"Pedido: {message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing Kafka message: {ex.Message}");
        }
    }
}