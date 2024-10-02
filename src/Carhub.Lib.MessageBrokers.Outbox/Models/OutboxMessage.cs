namespace Carhub.Lib.MessageBrokers.Outbox.Models;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }
    public string MessageId { get; set; }
    public string MessageType { get; set; }
    public string SerializedMessage { get; set; }
    public DateTime SentAt { get; set; }
    public DateTime? ProcessedAt { get; set; }
}