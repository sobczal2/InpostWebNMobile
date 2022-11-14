using Sobczal.InPost.Dtos.Dtos.Users;

namespace Sobczal.InPost.Application.Dtos.Packages;

public class PackageDto
{
    public Guid Id { get; set; }
    public DateTime SentAt { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public LockerDto Source { get; set; } = default!;
    public LockerDto Destination { get; set; } = default!;
    public InPostUserDto From { get; set; } = default!;
    public InPostUserDto To { get; set; } = default!;
    public virtual IEnumerable<PackageStepDto> PackageSteps { get; set; } = default!;
}