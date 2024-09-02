using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Vehicles;

public sealed class InvalidTypeOfFuelException(string typeOfFuel)
    : CarhubDomainException($"Type of fuel: {typeOfFuel} is not available");