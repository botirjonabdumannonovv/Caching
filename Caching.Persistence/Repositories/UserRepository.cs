using System.Linq.Expressions;
using Caching.Domain.Common.Caching;
using Caching.Domain.Common.Query;
using Caching.Domain.Entities;
using Caching.Persistence.Caching.Brokers;
using Caching.Persistence.DbContexts;
using Caching.Persistence.Repositories.Interfaces;

namespace Caching.Persistence.Repositories;

public class UserRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<User, IdentityDbContext>(dbContext, cacheBroker, new CacheEntryOptions()), IUserRepository
{
    ValueTask<User> IUserRepository.CreateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    ValueTask<User?> IUserRepository.DeleteByIdAsync(Guid userId, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.DeleteByIdAsync(userId, saveChanges, cancellationToken);
    }

    IQueryable<User?> IUserRepository.Get(Expression<Func<User, bool>>? predicate, bool asNoTracking)
    {
        return base.Get(predicate, asNoTracking);
    }

    ValueTask<IList<User>> IUserRepository.GetAsync(QuerySpecification<User> querySpecification, bool asNoTracking, CancellationToken cancellationToken)
    {
        return base.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    ValueTask<User?> IUserRepository.GetByIdAsync(Guid userId, bool asNoTracking, CancellationToken cancellationToken)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    ValueTask<User> IUserRepository.UpdateAsync(User user, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }
}
