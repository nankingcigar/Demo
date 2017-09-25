using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace Nankingcigar.Demo.MessageQueue.User.Registration.Grid
{
    public class Job : BackgroundJob<Core.Entity.User.User>, ITransientDependency
    {
        public IRepository<Core.Entity.User.Grid, long> GridRepository { get; set; }

        [UnitOfWork]
        public override async void Execute(Core.Entity.User.User args)
        {
            Core.Entity.User.Grid grid = new Core.Entity.User.Grid()
            {
                Id = args.Id,
                Name = args.UserName,
                Display = args.Display ?? args.UserName,
                Email = args.Email,
                LastLoginTime = args.LastLoginTime
            };
            await GridRepository.InsertAsync(grid);
        }
    }
}