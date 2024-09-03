using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Entities;

public sealed class Vehicle : AggregateRoot
{
    public VinNumber VinNumber { get; }
    public Brand Brand { get; }
    public Model Model { get; }
    public VehicleType VehicleType { get; }
    public EngineData EngineData { get; private set; }
    public Weight Weight { get; }
    
    private Vehicle(AggregateId id, VinNumber vinNumber, Brand brand, Model model,
        VehicleType vehicleType, Weight weight)
        : base(id)
    {
        VinNumber = vinNumber;
        Brand = brand;
        Model = model;
        VehicleType = vehicleType;
        Weight = weight;
    }

    public static Vehicle Create(Guid id, string vinNumber, string brand, string model,
        string type, double capacity, double power, string typeOfFuel,  double gross, double curb)
    {
        var vehicle = new Vehicle(id, vinNumber, brand, model, type, new Weight(gross, curb));
        vehicle.ChangeEngineData(capacity, power, typeOfFuel);
        return vehicle;
    }

    private void ChangeEngineData(double capacity, double power, string typeOfFuel)
        => EngineData = new EngineData(capacity, power, typeOfFuel);
}