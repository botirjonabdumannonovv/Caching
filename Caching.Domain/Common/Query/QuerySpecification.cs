using System.Linq.Expressions;

using Caching.Domain.Common.Caching;
using Caching.Domain.Common.Comparers;
using Caching.Domain.Common.Entities;

namespace Caching.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken) : CacheModel where TEntity : IEntity
{

    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = new();
    public List<(Expression<Func<TEntity, object>> KeySelector, bool IsAscending)> OrderingOptions { get; } = new();
    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(filter.ToString());

        foreach(var filter in OrderingOptions)
            hashCode.Add(filter.ToString());

        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }

    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";
}
