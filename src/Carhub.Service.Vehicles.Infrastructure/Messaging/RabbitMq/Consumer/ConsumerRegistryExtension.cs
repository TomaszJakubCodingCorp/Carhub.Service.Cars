using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Configuration;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Connections;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Serializing;
using Carhub.Service.Vehicles.Infrastructure.RabbitMqConfigTests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Consumer;

public static class ConsumerRegistryExtension
{
    public static IRabbitMqServiceCollection AddConsumer<TMessage>(this IRabbitMqServiceCollection services,
        Func<TMessage, Task> func)
        where TMessage : class, IConsumer
    {
        services
            .AddHostedService<RabbitMqBackgroundService<TMessage>>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMqBackgroundService<TMessage>>>();
                var consumerConnection = sp.GetRequiredService<ConsumerConnection>();
                var rabbitMqSerializer = sp.GetRequiredService<IRabbitMqSerializer>();
                var options = sp.GetRequiredService<IOptions<RabbitMqOptions>>().Value;

                var typeName = typeof(TMessage).Name;
                var consumerOptions = options.Consumers?.FirstOrDefault(x
                    => x.Type == typeName);

                if (consumerOptions is null)
                {
                    throw new ArgumentException($"Consumer options for type: {typeName}");
                }

                return new RabbitMqBackgroundService<TMessage>(
                    logger,
                    consumerConnection,
                    rabbitMqSerializer,
                    consumerOptions,
                    func);
            });
        return services;
    }
}