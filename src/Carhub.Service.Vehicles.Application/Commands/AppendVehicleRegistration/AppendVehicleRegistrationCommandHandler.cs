using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Service.Vehicles.Application.Exceptions;
using Carhub.Service.Vehicles.Domain.Repositories;

namespace Carhub.Service.Vehicles.Application.Commands.AppendVehicleRegistration;

internal sealed class AppendVehicleRegistrationCommandHandler(
    IVehicleRepository vehicleRepository) : ICommandHandler<AppendVehicleRegistrationCommand>
{
    public async Task HandleAsync(AppendVehicleRegistrationCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var vehicle = await vehicleRepository.GetAsync(command.Id, cancellationToken);
        if (vehicle is null)
        {
            throw new VehicleNotFoundException(command.Id);
        }
        vehicle.AppendRegistration(command.Id, command.PeriodFrom, command.PeriodTo, command.Number, command.IssuerName,
            command.IssuerAddress, command.OwnerFullName, command.OwnerIdentityNumber, command.OwnerAddress);
        await vehicleRepository.UpdateAsync(vehicle, cancellationToken);
    }
}