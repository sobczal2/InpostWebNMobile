namespace Sobczal.InPost.Application.Dtos.Packages;

public class PackageStepDto
{
    public PackageStepTypeDto Type { get; set; }
    public DateTime At { get; set; }
    public string Description { get; set; } = default!;
}