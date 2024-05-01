﻿using System.Linq.Expressions;

namespace LeafCatcher;

public interface IDbSet<TEntity, TId> 
    where TEntity : IEntity<TId> 
    where TId : IComparable<TId>, IEquatable<TId>
{
    IQueryable<TEntity> AsQueryable();

    Task<IEnumerable<TEntity>> FilterByAsync(
        Expression<Func<TEntity, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
       Expression<Func<TEntity, bool>> filterExpression,
       Expression<Func<TEntity, TProjected>> projectionExpression);

    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filterExpression);

    Task<TEntity> FindByIdAsync(TId id);

    ValueTask<long> InsertAsync(TEntity document);

    ValueTask<long> InsertAsync(IEnumerable<TEntity> documents);

    ValueTask<long> ReplaceAsync(TEntity document);

    ValueTask<long> ReplaceAsync(IEnumerable<TEntity> documents);

    ValueTask<long> DeleteWhereAsync(Expression<Func<TEntity, bool>> filterExpression);

    ValueTask<long> DeleteAsync(TId id);

    ValueTask<long> DeleteAsync(IEnumerable<TId> ids);
}