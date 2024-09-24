using Carhub.Service.Vehicles.Infrastructure.Outbox.Models;

namespace Carhub.Service.Vehicles.Infrastructure.Outbox.Accessors;

public interface IOutboxMessageAccessor
{
    Task<List<OutboxMessage>> GetUnsentAsync();
    Task ProcessAsync(OutboxMessage outboxMessage);
}