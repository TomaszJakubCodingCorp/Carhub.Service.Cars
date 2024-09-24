using Carhub.Service.Vehicles.Application;
using Carhub.Service.Vehicles.Infrastructure.Outbox.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Carhub.Service.Vehicles.Infrastructure.Outbox;

internal sealed class OutboxProcessor : IHostedService
{
    private readonly ILogger<OutboxProcessor> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IEventPublisher _eventPublisher;
    private readonly bool _enabled;
    private readonly TimeSpan _interval;
    private Timer _timer;
    
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
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (_enabled)
        {
            _timer = new Timer(Execute, null, TimeSpan.Zero, _interval);
        }

        return Task.CompletedTask;
    }

    private void Execute(object state)
    {
        
    }
    
    

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}