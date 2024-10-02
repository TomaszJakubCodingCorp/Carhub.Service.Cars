using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Outbox.Accessors.Abstractions;
using Carhub.Service.Vehicles.Infrastructure.Outbox.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Carhub.Service.Vehicles.Infrastructure.Outbox;

internal sealed class OutboxProcessor : BackgroundService
{
    private readonly ILogger<OutboxProcessor> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IEventPublisher _eventPublisher;
    private readonly bool _enabled;
    private readonly TimeSpan _interval;
    
    public OutboxProcessor(
        ILogger<OutboxProcessor> logger,
        IServiceProvider serviceProvider,
        IEventPublisher eventPublisher,
        IOptions<OutboxOptions> options)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _eventPublisher = eventPublisher;
        _interval = options.Value.Interval;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(_interval);
        while (!stoppingToken.IsCancellationRequested 
               && await timer.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation("Started processing outbox messages");
            var messageAccessor = _serviceProvider.GetRequiredService<IOutboxMessageAccessor>();
            var unsentMessages = await messageAccessor.GetUnsentAsync(stoppingToken);
            if (!unsentMessages.Any())
            {
                _logger.LogInformation("No messages to be processed by outbox processor");
                return;
            }

            foreach (var message in unsentMessages.OrderBy(x => x.SentAt))
            {
                
            }
        }
    }
}