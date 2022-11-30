using Sobczal.InPost.Models.Common;

namespace Sobczal.InPost.Models.Packages;

public class PackageStep : Entity<Guid>
{
    public virtual Package Package { get; set; } = default!;
    public Guid PackageId { get; set; }
    public PackageStepType Type { get; set; }
    public DateTime At { get; set; }
}