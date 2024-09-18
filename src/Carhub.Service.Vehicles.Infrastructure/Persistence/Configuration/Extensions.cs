using Carhub.Service.Vehicles.Domain.Repositories;
using Carhub.Service.Vehicles.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.Persistence.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddPersistence(this IServiceCollection services)
        => services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
}