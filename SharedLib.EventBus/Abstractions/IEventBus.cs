
using SharedLib.EventBus.Events;

namespace SharedLib.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}
