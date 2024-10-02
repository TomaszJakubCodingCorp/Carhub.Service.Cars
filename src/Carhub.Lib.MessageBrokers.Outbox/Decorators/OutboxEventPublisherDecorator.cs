using Carhub.Lib.MessageBrokers.Abstractions;
using Carhub.Lib.MessageBrokers.Abstractions.Serializing;
using Carhub.Lib.MessageBrokers.Outbox.Models;
using Microsoft.Extensions.Logging;

namespace Carhub.Lib.MessageBrokers.Outbox.Decorators;

internal sealed class OutboxEventPublisherDecorator(
    IEventPublisher eventPublisher,
    ILogger<OutboxEventPublisherDecorator> logger, 
    IOutboxMessageSaver outboxMessageSaver,
    IMessageBrokerSerializer serializer) : IEventPublisher
{
    public void Publish<TMessage>(TMessage message, Guid? messageId = null) where TMessage : class, IEvent
    {
        var outboxMessage = new OutboxMessage();
        messageId ??= Guid.NewGuid();
        try
        {
            eventPublisher.Publish(message, messageId);
            outboxMessage.ProcessedAt = DateTime.Now;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
        finally
        {
            outboxMessage.Id = Guid.NewGuid();
            outboxMessage.MessageId = messageId.ToString();
            outboxMessage.SerializedMessage = serializer.ToStringJson(message);
            outboxMessage.MessageType = message?.GetType()?.FullName;
            outboxMessage.SentAt = DateTime.Now;
            outboxMessageSaver.Handle(outboxMessage);
        }
    }
}