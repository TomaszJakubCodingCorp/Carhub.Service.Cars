namespace Carhub.Lib.MessageBrokers.Outbox.Configuration;

public sealed record OutboxOptions
{
    public bool Enabled { get; init; }
    public TimeSpan Interval { get; set; }
    public TimeSpan Expiry { get; set; }
}