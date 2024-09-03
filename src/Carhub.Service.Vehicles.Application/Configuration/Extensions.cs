using Carhub.Lib.Cqrs.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Application.Configuration;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddCarhubCqrs();
}