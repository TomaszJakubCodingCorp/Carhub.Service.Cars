namespace Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions;

public interface IConvention
{
    public string Exchange { get; set; }
    public string RoutingKey { get; set; }
}