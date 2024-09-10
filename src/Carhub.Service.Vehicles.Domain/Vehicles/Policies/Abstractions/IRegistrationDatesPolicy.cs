using Carhub.Service.Vehicles.Domain.Vehicles.Entities;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;

public interface IRegistrationDatesPolicy
{
    void Validate(Vehicle vehicle, DateOnly periodFrom, DateOnly periodTo);
}