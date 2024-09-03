using Carhub.Service.Vehicles.Domain.Vehicles.Entities;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Vehicles;

public sealed class VehicleTests 
{
    [Fact]
    public void Create_GivenValidArguments_ShouldReturnVehicle()
    {
        //arrange
        var id = Guid.NewGuid();
        var vinNumber = new string('t', 17);
        var testBrand = "test_brand";
        var testModel = "test_model";
        var vehicleType = VehicleType.PassengerCar();
        var capacity = 10;
        var power = 10;
        var typeOfFuel = EngineData.TypeOfFuelDiesel();
        var gross = 1;
        var curb = 2; 
        
        //act
        var vehicle = Vehicle.Create(id, vinNumber, testBrand, testModel, vehicleType, capacity,
            power, typeOfFuel, gross, curb);
        
        //assert
        vehicle.Id.Value.ShouldBe(id);
        vehicle.VinNumber.Value.ShouldBe(vinNumber);
        vehicle.Brand.Value.ShouldBe(testBrand);
        vehicle.Model.Value.ShouldBe(testModel);
        vehicle.VehicleType.Value.ShouldBe(vehicleType);
        vehicle.EngineData.Capacity.ShouldBe(capacity);
        vehicle.EngineData.Power.ShouldBe(power);
        vehicle.EngineData.TypeOfFuel.ShouldBe(typeOfFuel);
        vehicle.Weight.Gross.ShouldBe(gross);
        vehicle.Weight.Curb.ShouldBe(curb);
    }
    
    [Theory]
    [InlineData(14)]
    [InlineData(18)]
    [InlineData(0)]
    public void Create_GivenInvalidVinNumberLength_ShouldThrowInvalidVinNumberLengthException(int multiplier)
    {
        //arrange
        var vinNumber = new string('t', multiplier);
        
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), vinNumber, "test_brand",
            "test_model", VehicleType.PassengerCar(), 10, 10, EngineData.TypeOfFuelDiesel(),
            1, 2));
        
        //assert
        exception.ShouldBeOfType<InvalidVinNumberLengthException>();
    }

    [Fact]
    public void Create_GivenEmptyBrand_ShouldThrowEmptyBrandException()
    {
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), new string('t', 17), string.Empty,
            "test_model", VehicleType.PassengerCar(), 10, 10, EngineData.TypeOfFuelDiesel(),
            1, 2));
        
        //assert
        exception.ShouldBeOfType<EmptyBrandException>();
    }
    
    [Fact]
    public void Create_GivenEmptyModel_ShouldThrowEmptyModelException()
    {
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), new string('t', 17), "test_brand",
            string.Empty, VehicleType.PassengerCar(), 10, 10, EngineData.TypeOfFuelDiesel(),
            1, 2));
        
        //assert
        exception.ShouldBeOfType<EmptyModelException>();
    }
    
    [Fact]
    public void Create_GivenEmptyVehicleType_ShouldThrowEmptyVehicleTypeException()
    {
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), new string('t', 17), "test_brand",
            "test_model", string.Empty, 10, 10, EngineData.TypeOfFuelDiesel(),
            1, 2));
        
        //assert
        exception.ShouldBeOfType<EmptyVehicleTypeException>();
    }
    
    [Fact]
    public void Create_GivenInvalidVehicleType_ShouldThrowInvalidVehicleTypeException()
    {
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), new string('t', 17), "test_brand",
            "test_model", "test_type", 10, 10, EngineData.TypeOfFuelDiesel(),
            1, 2));
        
        //assert
        exception.ShouldBeOfType<InvalidVehicleTypeException>();
    }
    
    [Fact]
    public void Create_GivenEmptyTypeOfFuel_ShouldThrowEmptyTypeOfFuelException()
    {
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), new string('t', 17), "test_brand",
            "test_model", VehicleType.PassengerCar(), 10, 10, string.Empty,
            1, 2));
        
        //assert
        exception.ShouldBeOfType<EmptyTypeOfFuelException>();
    }
    
    [Fact]
    public void Create_GivenInvalidTypeOfFuel_ShouldThrowInvalidTypeOfFuelException()
    {
        //act
        var exception = Record.Exception(() => Vehicle.Create(Guid.NewGuid(), new string('t', 17), "test_brand",
            "test_model", VehicleType.PassengerCar(), 10, 10, "test_type_of_fuel",
            1, 2));
        
        //assert
        exception.ShouldBeOfType<InvalidTypeOfFuelException>();
    }
}