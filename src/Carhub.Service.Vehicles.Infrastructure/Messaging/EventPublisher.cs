using Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Abstractions;
using Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Abstractions;
using Carhub.Service.Vehicles.Application;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging;

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