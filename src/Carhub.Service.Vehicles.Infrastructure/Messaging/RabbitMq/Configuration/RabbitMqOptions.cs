namespace Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Configuration;

public record RabbitMqOptions
{
    internal static string OptionsName = nameof(RabbitMqOptions);
    public string Type { get; set; }
}