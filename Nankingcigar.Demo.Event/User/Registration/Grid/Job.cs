using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;

namespace Nankingcigar.Demo.MessageQueue.User.Registration.Grid
{
    public class Job : BackgroundJob<Core.Entity.POCO.User.User>, ITransientDependency
    {
        public IDapperRepositoryExtension<Core.Entity.View.User.Grid, long> GridDapperRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.POCO.User.User args)
        {
            Core.Entity.View.User.Grid grid = new Core.Entity.View.User.Grid()
            {
                Id = args.Id,
                Name = args.UserName,
                Display = args.Display ?? args.UserName,
                Email = args.Email,
                LastLoginTime = args.LastLoginTime
            };
            await GridDapperRepository.InsertAsync(grid);
        }
    }
}