using System.Net;
using Sobczal.InPost.Application.Results;

namespace Sobczal.InPost.Application.Exceptions;

public class UnauthorizedException : InPostException
{
    private readonly string _description;

    public UnauthorizedException(string description)
    {
        _description = description;
    }
    public override HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;
    public override InPostErrorResult InPostErrorResult => new InPostErrorResult("Unauthorized", _description);
}