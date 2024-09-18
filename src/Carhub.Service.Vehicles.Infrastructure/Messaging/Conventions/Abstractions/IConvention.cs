namespace Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Abstractions;

internal interface IConvention
{
    public string Exchange { get; }
    public string RoutingKey { get; }
}