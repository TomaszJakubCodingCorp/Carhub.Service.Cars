using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

public sealed class PeriodTimeToBeforeTimeFromException(DateOnly from, DateOnly to)
    : CarhubDomainException($"Period to: {to} can not be before from: {from}");   
    