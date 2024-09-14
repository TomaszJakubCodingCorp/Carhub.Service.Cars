using System.Security.Cryptography;
using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Service.Vehicles.Application.Commands.AppendVehicleRegistration;
using Carhub.Service.Vehicles.Application.Exceptions;
using Carhub.Service.Vehicles.Domain.Repositories;
using Carhub.Service.Vehicles.Tests.Shared.Domain.Vehicles;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Application.Tests.Commands.AppendVehicleRegistration;

public sealed class AppendRegistrationVehicleCommandHandlerTests
{
    private Task Act(AppendVehicleRegistrationCommand command) => _handler.HandleAsync(command, default);

    [Fact]
    public async Task HandleAsync_GivenExistingVehicle_ShouldUpdateVehicleByRepository()
    {
        //arrange
        var vehicle = VehicleFactory.Get();
        
        var command = new AppendVehicleRegistrationCommand(vehicle.Id, Guid.NewGuid(), new DateOnly(2020, 1, 1),
            null, "test_number", "test_issuer_name", "test_issuer_address",
            "test_owner_fullname", "test_owner_identity_number", "test_owner_address");

        _vehicleRepository
            .GetAsync(command.Id, default)
            .Returns(vehicle);
        
        //act
        await Act(command);
        
        //assert
        vehicle.Registrations.Any(x => x.Id.Value == command.Id).ShouldBeTrue();
        
        await _vehicleRepository
            .Received(1)
            .UpdateAsync(vehicle, default);
    }
    
    [Fact]
    public async Task HandleAsync_GivenNotExistingVehicle_ShouldThrowVehicleNotFoundException()
    {
        //arrange
        var command = new AppendVehicleRegistrationCommand(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2020, 1, 1),
            null, "test_number", "test_issuer_name", "test_issuer_address",
            "test_owner_fullname", "test_owner_identity_number", "test_owner_address");
        
        //act
        var exception = await Record.ExceptionAsync(async () => await Act(command));
        
        //assert
        exception.ShouldBeOfType<VehicleNotFoundException>();
    }
    
    #region arrange
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ICommandHandler<AppendVehicleRegistrationCommand> _handler;

    public AppendRegistrationVehicleCommandHandlerTests()
    {
        _vehicleRepository = Substitute.For<IVehicleRepository>();
        _handler = new AppendVehicleRegistrationCommandHandler(_vehicleRepository);
    }
    #endregion
}