using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Infrastructure.Configuration.Lockers;

public class LockerEntityTypeConfiguration : IEntityTypeConfiguration<Locker>
{
    public void Configure(EntityTypeBuilder<Locker> builder)
    {
        builder.HasData(
            new Locker()
            {
                Id = Guid.Parse("C3895097-3B6A-4436-A258-E0D412DA6332"),
                Name = "Locker 1",
                Address = "Address 1",
            },
            new Locker()
            {
                Id = Guid.Parse("3113BBAE-6193-49F4-A39A-FFBC135A8B12"),
                Name = "Locker 2",
                Address = "Address 2",
            }
        );
    }
}