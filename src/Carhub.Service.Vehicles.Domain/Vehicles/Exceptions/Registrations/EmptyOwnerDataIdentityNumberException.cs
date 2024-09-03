using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyOwnerDataIdentityNumberException() 
    : CarhubDomainException("Owner data identity number can not be empty");