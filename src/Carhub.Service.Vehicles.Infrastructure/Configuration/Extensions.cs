using Carhub.Service.Vehicles.Infrastructure.Messaging.Configuration;
using Carhub.Service.Vehicles.Infrastructure.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.Configuration;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddMessaging(configuration)
            .AddPersistence();
}