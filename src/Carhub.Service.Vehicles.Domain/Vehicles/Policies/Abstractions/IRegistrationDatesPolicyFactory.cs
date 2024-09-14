namespace Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;

public interface IRegistrationDatesPolicyFactory
{
    IRegistrationDatesPolicy Create(bool isDateToIsNull);
}