using Carhub.Lib.SharedKernel;
using Carhub.Service.Cars.Domain.Vehicles.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.ValueObjects;

public sealed class Brand : ValueObject
{
    private string Value { get; }

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