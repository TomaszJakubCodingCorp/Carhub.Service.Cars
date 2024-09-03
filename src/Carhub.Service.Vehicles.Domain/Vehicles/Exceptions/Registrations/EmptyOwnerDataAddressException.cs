using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyOwnerDataAddressException()
    : CarhubDomainException("Owner data address can not be empty");