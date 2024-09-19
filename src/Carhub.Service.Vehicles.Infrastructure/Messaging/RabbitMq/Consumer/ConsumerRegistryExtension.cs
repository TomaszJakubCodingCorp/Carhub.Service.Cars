using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Connections;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Serializing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Consumer;

public static class ConsumerRegistryExtension
{
    public static IServiceCollection AddConsumer<TMessage>(this IServiceCollection services, Func<TMessage, Task> func)
        where TMessage : class, IConsumer
        => services
            .AddHostedService<RabbitMqBackgroundService<TMessage>>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMqBackgroundService<TMessage>>>();
                var consumerConnection = sp.GetRequiredService<ConsumerConnection>();
                var rabbitMqSerializer = sp.GetRequiredService<IRabbitMqSerializer>();
                return new RabbitMqBackgroundService<TMessage>(
                    logger,
                    consumerConnection,
                    rabbitMqSerializer,
                    func);
            });
}