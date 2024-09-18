using Carhub.Service.Vehicles.Application;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.Conventions.Abstractions;

internal interface IConventionProvider
{
    IConvention Get<TMessage>() where TMessage : IEvent;
}