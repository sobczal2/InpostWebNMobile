using System.Net;

namespace Sobczal.InPost.Application.Exceptions;

public class ForbiddenException : InPostException
{
    private readonly string _description;

    public ForbiddenException(string description)
    {
        _description = description;
    }
    public override HttpStatusCode HttpStatusCode => HttpStatusCode.Forbidden;
}