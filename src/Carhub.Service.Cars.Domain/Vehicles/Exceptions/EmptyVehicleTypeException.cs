using Carhub.Lib.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions;

public sealed class EmptyVehicleTypeException()
    :   CarhubDomainException("Type can not be empty");
    
    