using Carhub.Service.Vehicles.Application;
using RabbitMQ.Client;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging;

internal sealed class EventPublisher : IEventPublisher
{
    public Task Publish<TMessage>(TMessage message) where TMessage : class, IEvent
    {
        throw new NotImplementedException();
    }
}