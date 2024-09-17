namespace Carhub.Service.Vehicles.Application;

public interface IEventPublisher
{
    public Task Publish<TMessage>(TMessage message) where TMessage : class, IEvent;
}