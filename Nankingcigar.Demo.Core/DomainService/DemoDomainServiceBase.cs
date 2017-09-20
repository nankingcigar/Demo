using Abp.Events.Bus;

namespace Nankingcigar.Demo.Core.DomainService
{
    public class DemoDomainServiceBase : Abp.Domain.Services.DomainService
    {
        public IEventBus EventBus { get; set; }
    }
}
