using System.Net;

namespace Sobczal.InPost.Application.Exceptions;

public abstract class InPostException : Exception
{
    public abstract HttpStatusCode HttpStatusCode { get; }
}