using Bogus;
using Carhub.Service.Vehicles.Domain.Vehicles.Entities;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

namespace Carhub.Service.Vehicles.Tests.Shared.Domain.Vehicles;

public static class VehicleFactory
{
    public static Vehicle Get()
    {
        var faker = new Faker<Vehicle>()
            .CustomInstantiator(arg => Vehicle.Create(
                Guid.NewGuid(),
                arg.Vehicle.Vin(),
                arg.Vehicle.Manufacturer(),
                arg.Vehicle.Model(),
                arg.PickRandom(VehicleType.Types),
                arg.Random.Double(1D, 10D),
                arg.Random.Double(1D, 10D),
                arg.PickRandom(EngineData.TypesOfFuel),
                arg.Random.Double(1D, 10D),
                arg.Random.Double(1D, 10D)));
        return faker.Generate(1).Single();
    } 
}