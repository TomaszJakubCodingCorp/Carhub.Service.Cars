namespace Carhub.Service.Vehicle.Infrastructure.Messaging.RabbitMq.Serializing;

internal interface IRabbitMqSerializer
{
     ReadOnlySpan<byte> ToJson<TMessage>(TMessage message) where TMessage : class;
    
}