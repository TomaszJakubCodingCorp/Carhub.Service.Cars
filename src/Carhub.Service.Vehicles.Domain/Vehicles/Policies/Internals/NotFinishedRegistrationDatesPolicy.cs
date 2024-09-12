using Carhub.Service.Vehicles.Domain.Vehicles.Entities;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;

internal sealed class NotFinishedRegistrationDatesPolicy : IRegistrationDatesPolicy
{
    public void Validate(Vehicle vehicle, DateOnly periodFrom, DateOnly? periodTo)
    {
        var presentRegistration = vehicle.Registrations.FirstOrDefault(x
            => x.Period.To is null 
            && x.Period.From > periodFrom);
        
        if (presentRegistration is not null)
        {
            throw new NotFinishedRegistrationException(presentRegistration.Period.From, periodFrom);
        }
    }
}