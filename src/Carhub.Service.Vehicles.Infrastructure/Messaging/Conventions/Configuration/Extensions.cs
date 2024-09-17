using Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicle.Infrastructure.Messaging.Conventions.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddConventions(this IServiceCollection services)
        => services
            .AddSingleton<IConventionProvider, ConventionProvider>();
}