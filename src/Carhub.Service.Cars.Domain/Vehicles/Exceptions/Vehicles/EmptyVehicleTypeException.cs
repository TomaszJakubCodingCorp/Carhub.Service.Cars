using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Vehicles;

public sealed class EmptyVehicleTypeException()
    :   CarhubDomainException("Type can not be empty");
    
    