using Carhub.Lib.MessageBrokers.Outbox.Accessors;
using Carhub.Lib.MessageBrokers.Outbox.Accessors.Abstractions;
using Carhub.Lib.MessageBrokers.Outbox.Decorators.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Lib.MessageBrokers.Outbox.Configuration;

public static class Extensions
{
    public static IServiceCollection AddOutbox(this IServiceCollection services)
        => services
            .AddSingleton<IOutboxMessageAccessor, InMemoryOutboxMessageAccessor>()
            .AddSingleton<IOutboxMessageSaver, InMemoryOutboxMessageAccessor>()
            .AddHostedService<OutboxProcessor>()
            .AddDecorators();
}