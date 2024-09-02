using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Cars.Domain.Vehicles.Exceptions.Registrations;

public sealed class PeriodTimeToBeforeTimeFromException(DateTime from, DateTime to)
    : CarhubDomainException($"Period to: {to} can not be before from: {from}");   
    