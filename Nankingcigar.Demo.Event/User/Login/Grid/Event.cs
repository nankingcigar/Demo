using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Nankingcigar.Demo.Core.EventBus.User;

namespace Nankingcigar.Demo.Event.User.Login.Grid
{
    public class Event : IEventHandler<LoginEventData>, ITransientDependency
    {
        public IBackgroundJobManager BackgroundJobManager { get; set; }

        public async void HandleEvent(LoginEventData eventData)
        {
            await BackgroundJobManager.EnqueueAsync<Job, Core.Entity.User.User>(eventData.Data);
        }
    }
}
