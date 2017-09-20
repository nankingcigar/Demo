using Abp.Events.Bus.Handlers;
using Nankingcigar.Demo.Core.EventBus;
using Nankingcigar.Demo.Core.EventBus.User;

namespace Nankingcigar.Demo.Event.User.Registration
{
    interface IRegistrationEvent : IEventHandler<RegistrationEventData>
    {
    }
}
