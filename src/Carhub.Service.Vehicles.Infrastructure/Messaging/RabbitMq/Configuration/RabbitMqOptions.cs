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
    
}