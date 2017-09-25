using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace Nankingcigar.Demo.MessageQueue.User.Login.Grid
{
    public class Job : BackgroundJob<Core.Entity.User.User>, ITransientDependency
    {
        public IRepository<Core.Entity.User.Grid, long> GridRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.User.User args)
        {
            Core.Entity.User.Grid grid = await GridRepository.GetAsync(args.Id);
            grid.LastLoginTime = args.LastLoginTime;
            await GridRepository.UpdateAsync(grid);
        }
    }
}