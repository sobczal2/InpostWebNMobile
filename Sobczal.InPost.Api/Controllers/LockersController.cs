using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sobczal.InPost.Application.Features.Lockers.Queries;

namespace Sobczal.InPost.Api.Controllers;

public class LockersController : BaseInPostController
{
    public LockersController(IMediator mediator) : base(mediator)
    {
    }
    
    [Authorize]
    [HttpGet("[action]")]
    public async Task<IActionResult> ListLockers()
    {
        return Ok(await Mediator.Send(new ListLockers.Query()));
    }
}