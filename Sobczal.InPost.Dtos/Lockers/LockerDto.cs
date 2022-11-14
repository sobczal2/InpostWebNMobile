namespace Sobczal.InPost.Application.Dtos.Packages;

public class LockerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
}