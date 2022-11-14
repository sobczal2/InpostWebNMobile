namespace Sobczal.InPost.Application.Dtos.Packages;

public class SendPackageDto
{
    public Guid ToLocker { get; set; }
    public Guid FromLocker { get; set; }
    public string ToUser { get; set; }
}