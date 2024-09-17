using Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Abstractions;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions;

internal sealed class Convention(string exchange, string routingKey) : IConvention
{
    public string Exchange { get; } = exchange;
    public string RoutingKey { get; } = routingKey;
}