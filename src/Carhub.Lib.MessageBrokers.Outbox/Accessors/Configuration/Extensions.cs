using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Lib.MessageBrokers.Outbox.Accessors.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddOutboxAccessors(this IServiceCollection services)
        => services;
}