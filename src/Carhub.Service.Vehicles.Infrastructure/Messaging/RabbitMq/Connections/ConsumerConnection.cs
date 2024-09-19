using RabbitMQ.Client;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Connections;

internal sealed class ConsumerConnection(IConnection connection)
{
    public IConnection Connection { get; } = connection;
}