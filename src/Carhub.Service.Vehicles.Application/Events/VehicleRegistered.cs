namespace Carhub.Service.Vehicles.Application.Events;

public record VehicleRegistered(Guid VehicleId) : IEvent;