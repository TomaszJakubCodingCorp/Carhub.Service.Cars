using Carhub.Service.Vehicles.Infrastructure.Outbox.Models;

namespace Carhub.Service.Vehicles.Infrastructure.Outbox.Accessors.Abstractions;

public interface IOutboxMessageAccessor
{
    Task<List<OutboxMessage>> GetUnsentAsync(CancellationToken cancellationToken);
    Task ProcessAsync(OutboxMessage outboxMessage);
}