using Carhub.Lib.MessageBrokers.Abstractions;
using Carhub.Lib.MessageBrokers.Abstractions.Serializing;
using Carhub.Lib.MessageBrokers.Outbox.Outbox.Accessors.Abstractions;
using Carhub.Service.Vehicles.Infrastructure.Outbox.Models;

namespace Carhub.Lib.MessageBrokers.Outbox.Outbox.Decorators;

internal sealed class OutboxEventPublisherDecorator(
    IEventPublisher eventPublisher,
    IOutboxMessageAccessor messageAccessor,
    IMessageBrokerSerializer serializer) : IEventPublisher
{
    public string Publish<TMessage>(TMessage message) where TMessage : class, IEvent
    {
        try
        {
            var messageId = eventPublisher.Publish(message);
            var outboxMessage = new OutboxMessage()
            {
                Id = Guid.NewGuid(),
                MessageId = messageId,
                SerializedMessage = serializer.ToByteJson(message),
                
            }
            //messageAccessor.ProcessAsync()
        }
        catch (Exception ex)
        {
            
        }
    }
}