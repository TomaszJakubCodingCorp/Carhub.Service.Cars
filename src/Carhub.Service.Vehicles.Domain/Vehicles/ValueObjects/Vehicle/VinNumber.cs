using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

public sealed class VinNumber : ValueObject
{
    private const int _length = 17;
    public string Value { get; }

    public VinNumber(string value)
    {
        if (value.Length is not _length)
        {
            throw new InvalidVinNumberLengthException(value);
        }
        Value = value;
    }

    public static implicit operator VinNumber(string value)
        => new VinNumber(value);

    public static implicit operator string(VinNumber vinNumber)
        => vinNumber?.Value;
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}