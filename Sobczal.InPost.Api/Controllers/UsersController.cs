using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sobczal.InPost.Application.Features.Users.Queries;

namespace Sobczal.InPost.Api.Controllers;

public class UsersController : BaseInPostController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }
    
    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> EnsureNewUserExists([FromBody] EnsureNewUserExists.Command command)
    {
        var user = await Mediator.Send(command);
        return Ok(user);
    }
    
    [Authorize]
    [HttpGet("[action]")]
    public async Task<IActionResult> ListUsers()
    {
        return Ok(await Mediator.Send(new ListUsers.Query()));
    }
}