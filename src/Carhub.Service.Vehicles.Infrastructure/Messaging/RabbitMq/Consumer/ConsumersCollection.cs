using Microsoft.Extensions.DependencyInjection;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Consumer;

public class ConsumersCollection
{
    private readonly Dictionary<Type, object> _consumers = new Dictionary<Type, object>();

    public void Add<TMessage>(Func<TMessage, Task> handler)
    {
        _consumers[typeof(TMessage)] = handler;
    }

    public void Build(IServiceCollection services)
    {
        foreach (var consumer in _consumers)
        {
            var methodInfo = typeof(ConsumerRegistryExtension).GetMethod(nameof(ConsumerRegistryExtension.AddConsumer));
            var genericMethod = methodInfo.MakeGenericMethod(consumer.Key);
            genericMethod.Invoke(null, new[] { services, consumer.Value });
        }
    }
}