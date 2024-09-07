using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

public sealed class NotFinishedRegistrationException(DateOnly presentTimeFrom, DateOnly newTimeFrom) 
    : CarhubDomainException($"Can not append registration with date: {newTimeFrom} which is earlier than present: {presentTimeFrom} and without time to argument");