using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Lib.MessageBrokers.Abstractions;
using Carhub.Service.Vehicles.Application.Events;
using Carhub.Service.Vehicles.Application.Exceptions;
using Carhub.Service.Vehicles.Domain.Repositories;
using Carhub.Service.Vehicles.Domain.Vehicles.Entities;

namespace Carhub.Service.Vehicles.Application.Commands.RegisterVehicle;

internal sealed class RegisterVehicleCommandHandler(
    IVehicleRepository vehicleRepository,
    IEventPublisher eventPublisher) : ICommandHandler<RegisterVehicleCommand>
{
    public async Task HandleAsync(RegisterVehicleCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        if (await vehicleRepository.IsVinNumberExistsAsync(command.VinNumber, cancellationToken))
        {
            throw new VinNumberAlreadyRegisteredException(command.VinNumber);
        }

        var vehicle = Vehicle.Create(command.Id, command.VinNumber, command.Brand, command.Model, command.Type,
            command.EngineCapacity, command.EnginePower, command.EngineTypeOfFuel, command.WeightGross,
            command.WeightCurb);
        await vehicleRepository.AddAsync(vehicle, cancellationToken);
        await eventPublisher.Publish(new VehicleRegistered(command.Id));
    }
}