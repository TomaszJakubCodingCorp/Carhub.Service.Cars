using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

public sealed class InvalidVehicleTypeException(string type)
    : CarhubDomainException($"Type: {type} is not into available types");