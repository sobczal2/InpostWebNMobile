using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Infrastructure.Configuration.Users;

public class InPostUserEntityTypeConfiguration : IEntityTypeConfiguration<InPostUser>
{
    public void Configure(EntityTypeBuilder<InPostUser> builder)
    {
        builder.HasMany(x => x.SentPackages)
            .WithOne(x => x.From)
            .HasForeignKey(x => x.FromId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.ReceivedPackages)
            .WithOne(x => x.To)
            .HasForeignKey(x => x.ToId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}