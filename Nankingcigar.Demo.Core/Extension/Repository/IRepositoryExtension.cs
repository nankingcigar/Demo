using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Nankingcigar.Demo.Core.Extension.Repository
{
    public interface IRepositoryExtension<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IRepositoryExtension<TEntity, TPrimaryKey> CloseLazyLoad();

        IRepositoryExtension<TEntity, TPrimaryKey> OpenLazyLoad();
    }

    public interface IRepositoryExtension<TEntity> : IRepositoryExtension<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
    }
}