using Carhub.Lib.Cqrs.Commands.Abstractions;

namespace Carhub.Service.Vehicles.Application.Commands.Vehicles.RegisterVehicle;

public sealed record RegisterVehicleCommand(Guid Id, string VinNumber, string Brand, string Model, 
    string Type, double EngineCapacity, double EnginePower, string EngineTypeOfFuel, 
    double WeightGross, double WeightCurb) : ICommand;