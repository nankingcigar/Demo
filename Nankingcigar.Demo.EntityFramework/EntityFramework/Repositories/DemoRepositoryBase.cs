using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Nankingcigar.Demo.Core.Extend;

namespace Nankingcigar.Demo.EntityFramework.Repositories
{
    internal class DemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DemoDbContext, TEntity, TPrimaryKey>, IRepositoryExtend<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public DemoRepositoryBase(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //add common methods for all repositories
        public virtual void CloseLazyLoad()
        {
            this.Context.Configuration.LazyLoadingEnabled = false;
        }
    }

    internal class DemoRepositoryBase<TEntity> : DemoRepositoryBase<TEntity, int>, IRepositoryExtend<TEntity>
        where TEntity : class, IEntity<int>
    {
        public DemoRepositoryBase(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}