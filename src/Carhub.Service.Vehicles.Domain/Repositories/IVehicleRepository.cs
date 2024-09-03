using Carhub.Service.Vehicles.Domain.Vehicles.Entities;

namespace Carhub.Service.Vehicles.Domain.Repositories;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
    Task<bool> IsVinNumberExists(string vinNumber);
}