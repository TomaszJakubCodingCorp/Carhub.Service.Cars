namespace Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Abstractions;

internal interface IConvention
{
    public string Exchange { get; }
    public string RoutingKey { get; }
}