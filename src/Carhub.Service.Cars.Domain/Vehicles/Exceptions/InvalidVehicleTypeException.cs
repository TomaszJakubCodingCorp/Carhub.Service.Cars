using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions;

public sealed class InvalidVehicleTypeException(string type)
    : CarhubDomainException($"Type: {type} is not into available types");