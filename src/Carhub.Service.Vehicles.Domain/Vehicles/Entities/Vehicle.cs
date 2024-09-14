using System.Collections.Immutable;
using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

namespace Carhub.Service.Vehicles.Domain.Vehicles.Entities;

public sealed class Vehicle : AggregateRoot
{
    private readonly HashSet<Registration> _registrations = new HashSet<Registration>();
    public VinNumber VinNumber { get; }
    public Brand Brand { get; }
    public Model Model { get; }
    public VehicleType VehicleType { get; }
    public EngineData EngineData { get; private set; }
    public Weight Weight { get; }
    public IReadOnlyList<Registration> Registrations => _registrations.ToImmutableList();
    
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

    public void AppendRegistration(Guid id, DateOnly periodFrom, DateOnly? periodTo, string number, string issuerName,
        string issuerAddress, string ownerFullName, string ownerIdentityNumber, string ownerAddress)
    {
        var policyFactory = RegistrationDatesPolicyFactory.GetInstance();
        var policy = policyFactory.Create(periodTo is null);
        policy.Validate(this, periodFrom, periodTo);

        if (periodTo is null && _registrations.Any()) 
        {
            if (_registrations.Last().Period.To is null)
            {
                _registrations.Last().FinishPeriod(periodFrom.AddDays(-1));
            }
        }
        
        var registration = Registration.Create(id, periodFrom, periodTo, number, issuerName, issuerAddress,
            ownerFullName, ownerIdentityNumber, ownerAddress);
        _registrations.Add(registration);
    }
}