using System.Reflection.Metadata;
using System.Text;
using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Connections;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Serializing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq;

internal class RabbitMqBackgroundService<TMessage> : BackgroundService where TMessage : class, IConsumer
{
    private readonly ILogger<RabbitMqBackgroundService<TMessage>> _logger;
    private readonly IConnection _connection;
    private readonly IRabbitMqSerializer _rabbitMqSerializer;
    private readonly Func<TMessage, Task> _handle;
    
    public RabbitMqBackgroundService(
        ILogger<RabbitMqBackgroundService<TMessage>> logger, 
        ConsumerConnection consumerConnection,
        IRabbitMqSerializer rabbitMqSerializer,
        Func<TMessage,Task> handle)
    {
        _logger = logger;
        _connection = consumerConnection.Connection;
        _rabbitMqSerializer = rabbitMqSerializer;
        _handle = handle;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var channel = _connection.CreateModel();
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var messageBytes = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(messageBytes);
            var message = _rabbitMqSerializer.ToObject<TMessage>(json);
            await _handle(message);
        };
        return Task.CompletedTask;
    }
}