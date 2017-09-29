using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;

namespace Nankingcigar.Demo.MessageQueue.User.Registration.Landing
{
    public class Job : BackgroundJob<Core.Entity.POCO.User.User>, ITransientDependency
    {
        public IDapperRepositoryExtension<Core.Entity.View.User.Landing, long> LandingDapperRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.POCO.User.User args)
        {
            Core.Entity.View.User.Landing landing = new Core.Entity.View.User.Landing()
            {
                Id = args.Id,
                Display = args.Display ?? args.UserName
            };
            await LandingDapperRepository.InsertAsync(landing);
        }
    }
}