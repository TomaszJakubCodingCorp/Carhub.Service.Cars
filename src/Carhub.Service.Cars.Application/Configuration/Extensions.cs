using Carhub.Lib.Cqrs.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Cars.Application.Configuration;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddCarhubCqrs();
}