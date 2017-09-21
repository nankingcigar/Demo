using Abp.Events.Bus.Handlers;
using Nankingcigar.Demo.Core.EventBus.User;

namespace Nankingcigar.Demo.Event.User.Registration
{
    internal interface IRegistrationEvent : IEventHandler<RegistrationEventData>
    {
    }
}