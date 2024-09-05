using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

public sealed class EngineData : ValueObject
{
    internal static List<string> TypesOfFuel = [
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

        if (!TypesOfFuel.Contains(typeOfFuel))
        {
            throw new InvalidTypeOfFuelException(typeOfFuel);
        }
        TypeOfFuel = typeOfFuel;
    }

    public static string TypeOfFuelPetrol()
        => "Petrol";
    public static string TypeOfFuelDiesel()
        => "Diesel";
    public static string TypeOfFuelElectricity()
        => "Electricity";
    public static string TypeOfFuelHybrid()
        => "Hybrid";
    public static string TypeOfFuelHydrogen()
        => "Hydrogen";

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Capacity;
        yield return Power;
        yield return TypeOfFuel;
    }
}