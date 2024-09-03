using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Service.Vehicles.Application.Commands.RegisterVehicle;
using Carhub.Service.Vehicles.Domain.Repositories;
using Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;
using NSubstitute;
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
            "test_model", 1, 1, EngineData.TypeOfFuelDiesel(), 1, 1);
        
        //act
        
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