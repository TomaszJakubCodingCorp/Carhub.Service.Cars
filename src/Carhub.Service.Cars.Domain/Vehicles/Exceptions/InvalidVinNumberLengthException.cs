using Carhub.Lib.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions;

public sealed class InvalidVinNumberLengthException(string vinNumber)
    : CarhubDomainException($"Vin number: {vinNumber} has invalid length");