using Sobczal.InPost.Models.Common;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Models.Packages;

public class Package : Entity<Guid>
{
    public DateTime SentAt { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public virtual Locker Source { get; set; } = default!;
    public Guid SourceId { get; set; }
    public virtual Locker Destination { get; set; } = default!;
    public Guid DestinationId { get; set; }
    public virtual InPostUser From { get; set; } = default!;
    public string FromId { get; set; } = default!;
    public virtual InPostUser To { get; set; } = default!;
    public string ToId { get; set; } = default!;
    public bool CanBePickedUp { get; set; }
    public virtual IEnumerable<PackageStep> PackageSteps { get; set; } = default!;

    public void BumpStep()
    {
        var lastPackageStep = PackageSteps.OrderBy(x => x.Type).Last();
        if(PackageStepType.PickedUp == lastPackageStep.Type)
            return;
        var packageSteps = PackageSteps.ToList();
        packageSteps.Add(new PackageStep
        {
            PackageId = Id,
            Type = lastPackageStep.Type + 1,
            At = DateTime.UtcNow
        });
        PackageSteps = packageSteps;
    }
}