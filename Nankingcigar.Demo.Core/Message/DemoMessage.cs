using Abp.Events.Bus;

namespace Nankingcigar.Demo.Core.Message
{
    public class DemoMessage<T> : EventData
    {
        public T Data { get; set; }
    }
}