using System.Net;
using Sobczal.InPost.Application.Results;

namespace Sobczal.InPost.Application.Exceptions;

public class BadRequestException : InPostException
{
    private readonly string _title;
    private readonly string _description;

    public BadRequestException(string title, string description)
    {
        _title = title;
        _description = description;
    }


    public override HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
    public override InPostErrorResult InPostErrorResult => new(_title, _description);
}