using System.Net;

namespace Sobczal.InPost.Application.Exceptions;

public class NotFoundException : InPostException
{
    private readonly string _description;

    public NotFoundException(string description)
    {
        _description = description;
    }

    public override HttpStatusCode HttpStatusCode => HttpStatusCode.NotFound;
}