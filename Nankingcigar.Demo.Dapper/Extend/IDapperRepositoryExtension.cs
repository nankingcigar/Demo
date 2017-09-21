using Abp.Dapper.Repositories;
using Abp.Domain.Entities;
using System.Data;

namespace Nankingcigar.Demo.Dapper.Extend
{
    public interface IDapperRepositoryExtension<TEntity, TPrimaryKey> : IDapperRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IDbConnection GetConnection();

        IDbTransaction GetTransaction();
    }

    public interface IDapperRepositoryExtension<TEntity> : IDapperRepositoryExtension<TEntity, int>, IDapperRepository<TEntity> where TEntity : class, IEntity<int>
    {
    }
}