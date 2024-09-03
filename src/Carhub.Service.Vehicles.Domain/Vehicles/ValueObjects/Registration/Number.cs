using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Registration;

public sealed class Number : ValueObject
{
    public string Value { get; }

    public Number(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyNumberException();
        }
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}