using Carhub.Lib.SharedKernel;
using Carhub.Service.Cars.Domain.Vehicles.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.ValueObjects;

public sealed class EngineData : ValueObject
{
    private readonly List<string> _typesOfFuel = [
        "Petrol", "Diesel", "Electricity", "Hybrid", "Hydrogen"
    ];
    
    public double Capacity { get; }
    public double Power { get; }
    public string TypeOfFuel { get; }

    public EngineData(double capacity, double power, string typeOfFuel)
    {
        Capacity = capacity;
        Power = power;
        if (string.IsNullOrWhiteSpace(typeOfFuel))
        {
            throw new EmptyTypeOfFuelException();
        }

        if (!_typesOfFuel.Contains(typeOfFuel))
        {
            throw new InvalidTypeOfFuelException(typeOfFuel);
        }
        TypeOfFuel = typeOfFuel;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Capacity;
        yield return Power;
        yield return TypeOfFuel;
    }
}