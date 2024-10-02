using Carhub.Lib.MessageBrokers.Outbox.Outbox.Models;

namespace Carhub.Lib.MessageBrokers.Outbox.Outbox.Accessors.Abstractions;

public interface IOutboxMessageAccessor
{
    Task<List<OutboxMessage>> GetUnsentAsync(CancellationToken cancellationToken);
    Task ProcessAsync(OutboxMessage outboxMessage);
}