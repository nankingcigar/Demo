using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Nankingcigar.Demo.Core.Message.User;

namespace Nankingcigar.Demo.MessageQueue.User.Login.Grid
{
    public class Handler : IEventHandler<LoginMessage>, ITransientDependency
    {
        public IBackgroundJobManager BackgroundJobManager { get; set; }

        public async void HandleEvent(LoginMessage eventData)
        {
            await BackgroundJobManager.EnqueueAsync<Job, Core.Entity.User.User>(eventData.Data);
        }
    }
}