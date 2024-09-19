using Carhub.Lib.Cqrs.Commands.Abstractions;

namespace Carhub.Service.Vehicles.Application.Commands.Vehicles.AppendVehicleRegistration;

public sealed record AppendVehicleRegistrationCommand(Guid VehicleId, Guid Id, DateOnly PeriodFrom,
    DateOnly? PeriodTo, string Number, string IssuerName, string IssuerAddress, string OwnerFullName,
    string OwnerIdentityNumber, string OwnerAddress) : ICommand;