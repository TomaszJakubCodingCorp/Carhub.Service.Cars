using System.Reflection;
using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Abstractions;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions;

internal sealed class ConventionProvider : IConventionProvider
{
    public IConvention Get<TMessage>() where TMessage : IEvent
    {
        var appName = Assembly.GetExecutingAssembly().FullName;
        var appNameParts = appName?.Split('.');
        var exchange = $"{appNameParts?[0]}_{appNameParts?[2]}";
        var routingKey = typeof(TMessage).Name;
        return new Convention(exchange, routingKey);
    }
}