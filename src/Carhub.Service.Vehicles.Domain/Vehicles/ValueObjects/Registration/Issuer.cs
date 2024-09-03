using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Registration;

public sealed class Issuer : ValueObject
{
    public string Name { get; }
    public string Address { get; }

    public Issuer(string name, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyIssuerNameException();
        }

        if (string.IsNullOrWhiteSpace(address))
        {
            throw new EmptyIssuerAddressException();
        }
        Name = name;
        Address = address;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}