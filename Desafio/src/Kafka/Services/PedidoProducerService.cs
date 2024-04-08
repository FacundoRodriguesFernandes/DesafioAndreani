using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Kafka.Services;

public interface IPedidoProducerService
{
    Task ProduceAsync(string topic, string message);
}

public class PedidoProducerService : IPedidoProducerService
{
    private readonly IConfiguration _configuration;

    private readonly IProducer<Null, string> _producer;

    public PedidoProducerService(IConfiguration configuration)
    {
        _configuration = configuration;

        var producerconfig = new ProducerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"]
        };

        _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        var kafkamessage = new Message<Null, string> { Value = message, };

        await _producer.ProduceAsync(topic, kafkamessage);
    }
}