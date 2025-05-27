using Microsoft.Extensions.DependencyInjection;

namespace SharedLib.EventBus.Abstractions;

public interface IEventBusBuilder
{
    public IServiceCollection Services { get; }
}
