using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Application.Features.Lockers.Queries;
using Sobczal.InPost.Application.Results;

namespace Sobczal.InPost.Api.Controllers;

public class LockersController : BaseInPostController
{
    public LockersController(IMediator mediator) : base(mediator)
    {
    }
    
    [Authorize]
    [HttpGet("[action]")]
    public async Task<InPostResult<IEnumerable<LockerDto>>> GetLockers()
    {
        var result = await Mediator.Send(new GetAllLockers.Query());
        return new InPostResult<IEnumerable<LockerDto>>(result);
    }
}