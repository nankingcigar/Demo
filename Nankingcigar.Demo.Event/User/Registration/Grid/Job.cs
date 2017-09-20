using System;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Event.User.Registration.Grid
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
                UserName = args.UserName,
                DisplayName = args.DisplayName,
                Email = args.Email,
                LastLoginTime = args.LastLoginTime
            };
            await GridRepository.InsertAsync(grid);
        }
    }
}
