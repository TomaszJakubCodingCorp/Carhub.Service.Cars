using Carhub.Lib.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions;

public sealed class EmptyBrandException() 
    : CarhubDomainException("Brand can not be empty");