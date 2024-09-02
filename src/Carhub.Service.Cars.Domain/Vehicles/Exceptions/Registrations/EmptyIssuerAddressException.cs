using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyIssuerAddressException()
    : CarhubDomainException("Issuer address can not be empty");