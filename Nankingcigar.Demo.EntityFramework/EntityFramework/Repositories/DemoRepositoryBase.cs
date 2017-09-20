using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Nankingcigar.Demo.Core.Extend;
using Nankingcigar.Demo.Core.Extend.Repository;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Repositories
{
    internal class DemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DemoDbContext, TEntity, TPrimaryKey>, IRepositoryExtend<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public DemoRepositoryBase(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //add common methods for all repositories
        public virtual IRepositoryExtend<TEntity, TPrimaryKey> CloseLazyLoad()
        {
            Context.Configuration.LazyLoadingEnabled = false;
            return this;
        }

        public IRepositoryExtend<TEntity, TPrimaryKey> OpenLazyLoad()
        {
            Context.Configuration.LazyLoadingEnabled = true;
            return this;
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