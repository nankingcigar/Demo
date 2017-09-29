using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace Nankingcigar.Demo.MessageQueue.User.Registration.Landing
{
    public class Job : BackgroundJob<Core.Entity.POCO.User.User>, ITransientDependency
    {
        public IRepository<Core.Entity.View.User.Landing, long> LandingRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.POCO.User.User args)
        {
            Core.Entity.View.User.Landing landing = new Core.Entity.View.User.Landing()
            {
                Id = args.Id,
                Display = args.Display ?? args.UserName
            };
            await LandingRepository.InsertAsync(landing);
        }
    }
}