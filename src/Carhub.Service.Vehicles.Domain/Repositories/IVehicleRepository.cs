using System.Net.Http.Headers;
using Carhub.Service.Vehicles.Domain.Vehicles.Entities;

namespace Carhub.Service.Vehicles.Domain.Repositories;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
    Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken);
    Task<bool> IsVinNumberExistsAsync(string vinNumber, CancellationToken cancellationToken);
    Task<Vehicle> GetAsync(Guid id, CancellationToken cancellationToken);
}