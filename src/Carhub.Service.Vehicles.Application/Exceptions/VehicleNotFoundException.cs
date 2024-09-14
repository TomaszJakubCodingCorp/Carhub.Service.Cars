using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Application.Exceptions;

public sealed class VehicleNotFoundException(Guid id)
    : CarhubApplicationException($"Vehicle with ID: {id} does not exist");