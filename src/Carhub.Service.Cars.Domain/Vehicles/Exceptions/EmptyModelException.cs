using Carhub.Lib.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions;

public sealed class EmptyModelException() : 
    CarhubDomainException("Model can not be empty");