using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

public sealed class Model : ValueObject
{
    public string Value { get; }
    
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