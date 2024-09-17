using Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions;
using Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Abstractions;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Abstractions;

internal interface IRabbitMqClient
{
    void Publish<TMessage>(TMessage message, IConvention convention, Guid? messageId = null) where TMessage : class;
}