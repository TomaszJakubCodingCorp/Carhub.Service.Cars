using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Cars.Domain.Vehicles.Exceptions;

namespace Carhub.Service.Cars.Domain.Vehicles.ValueObjects;

public sealed class VehicleType : ValueObject
{
    private readonly List<string> _types =
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

        if (!_types.Contains(value))
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