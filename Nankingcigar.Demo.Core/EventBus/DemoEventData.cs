using Abp.Events.Bus;

namespace Nankingcigar.Demo.Core.EventBus
{
    public class DemoEventData<T> : EventData
    {
        public T Data { get; set; }
    }
}