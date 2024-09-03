using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyOwnerDataFullNameException()
    : CarhubDomainException("Owner data full name can not be empty");