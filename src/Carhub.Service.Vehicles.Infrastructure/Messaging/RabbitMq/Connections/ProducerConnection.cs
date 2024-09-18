using RabbitMQ.Client;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Connections;

internal sealed class ProducerConnection(IConnection connection)
{
    public IConnection Connection { get; } = connection;
}