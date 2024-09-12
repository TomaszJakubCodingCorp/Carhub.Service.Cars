using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

public class CollisionRegistrationDatesException(DateOnly? presentTimeFrom, DateOnly? presentTimeTo, DateOnly newTimeFrom, DateOnly? newTimeTo)
    : CarhubDomainException($"New dates: {newTimeFrom} - {newTimeTo} and present registration dates: {presentTimeFrom} - {presentTimeTo} have collision");