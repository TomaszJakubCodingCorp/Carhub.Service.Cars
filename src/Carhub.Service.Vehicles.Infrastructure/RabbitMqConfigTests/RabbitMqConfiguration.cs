using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.RabbitMqConfigTests;

internal sealed class RabbitMqConfiguration
{
    public IRabbitMqServiceCollection WithConsumers { get; set; }
    public bool OutboxEnabled { get; set; }
}