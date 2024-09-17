using Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Configuration;
using Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddMessaging(this IServiceCollection services)
        => services
            .AddConventions()
            .AddRabbitMq();
}