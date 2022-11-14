using Microsoft.EntityFrameworkCore;
using Sobczal.InPost.Infrastructure.Configuration.Packages;
using Sobczal.InPost.Models.Packages;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Infrastructure.Core;

public class InPostDbContext : DbContext
{
    public InPostDbContext(DbContextOptions<InPostDbContext> options) : base(options)
    {
    }

    public DbSet<Package> Packages { get; set; } = default!;
    public DbSet<Locker> Boxes { get; set; }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(PackageEntityTypeConfiguration).Assembly);
    }
}