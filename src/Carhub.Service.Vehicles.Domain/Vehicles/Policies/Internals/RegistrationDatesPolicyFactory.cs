using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;

internal sealed class RegistrationDatesPolicyFactory : IRegistrationDatesPolicyFactory
{
    private RegistrationDatesPolicyFactory()
    {
    }

    internal static IRegistrationDatesPolicyFactory GetInstance()
        => new RegistrationDatesPolicyFactory();

    public IRegistrationDatesPolicy Create(bool isDateToIsNull) => isDateToIsNull switch
    {
        true => new NotFinishedRegistrationDatesPolicy(),
        false => new CollisionRegistrationDatesPolicy()
    };
}