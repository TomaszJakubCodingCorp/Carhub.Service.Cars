using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Ownership.Exceptions;

public sealed class UnavailableConfirmationStatusException(string status)
    : CarhubDomainException($"Confirmation status: {status} is not available");