using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Infrastructure.Configuration.Packages;

public class PackageEntityTypeConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
        builder.HasOne(x => x.Destination)
            .WithMany(x => x.PackagesToPickup)
            .HasForeignKey(x => x.DestinationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Source)
            .WithMany(x => x.PackagesToSent)
            .HasForeignKey(x => x.SourceId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}