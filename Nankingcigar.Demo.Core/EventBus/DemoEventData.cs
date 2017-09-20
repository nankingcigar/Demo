using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus;

namespace Nankingcigar.Demo.Core.EventBus
{
    public class DemoEventData<T>: EventData
    {
        public T Data { get; set; }
    }
}
