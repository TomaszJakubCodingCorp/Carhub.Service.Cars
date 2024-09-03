using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Registration;

public sealed class OwnerData : ValueObject
{
    public string FullName { get; }
    public string IdentityNumber { get; }
    public string Address { get; }

    public OwnerData(string fullName, string identityNumber, string address)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new EmptyOwnerDataFullNameException();
        }

        if (string.IsNullOrWhiteSpace(identityNumber))
        {
            throw new EmptyOwnerDataIdentityNumberException();
        }

        if (string.IsNullOrWhiteSpace(address))
        {
            throw new EmptyOwnerDataAddressException();
        }
        FullName = fullName;
        IdentityNumber = identityNumber;
        Address = address;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}