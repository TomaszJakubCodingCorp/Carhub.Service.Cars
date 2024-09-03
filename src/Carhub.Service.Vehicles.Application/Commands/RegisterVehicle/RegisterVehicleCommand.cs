using Carhub.Lib.Cqrs.Commands.Abstractions;

namespace Carhub.Service.Vehicles.Application.Commands.RegisterVehicle;

public sealed record RegisterVehicleCommand(Guid Id, string VinNumber, string Brand, string Model, double EngineCapacity,
    double EnginePower, string EngineTypeOfFuel, double WeightGross, double WeightCurb) : ICommand;