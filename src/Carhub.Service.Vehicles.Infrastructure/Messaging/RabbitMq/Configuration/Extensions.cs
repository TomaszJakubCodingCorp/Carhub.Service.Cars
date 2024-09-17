using Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Serializing.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddRabbitMq(this IServiceCollection services)
        => services.AddRabbitMqSerializing();
}