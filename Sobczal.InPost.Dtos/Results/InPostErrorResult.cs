namespace Sobczal.InPost.Application.Results;

public sealed class InPostErrorResult
{
    public string Title { get; set; }
    public string Description { get; set; }

    public InPostErrorResult(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
