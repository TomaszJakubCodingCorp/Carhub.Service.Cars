using System.Reflection.Metadata;
using System.Text;
using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Configuration;
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
    private readonly ConsumerOptions _consumerOptions;
    private readonly Func<TMessage, Task> _handle;
    
    public RabbitMqBackgroundService(
        ILogger<RabbitMqBackgroundService<TMessage>> logger, 
        ConsumerConnection consumerConnection,
        IRabbitMqSerializer rabbitMqSerializer,
        ConsumerOptions consumerOptions,
        Func<TMessage,Task> handle)
    {
        _logger = logger;
        _connection = consumerConnection.Connection;
        _rabbitMqSerializer = rabbitMqSerializer;
        _consumerOptions = consumerOptions;
        _handle = handle;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var channel = _connection.CreateModel();
        channel.ExchangeDeclare(_consumerOptions.Exchange, ExchangeType.Direct, true, false);
        channel.QueueDeclare(_consumerOptions.Queue, true, false, false);
        channel.QueueBind(_consumerOptions.Queue, _consumerOptions.Exchange, _consumerOptions.Routing);
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var messageBytes = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(messageBytes);
            var message = _rabbitMqSerializer.ToObject<TMessage>(json);
            await _handle(message);
        };
        channel.BasicConsume(queue: _consumerOptions.Queue,
            autoAck: true,
            consumer: consumer);
        return Task.CompletedTask;
    }
}