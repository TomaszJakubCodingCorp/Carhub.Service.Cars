using Carhub.Lib.Cqrs.Commands.Abstractions;

namespace Carhub.Service.Vehicles.Application.Commands.Ownership.CreateOwnership;

public sealed record CreateOwnershipCommand(Guid VehicleId) : ICommand, IConsumer;