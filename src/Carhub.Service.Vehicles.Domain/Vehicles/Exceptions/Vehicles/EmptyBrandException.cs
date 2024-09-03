using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

public sealed class EmptyBrandException() 
    : CarhubDomainException("Brand can not be empty");