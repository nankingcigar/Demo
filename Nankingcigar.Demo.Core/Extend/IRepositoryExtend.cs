﻿using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Nankingcigar.Demo.Core.Extend
{
    public interface IRepositoryExtend<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IRepositoryExtend<TEntity, TPrimaryKey> CloseLazyLoad();
        IRepositoryExtend<TEntity, TPrimaryKey> OpenLazyLoad();
    }

    public interface IRepositoryExtend<TEntity> : IRepositoryExtend<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
    }
}