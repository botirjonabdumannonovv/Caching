using Caching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caching.Persistence.DbContexts;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var result = modelBuilder.Model.GetEntityTypes();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
