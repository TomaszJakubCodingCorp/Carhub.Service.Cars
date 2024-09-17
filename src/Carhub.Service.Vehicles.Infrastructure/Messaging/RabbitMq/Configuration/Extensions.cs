using Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Connections;
using Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Serializing.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddRabbitMq(this IServiceCollection services)
        => services
            .AddRabbitMqSerializing();

    private static IServiceCollection AddRabbitMqProducer(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddSingleton<ProducerConnection>(sp =>
            {
                var options = configuration.GetOptions<RabbitMqOptions>(RabbitMqOptions.OptionsName);
                var connectionFactory = new ConnectionFactory()
                {

                };
            });

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        T t = new T();
        configuration.Bind(sectionName, t);
        return t;
    }
}