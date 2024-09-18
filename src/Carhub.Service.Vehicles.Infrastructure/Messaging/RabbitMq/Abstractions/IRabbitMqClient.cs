using Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Abstractions;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Abstractions;

internal interface IRabbitMqClient
{
    void Publish<TMessage>(TMessage message, IConvention convention, Guid? messageId = null) where TMessage : class;
}