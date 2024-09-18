namespace Carhub.Service.Vehicle.Infrastructure.Messaging.Configuration;

internal sealed record MessagingOptions
{
    internal static string OptionsName = nameof(MessagingOptions);
    public bool Outbox { get; init; } = false;
}