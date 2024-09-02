using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Vehicles;

public sealed class InvalidVinNumberLengthException(string vinNumber)
    : CarhubDomainException($"Vin number: {vinNumber} has invalid length");