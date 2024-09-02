using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Registrations;

public sealed class EmptyNumberException(string number)
    : CarhubDomainException($"Number can not be empty");