using Carhub.Lib.SharedKernel.SharedKernel;

namespace Carhub.Service.Cars.Domain.Vehicles.ValueObjects.Registration;

public sealed class Number : ValueObject
{
    public string Value { get; }

    public Number(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}