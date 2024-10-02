using Carhub.Lib.MessageBrokers.Outbox.Models;

namespace Carhub.Lib.MessageBrokers.Outbox;

public interface IOutboxMessageSaver
{
    void Handle(OutboxMessage outboxMessage);
}