using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

public sealed class Brand : ValueObject
{
    public string Value { get; }

    private Brand(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyBrandException();
        }
        Value = value;
    }

    public static implicit operator Brand(string value)
        => new Brand(value);

    public static implicit operator string(Brand brand)
        => brand?.Value;
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}