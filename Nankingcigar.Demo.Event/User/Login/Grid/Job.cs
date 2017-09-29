using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;

namespace Nankingcigar.Demo.MessageQueue.User.Login.Grid
{
    public class Job : BackgroundJob<Core.Entity.POCO.User.User>, ITransientDependency
    {
        public IDapperRepositoryExtension<Core.Entity.View.User.Grid, long> GridDapperRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.POCO.User.User args)
        {
            Core.Entity.View.User.Grid grid = await GridDapperRepository.GetAsync(args.Id);
            grid.LastLoginTime = args.LastLoginTime;
            await GridDapperRepository.UpdateAsync(grid);
        }
    }
}