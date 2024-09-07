using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Registration;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Entities;

public sealed class Registration
{
    public EntityId Id { get; }
    public Period Period { get; private set; }
    public Number Number { get; private set; }
    public Issuer Issuer { get; private set; }
    public OwnerData OwnerData { get; private set; }
    
    private Registration(EntityId id)
        => Id = id;

    internal static Registration Create(Guid id, DateOnly periodFrom, string number, string issuerName,
        string issuerAddress, string ownerFullName, string ownerIdentityNumber, string ownerAddress)
    {
        var registration = new Registration(id);
        registration.ChangePeriod(periodFrom);
        registration.ChangeNumber(number);
        registration.ChangeIssuer(issuerName, issuerAddress);
        registration.ChangeOwnerDate(ownerFullName, ownerIdentityNumber, ownerAddress);
        return registration;
    }

    private void ChangePeriod(DateOnly from)
        => Period = new Period(from);

    private void ChangeNumber(string number)
        => Number = new Number(number);

    private void ChangeIssuer(string name, string address)
        => Issuer = new Issuer(name, address);

    private void ChangeOwnerDate(string fullName, string identityNumber, string address)
        => OwnerData = new OwnerData(fullName, identityNumber, address);
}