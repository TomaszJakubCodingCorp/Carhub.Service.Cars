using Carhub.Lib.Cqrs.Commands.Abstractions;
using Carhub.Lib.MessageBrokers.RabbitMq.Configuration;
using Carhub.Service.Vehicles.Application.Commands.Ownership.CreateOwnership;
using Carhub.Service.Vehicles.Application.Commands.Vehicles.AppendVehicleRegistration;
using Carhub.Service.Vehicles.Infrastructure.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.Configuration;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services.AddRabbitMq(configuration,
                consumers =>
                {
                    consumers.AddConsumer<CreateOwnershipCommand>(message =>
                    {
                        var scope = services.BuildServiceProvider();
                        var commandHandler = scope.GetRequiredService<ICommandHandler<CreateOwnershipCommand>>();
                        return commandHandler.HandleAsync(message);
                    });
                    consumers.AddConsumer<AppendVehicleRegistrationCommand>(message =>
                    {
                        var scope = services.BuildServiceProvider();
                        var commandHandler = scope.GetRequiredService<ICommandHandler<AppendVehicleRegistrationCommand>>();
                        return commandHandler.HandleAsync(message);
                    });
                })
            .AddPersistence();
}