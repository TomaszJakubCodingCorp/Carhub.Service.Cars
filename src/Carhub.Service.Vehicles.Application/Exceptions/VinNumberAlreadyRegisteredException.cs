using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Application.Exceptions;

public sealed class VinNumberAlreadyRegisteredException(string vinNumber)
    : CarhubApplicationException($"Vin number: {vinNumber} is already in use");