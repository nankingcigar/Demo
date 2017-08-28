using Abp.Dapper.Repositories;
using Abp.Domain.Entities;
using System.Data;

namespace Nankingcigar.Demo.Dapper.Extend
{
    public interface IDapperRepositoryExtend<TEntity, TPrimaryKey> : IDapperRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IDbConnection GetConnection();

        IDbTransaction GetTransaction();
    }

    public interface IDapperRepositoryExtend<TEntity> : IDapperRepositoryExtend<TEntity, int>, IDapperRepository<TEntity> where TEntity : class, IEntity<int>
    {
    }
}