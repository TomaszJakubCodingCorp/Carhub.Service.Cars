using Carhub.Lib.MessageBrokers.Outbox.Models;

namespace Carhub.Lib.MessageBrokers.Outbox.Accessors.Abstractions;

public interface IOutboxMessageAccessor
{
    Task<List<OutboxMessage>> GetUnsentAsync(CancellationToken cancellationToken);
    Task ProcessAsync(OutboxMessage outboxMessage);
}