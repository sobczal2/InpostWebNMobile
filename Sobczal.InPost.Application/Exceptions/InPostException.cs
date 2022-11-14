using System.Net;
using Sobczal.InPost.Application.Results;

namespace Sobczal.InPost.Application.Exceptions;

public abstract class InPostException : Exception
{
    public abstract HttpStatusCode HttpStatusCode { get; }
    public abstract InPostErrorResult InPostErrorResult { get; }
}