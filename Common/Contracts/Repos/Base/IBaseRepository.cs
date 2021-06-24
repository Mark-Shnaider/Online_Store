using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Common.Models.Entities.Base;
using Common.Contracts.Base;

namespace Common.Contracts.Repos.Base
{
    public interface IBaseRepository<TKey, TEntity>
        where TEntity : IBaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        TEntity AddOrUpdate(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
        void DeleteRange(IEnumerable<TKey> ids);
        EntityEntry<TEntity> GetEntry(TEntity entity);
        IQueryable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null);
        TEntity GetById(TKey id);
        TEntity GetById(TKey id, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null, bool localOnly = false);
        void Load(Expression<Func<TEntity, bool>> condition = null);
    }
}
