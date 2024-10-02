using Carhub.Lib.MessageBrokers.Outbox.Outbox.Models;

namespace Carhub.Lib.MessageBrokers.Outbox.Outbox;

public interface IOutboxMessageSaver
{
    void Handle(OutboxMessage outboxMessage);
}