using Carhub.Lib.MessageBrokers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Lib.MessageBrokers.Outbox.Decorators.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDecorators(this IServiceCollection services)
    {
        services.TryDecorate(typeof(IEventPublisher), typeof(OutboxEventPublisherDecorator));
        return services;
    }
}