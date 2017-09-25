using Abp.Events.Bus.Handlers;
using Nankingcigar.Demo.Core.Message.User;

namespace Nankingcigar.Demo.MessageQueue.User.Registration
{
    internal interface IRegistrationHandler : IEventHandler<RegistrationMessage>
    {
    }
}