using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyNumberException()
    : CarhubDomainException($"Number can not be empty");