using Carhub.Lib.Cqrs.Commands.Abstractions;

namespace Carhub.Service.Cars.Application.Commands.AddVehicle;

public sealed record AddVehicleCommand(Guid Id, string Brand, string Model, double EngineCapacity,
    double EnginePower, string EngineTypeOfFuel, double WeightGross, double WeightCurb) : ICommand;