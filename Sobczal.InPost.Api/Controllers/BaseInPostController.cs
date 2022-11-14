using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sobczal.InPost.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseInPostController : ControllerBase
{
    protected readonly IMediator Mediator;

    public BaseInPostController(IMediator mediator)
    {
        Mediator = mediator;
    }
}