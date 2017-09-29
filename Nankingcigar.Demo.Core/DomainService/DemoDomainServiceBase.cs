using Abp.Events.Bus;
using Abp.Runtime.Session;

namespace Nankingcigar.Demo.Core.DomainService
{
    public class DemoDomainServiceBase : Abp.Domain.Services.DomainService
    {
        public IEventBus EventBus { get; set; }

        public IAbpSession AbpSession { get; set; }
    }
}