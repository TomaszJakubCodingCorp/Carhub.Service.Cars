using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Serializing.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddRabbitMqSerializing(this IServiceCollection services)
        => services
            .AddSingleton<IRabbitMqSerializer, RabbitMqSerializer>();
}