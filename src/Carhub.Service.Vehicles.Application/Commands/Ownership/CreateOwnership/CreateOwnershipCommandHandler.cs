using Carhub.Lib.Cqrs.Commands.Abstractions;
using Microsoft.Extensions.Logging;

namespace Carhub.Service.Vehicles.Application.Commands.Ownership.CreateOwnership;

internal sealed class CreateOwnershipCommandHandler(
    ILogger<CreateOwnershipCommandHandler> logger) : ICommandHandler<CreateOwnershipCommand>
{
    public Task HandleAsync(CreateOwnershipCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        logger.LogInformation(command.VehicleId.ToString());
        return Task.CompletedTask;
    }
}