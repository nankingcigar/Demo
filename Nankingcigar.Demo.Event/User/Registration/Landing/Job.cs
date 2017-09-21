using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace Nankingcigar.Demo.Event.User.Registration.Landing
{
    public class Job : BackgroundJob<Core.Entity.User.User>, ITransientDependency
    {
        public IRepository<Core.Entity.User.Landing, long> LandingRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.User.User args)
        {
            Core.Entity.User.Landing landing = new Core.Entity.User.Landing()
            {
                Id = args.Id,
                DisplayName = args.DisplayName ?? args.UserName
            };
            await LandingRepository.InsertAsync(landing);
        }
    }
}