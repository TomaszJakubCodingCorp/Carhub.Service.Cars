using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyIssuerNameException()
    : CarhubDomainException("Issuer name can not be empty");