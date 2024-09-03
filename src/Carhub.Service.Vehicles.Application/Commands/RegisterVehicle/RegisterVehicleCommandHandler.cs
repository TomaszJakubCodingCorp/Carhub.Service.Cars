using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Service.Vehicles.Domain.Repositories;

namespace Carhub.Service.Vehicles.Application.Commands.RegisterVehicle;

internal sealed class RegisterVehicleCommandHandler(
    IVehicleRepository vehicleRepository) : ICommandHandler<RegisterVehicleCommand>
{
    public Task HandleAsync(RegisterVehicleCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }
}