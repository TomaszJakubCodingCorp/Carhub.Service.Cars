using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Configuration;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddConventions()
            .AddRabbitMq(configuration)
            .AddServices()
            .AddConfiguration(configuration);

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IEventPublisher, EventPublisher>();

    private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services
            .Configure<MessagingOptions>(configuration.GetSection(MessagingOptions.OptionsName));
}