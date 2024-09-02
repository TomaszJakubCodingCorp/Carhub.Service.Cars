using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Vehicles;

public sealed class EmptyModelException() : 
    CarhubDomainException("Model can not be empty");