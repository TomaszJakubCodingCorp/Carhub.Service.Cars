using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions;

public sealed class EmptyTypeOfFuelException()
    : CarhubDomainException("Type of fuel can not be empty");