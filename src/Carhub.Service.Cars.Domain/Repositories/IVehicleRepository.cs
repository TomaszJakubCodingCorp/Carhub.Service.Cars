using Carhub.Service.Cars.Domain.Vehicles.Entities;

namespace Carhub.Service.Cars.Domain.Repositories;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
}