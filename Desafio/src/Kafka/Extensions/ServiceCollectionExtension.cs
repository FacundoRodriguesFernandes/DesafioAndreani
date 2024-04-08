using Kafka.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddKafka(this IServiceCollection services)
        {
            services.AddSingleton<IPedidoProducerService, PedidoProducerService>();
            services.AddSingleton<IPedidoConsumerService, PedidoConsumerService>();

            return services;
        }
    }
}