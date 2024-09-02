using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Service.Cars.Domain.Repositories;

namespace Carhub.Service.Cars.Application.Commands.AddVehicle;

internal sealed class AddVehicleCommandHandler(
    IVehicleRepository vehicleRepository) : ICommandHandler<AddVehicleCommand>
{
    public Task HandleAsync(AddVehicleCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}