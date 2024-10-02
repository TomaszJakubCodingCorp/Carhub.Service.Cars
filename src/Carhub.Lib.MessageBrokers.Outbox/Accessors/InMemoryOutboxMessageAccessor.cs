using System.Collections.Concurrent;
using Carhub.Lib.MessageBrokers.Outbox.Accessors.Abstractions;
using Carhub.Lib.MessageBrokers.Outbox.Configuration;
using Carhub.Lib.MessageBrokers.Outbox.Models;
using Microsoft.Extensions.Options;

namespace Carhub.Lib.MessageBrokers.Outbox.Accessors;

internal sealed class InMemoryOutboxMessageAccessor : IOutboxMessageAccessor, IOutboxMessageSaver
{
    private readonly ConcurrentDictionary<string, OutboxMessage> _outboxMessages = [];
    private readonly TimeSpan _expiry;

    public InMemoryOutboxMessageAccessor(IOptions<OutboxOptions> options)
    {
        _expiry = options.Value.Expiry;
    }
    
    public Task<List<OutboxMessage>> GetUnsentAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(_outboxMessages
            .Where(x => x.Value.ProcessedAt is null)
            .Select(x => x.Value)
            .ToList());
    }

    public Task ProcessAsync(OutboxMessage outboxMessage)
    {
        outboxMessage.ProcessedAt = DateTime.Now;
        RemoveExpiredMessages();
        return Task.CompletedTask;
    }

    private void RemoveExpiredMessages()
    {
        if (_expiry == TimeSpan.Zero)
        {
            return;
        }

        var now = DateTime.Now;
        var expiredMessages = _outboxMessages
            .Where(x => CountMessageLifeTime(now, x.Value) >= _expiry)
            .ToDictionary();
        foreach (var expiredMessage in expiredMessages)
        {
            _outboxMessages.TryRemove(expiredMessage.Key, out _);
        }
    }

    private static TimeSpan CountMessageLifeTime(DateTime now, OutboxMessage outboxMessage)
        => outboxMessage.ProcessedAt is null ? 
            TimeSpan.Zero : 
            TimeSpan.FromMicroseconds(now.Microsecond - outboxMessage.ProcessedAt.Value.Microsecond);

    public void Handle(OutboxMessage outboxMessage)
        => _outboxMessages.TryAdd(outboxMessage.MessageId, outboxMessage);
    
}