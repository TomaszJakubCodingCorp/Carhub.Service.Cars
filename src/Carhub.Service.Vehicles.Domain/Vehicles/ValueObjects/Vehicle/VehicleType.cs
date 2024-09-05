using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

public sealed class VehicleType : ValueObject
{
    internal static List<string> Types =
    [
        "Passengers Car", "Truck", "Motorcycle"
    ];
    
    public string Value { get; }

    public VehicleType(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyVehicleTypeException();
        }

        if (!Types.Contains(value))
        {
            throw new InvalidVehicleTypeException(value);
        }
        Value = value;
    }

    public static VehicleType PassengerCar()
        => new VehicleType("Passengers Car");
    
    public static VehicleType Truck()
        => new VehicleType("Truck");
    
    public static VehicleType Motorcycle()
        => new VehicleType("Motorcycle");
    
    public static implicit operator VehicleType(string value)
        => new VehicleType(value);

    public static implicit operator string(VehicleType vehicleType)
        => vehicleType.Value;
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}