namespace Sobczal.InPost.Application.Results;

public sealed class InPostResult<T>
{
    public T Payload { get; set; }

    public InPostResult(T payload)
    {
        Payload = payload;
    }
}