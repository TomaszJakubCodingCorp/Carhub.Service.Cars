namespace Carhub.Service.Vehicles.Infrastructure.Outbox.Models;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }
    public string MessageId { get; set; }
    public string MessageType { get; set; }
    public object Message { get; set; }
    public string SerializedMessage { get; set; }
    public DateTime SentAt { get; set; }
    public DateTime? ProcessedAt { get; set; }
}