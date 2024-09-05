using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Service.Vehicles.Application.Commands.RegisterVehicle;
using Carhub.Service.Vehicles.Application.Exceptions;
using Carhub.Service.Vehicles.Domain.Repositories;
using Carhub.Service.Vehicles.Domain.Vehicles.Entities;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Application.Tests.Commands.RegisterVehicle;

public sealed class RegisterVehicleCommandHandlerTests
{
    private Task Act(RegisterVehicleCommand command) => _handler.HandleAsync(command, default);
    
    [Fact]
    public async Task HandleAsync_GivenAlreadyExistingVinNumber_ShouldThrowVinNumberAlreadyRegisteredException()
    {
        //arrange 
        var command = new RegisterVehicleCommand(Guid.NewGuid(), new string('1', 17),"test_brand", 
            "test_model", VehicleType.PassengerCar(),1, 1, EngineData.TypeOfFuelDiesel(), 1, 1);
        _vehicleRepository
            .IsVinNumberExists(Arg.Is<string>(command.VinNumber))
            .Returns(true);
        
        //act
        var exception = await Record.ExceptionAsync(async () => await Act(command));
        
        //assert
        exception.ShouldBeOfType<VinNumberAlreadyRegisteredException>();
    }

    [Fact]
    public async Task HandleAsync_GivenNotExistingVinNumber_ShouldAddVehicleByRepository()
    {
        //arrange 
        var command = new RegisterVehicleCommand(Guid.NewGuid(), new string('1', 17),"test_brand", 
            "test_model", VehicleType.PassengerCar(),1, 1, EngineData.TypeOfFuelDiesel(), 1, 1);
        _vehicleRepository
            .IsVinNumberExists(Arg.Is<string>(command.VinNumber))
            .Returns(false);
        
        //act
        await Act(command);
        
        //assert
        await _vehicleRepository
            .Received(1)
            .AddAsync(Arg.Is<Vehicle>(arg
                => arg.Id.Value == command.Id
                   && arg.VinNumber.Value == command.VinNumber
                   && arg.Brand.Value == command.Brand
                   && arg.Model.Value == command.Model
                   && arg.EngineData.Capacity == command.EngineCapacity
                   && arg.EngineData!.Power == command.EnginePower
                   && arg.EngineData.TypeOfFuel == command.EngineTypeOfFuel
                   && arg.Weight.Gross == command.WeightGross
                   && arg.Weight.Curb == command.WeightCurb), default);
    }
    
    #region arrange
    private readonly  IVehicleRepository _vehicleRepository;
    private readonly ICommandHandler<RegisterVehicleCommand> _handler;

    public RegisterVehicleCommandHandlerTests()
    {
        _vehicleRepository = Substitute.For<IVehicleRepository>();
        _handler = new RegisterVehicleCommandHandler(_vehicleRepository);
    }
    #endregion
}