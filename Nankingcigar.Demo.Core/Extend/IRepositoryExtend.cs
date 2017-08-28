using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Nankingcigar.Demo.Core.Extend
{
    public interface IRepositoryExtend<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        void CloseLazyLoad();
    }

    public interface IRepositoryExtend<TEntity> : IRepositoryExtend<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
    }
}