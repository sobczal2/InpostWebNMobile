using Sobczal.InPost.Models.Common;

namespace Sobczal.InPost.Models.Packages;

public class Locker : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public virtual IEnumerable<Package> PackagesToPickup { get; set; } = default!;
    public virtual IEnumerable<Package> PackagesToSent { get; set; } = default!;
}