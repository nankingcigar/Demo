using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Nankingcigar.Demo.Core.Extension.Repository.Dapper
{
    public interface IDapperRepositoryExtension<TEntity, TPrimaryKey> : IRepository, ITransientDependency where TEntity : class, IEntity<TPrimaryKey>
    {
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        int Execute(string query, object parameters = null);
        Task<int> ExecuteAsync(string query, object parameters = null);
        TEntity FirstOrDefault(TPrimaryKey id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TPrimaryKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);
        IEnumerable<TEntity> GetAllPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);
        Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);
        Task<IEnumerable<TEntity>> GetAllPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true);
        Task<TEntity> GetAsync(TPrimaryKey id);
        IEnumerable<TEntity> GetSet(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, string sortingProperty, bool ascending = true);
        IEnumerable<TEntity> GetSet(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);
        Task<IEnumerable<TEntity>> GetSetAsync(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, string sortingProperty, bool ascending = true);
        Task<IEnumerable<TEntity>> GetSetAsync(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression);
        void Insert(TEntity entity);
        TPrimaryKey InsertAndGetId(TEntity entity);
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        IEnumerable<TAny> Query<TAny>(string query, object parameters = null) where TAny : class;
        IEnumerable<TEntity> Query(string query, object parameters = null);
        Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters = null);
        Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters = null) where TAny : class;
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(TPrimaryKey id);
        Task<TEntity> SingleAsync(TPrimaryKey id);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
    }

    public interface IDapperRepositoryExtension<TEntity> : IDapperRepositoryExtension<TEntity, int> where TEntity : class, IEntity<int>
    {
    }
}
