using System.Text;
using Newtonsoft.Json;

namespace Carhub.Service.Vehicles.Infrastructure.Messaging.RabbitMq.Serializing;

internal sealed class RabbitMqSerializer : IRabbitMqSerializer
{
    private readonly JsonSerializerSettings _settings = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
    };

    public ReadOnlySpan<byte> ToJson<TMessage>(TMessage message) where TMessage : class
        => Encode(Serialize(message));
    private string Serialize(object value) => JsonConvert.SerializeObject(value, _settings);
    private static ReadOnlySpan<byte> Encode(string value) => Encoding.UTF8.GetBytes(value);
}