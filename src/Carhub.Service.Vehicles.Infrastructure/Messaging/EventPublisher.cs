using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Abstractions;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Abstractions;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging;

internal sealed class EventPublisher(
    IConventionProvider conventionProvider,
    IRabbitMqClient client) : IEventPublisher
{
    public Task Publish<TMessage>(TMessage message) where TMessage : class, IEvent
    {
        var convention = conventionProvider.Get<TMessage>();
        client.Publish(message, convention, Guid.NewGuid());
        return Task.CompletedTask;
    }
}