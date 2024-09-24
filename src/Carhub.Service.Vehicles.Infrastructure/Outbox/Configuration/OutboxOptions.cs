namespace Carhub.Service.Vehicles.Infrastructure.Outbox.Configuration;

public sealed record OutboxOptions
{
    public bool Enabled { get; init; }
    public string ConnectionString { get; init; }
    public TimeSpan Interval { get; set; }
}