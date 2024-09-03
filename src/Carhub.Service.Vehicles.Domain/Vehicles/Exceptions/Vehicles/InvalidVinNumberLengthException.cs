using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

public sealed class InvalidVinNumberLengthException(string vinNumber)
    : CarhubDomainException($"Vin number: {vinNumber} has invalid length");