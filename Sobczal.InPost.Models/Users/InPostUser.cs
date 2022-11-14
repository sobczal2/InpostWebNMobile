using Sobczal.InPost.Models.Common;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Models.Users;

public class InPostUser : Entity<string>
{
    public string Email { get; set; } = default!;
    public virtual IEnumerable<Package> SentPackages { get; set; } = default!;
    public virtual IEnumerable<Package> ReceivedPackages { get; set; } = default!;
}