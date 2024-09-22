using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Abstractions;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Connections;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Serializing.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddRabbitMqSerializing()
            .AddServices()
            .AddConfiguration(configuration)
            .AddRabbitMqProducerConnection(configuration)
            .AddRabbitMqConsumerConnection(configuration);

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IRabbitMqClient, RabbitMqClient>();

    private static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services
            .Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.OptionsName));

    private static IServiceCollection AddRabbitMqProducerConnection(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddSingleton<ProducerConnection>(sp =>
            {
                var options = configuration.GetOptions<RabbitMqOptions>(RabbitMqOptions.OptionsName);
                
                var connectionFactory = new ConnectionFactory()
                {
                    Port = options.Port,
                    HostName = options.HostName,
                    VirtualHost = options.VirtualHost,
                    UserName = options.UserName,
                    Password = options.Password,
                    ClientProvidedName = $"{options.ConnectionName}_Producer"
                };
                var connection = connectionFactory.CreateConnection();
                return new ProducerConnection(connection);
            });

    private static IServiceCollection AddRabbitMqConsumerConnection(this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSingleton<ConsumerConnection>(sp =>
            {
                var options = configuration.GetOptions<RabbitMqOptions>(RabbitMqOptions.OptionsName);
                var connectionFactory = new ConnectionFactory()
                {
                    Port = options.Port,
                    HostName = options.HostName,
                    VirtualHost = options.VirtualHost,
                    UserName = options.UserName,
                    Password = options.Password,
                    ClientProvidedName = $"{options.ConnectionName}_Consumer"
                };
                var connection = connectionFactory.CreateConnection();
                return new ConsumerConnection(connection);
            });

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        T t = new T();
        configuration.Bind(sectionName, t);
        return t;
    }
}