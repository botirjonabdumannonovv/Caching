using System.Linq.Expressions;

using Caching.Domain.Common.Query;
using Caching.Domain.Entities;

namespace Caching.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<User>> GetAsync(
        QuerySpecification<User> querySpecification, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        );

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    ValueTask<User> CreateAsync( User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken= default);

    ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
