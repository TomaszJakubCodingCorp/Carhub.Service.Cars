using Carhub.Service.Vehicles.Infrastructure.Messaging.Configuration;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Configuration;

internal sealed record RabbitMqOptions
{
    internal static string OptionsName = $"{MessagingOptions.OptionsName}:{nameof(RabbitMqOptions)}";
    public int Port { get; init; }
    public string HostName { get; init; }
    public string VirtualHost { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
    public string ConnectionName { get; init; }
    public List<ConsumerOptions> Consumers { get; init; }
}

internal sealed record ConsumerOptions
{
    public string Type { get; init; }
    public string Exchange { get; init; }
    public string Routing { get; init; }
    public string Queue { get; init; }
}