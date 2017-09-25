using Abp.BackgroundJobs;
using Abp.Dependency;
using Nankingcigar.Demo.Core.Message.User;

namespace Nankingcigar.Demo.MessageQueue.User.Registration.Landing
{
    public class Handler : IRegistrationHandler, ITransientDependency
    {
        public IBackgroundJobManager BackgroundJobManager { get; set; }

        public async void HandleEvent(RegistrationMessage eventData)
        {
            await BackgroundJobManager.EnqueueAsync<Job, Core.Entity.User.User>(eventData.Data);
        }
    }
}