using Abp.Dapper.Repositories;
using Abp.Data;
using Abp.Domain.Entities;
using System.Data;
using Nankingcigar.Demo.Core.Extension.Repository.Dapper;

namespace Nankingcigar.Demo.Dapper.Extend
{
    public class DapperRepositoryBaseExtension<TDbContext, TEntity, TPrimaryKey> : DapperEfRepositoryBase<TDbContext, TEntity, TPrimaryKey>, IDapperRepositoryExtension<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public DapperRepositoryBaseExtension(IActiveTransactionProvider activeTransactionProvider) : base(activeTransactionProvider)
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

    public class DapperRepositoryBaseExtension<TDbContext, TEntity> : DapperRepositoryBaseExtension<TDbContext, TEntity, int>, IDapperRepositoryExtension<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : class
    {
        public DapperRepositoryBaseExtension(IActiveTransactionProvider activeTransactionProvider) : base(activeTransactionProvider)
        {
        }
    }
}