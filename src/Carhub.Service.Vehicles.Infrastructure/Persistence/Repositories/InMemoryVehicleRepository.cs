using Carhub.Service.Vehicles.Domain.Repositories;
using Carhub.Service.Vehicles.Domain.Vehicles.Entities;

namespace Carhub.Service.Vehicles.Infrastructure.Persistence.Repositories;

internal sealed class InMemoryVehicleRepository : IVehicleRepository
{
    private readonly List<Vehicle> _vehicles = new List<Vehicle>();

    public Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        _vehicles.Add(vehicle);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task<bool> IsVinNumberExistsAsync(string vinNumber, CancellationToken cancellationToken)
        => Task.FromResult(_vehicles.Any(x => x.VinNumber.Value == vinNumber));

    public Task<Vehicle> GetAsync(Guid id, CancellationToken cancellationToken)
        => Task.FromResult(_vehicles.FirstOrDefault(x => x.Id.Value == id));
}