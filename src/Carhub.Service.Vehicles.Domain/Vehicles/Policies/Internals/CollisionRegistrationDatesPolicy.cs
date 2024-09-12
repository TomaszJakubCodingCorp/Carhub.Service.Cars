using Carhub.Service.Vehicles.Domain.Vehicles.Entities;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;

internal sealed class CollisionRegistrationDatesPolicy : IRegistrationDatesPolicy
{
    public void Validate(Vehicle vehicle, DateOnly periodFrom, DateOnly? periodTo)
    {
        var beginEarlierAndFinishLaterRegistration = vehicle.Registrations
            .FirstOrDefault(x => x.Period.From > periodFrom && x.Period.From < periodTo);
        if (beginEarlierAndFinishLaterRegistration is not null)
        {
            throw new CollisionRegistrationDatesException(beginEarlierAndFinishLaterRegistration.Period.From,
                beginEarlierAndFinishLaterRegistration.Period.To, periodFrom, periodTo);
        }

        var isEqualRegistration = vehicle.Registrations.FirstOrDefault(x
            => x.Period.From == periodFrom
            || x.Period.From == periodTo
            || x.Period.To == periodFrom
            || x.Period.To == periodTo);
        
        if (isEqualRegistration is not null)
        {
            throw new CollisionRegistrationDatesException(isEqualRegistration.Period.From,
                isEqualRegistration.Period.To, periodFrom, periodTo);
        }
    }
}