using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Nankingcigar.Demo.Core.Extension.Repository;

namespace Nankingcigar.Demo.EntityFramework.EntityFramework.Repositories
{
    internal class DemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<DemoDbContext, TEntity, TPrimaryKey>, IRepositoryExtension<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public DemoRepositoryBase(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //add common methods for all repositories
        public virtual IRepositoryExtension<TEntity, TPrimaryKey> CloseLazyLoad()
        {
            Context.Configuration.LazyLoadingEnabled = false;
            return this;
        }

        public virtual IRepositoryExtension<TEntity, TPrimaryKey> OpenLazyLoad()
        {
            Context.Configuration.LazyLoadingEnabled = true;
            return this;
        }
    }

    internal class DemoRepositoryBase<TEntity> : DemoRepositoryBase<TEntity, int>, IRepositoryExtension<TEntity>
        where TEntity : class, IEntity<int>
    {
        public DemoRepositoryBase(IDbContextProvider<DemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}