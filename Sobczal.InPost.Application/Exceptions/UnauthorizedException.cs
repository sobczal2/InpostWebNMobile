using System.Net;

namespace Sobczal.InPost.Application.Exceptions;

public class UnauthorizedException : InPostException
{
    private readonly string _description;

    public UnauthorizedException(string description)
    {
        _description = description;
    }
    public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;
}