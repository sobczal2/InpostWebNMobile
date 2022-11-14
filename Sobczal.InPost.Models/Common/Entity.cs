namespace Sobczal.InPost.Models.Common;

public class Entity<TId>
{
    public TId Id { get; set; } = default!;
}