using Carhub.Service.Vehicles.Infrastructure.Outbox.Accessors.Abstractions;
using Carhub.Service.Vehicles.Infrastructure.Outbox.Models;

namespace Carhub.Service.Vehicles.Infrastructure.Outbox.Accessors;

internal sealed class PostgreOutboxMessageAccessor : IOutboxMessageAccessor
{
    public Task<List<OutboxMessage>> GetUnsentAsync()
    {
        throw new NotImplementedException();
    }

    public Task ProcessAsync(OutboxMessage outboxMessage)
    {
        throw new NotImplementedException();
    }
}