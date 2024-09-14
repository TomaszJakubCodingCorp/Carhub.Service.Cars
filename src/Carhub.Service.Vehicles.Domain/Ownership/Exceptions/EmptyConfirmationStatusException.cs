using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Ownership.Exceptions;

public sealed class EmptyConfirmationStatusException()
    : CarhubDomainException("Confirmation status can not be empty");