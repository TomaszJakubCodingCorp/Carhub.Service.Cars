using Carhub.Lib.SharedKernel;
using Carhub.Service.Cars.Domain.Vehicles.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.ValueObjects;

public sealed class Model : ValueObject
{
    private string Value { get; }
    
    public Model(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyModelException();
        }
        Value = value;
    }

    public static implicit operator Model(string value)
        => new Model(value);

    public static implicit operator string(Model model)
        => model?.Value;
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}