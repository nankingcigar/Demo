using Abp.Dapper.Repositories;
using Abp.Data;
using Abp.Domain.Entities;
using System.Data;

namespace Nankingcigar.Demo.Dapper.Extend
{
    public class DapperRepositoryBaseExtend<TDbContext, TEntity, TPrimaryKey> : DapperEfRepositoryBase<TDbContext, TEntity, TPrimaryKey>, IDapperRepositoryExtend<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public DapperRepositoryBaseExtend(IActiveTransactionProvider activeTransactionProvider) : base(activeTransactionProvider)
        {
        }

        public virtual IDbConnection GetConnection()
        {
            return this.Connection;
        }

        public virtual IDbTransaction GetTransaction()
        {
            return this.ActiveTransaction;
        }
    }

    public class DapperRepositoryBaseExtend<TDbContext, TEntity> : DapperRepositoryBaseExtend<TDbContext, TEntity, int>, IDapperRepositoryExtend<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : class
    {
        public DapperRepositoryBaseExtend(IActiveTransactionProvider activeTransactionProvider) : base(activeTransactionProvider)
        {
        }
    }
}