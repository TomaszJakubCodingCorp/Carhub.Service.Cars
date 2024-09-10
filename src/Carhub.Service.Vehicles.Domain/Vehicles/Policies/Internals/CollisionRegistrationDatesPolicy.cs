using Carhub.Service.Vehicles.Domain.Vehicles.Entities;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;

internal sealed class CollisionRegistrationDatesPolicy : IRegistrationDatesPolicy
{
    public void Validate(Vehicle vehicle, DateOnly periodFrom, DateOnly periodTo)
    {
        throw new NotImplementedException();
    }
}

internal sealed class NotFinishedRegistrationDatesPolicy
{
    
}