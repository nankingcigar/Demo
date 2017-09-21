using Abp.BackgroundJobs;
using Abp.Dependency;
using Nankingcigar.Demo.Core.EventBus.User;

namespace Nankingcigar.Demo.Event.User.Registration.Landing
{
    public class Event : IRegistrationEvent, ITransientDependency
    {
        public IBackgroundJobManager BackgroundJobManager { get; set; }

        public async void HandleEvent(RegistrationEventData eventData)
        {
            await BackgroundJobManager.EnqueueAsync<Job, Core.Entity.User.User>(eventData.Data);
        }
    }
}