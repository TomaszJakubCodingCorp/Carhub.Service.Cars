using System.Reflection;
using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Abstractions;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Configuration;
using Microsoft.Extensions.Options;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions;

internal sealed class ConventionProvider(IOptions<RabbitMqOptions> options) : IConventionProvider
{
    private readonly string _connectionName = options.Value.ConnectionName;

    public IConvention Get<TMessage>() where TMessage : IEvent
    {
        var exchange = _connectionName;
        var routingKey = typeof(TMessage).Name;
        return new Convention(exchange, routingKey);
    }
}