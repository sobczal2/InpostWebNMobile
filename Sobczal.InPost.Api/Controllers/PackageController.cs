using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Application.Features.Packages;
using Sobczal.InPost.Application.Features.Packages.Queries;

namespace Sobczal.InPost.Api.Controllers;

public class PackageController : BaseInPostController
{
    public PackageController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> SendPackage([FromBody] SendPackageDto sendPackageDto)
    {
        return Ok(await Mediator.Send(new SendPackage.Command(sendPackageDto)));
    }

    [HttpGet("[action]/{packageId:guid}")]
    public async Task<IActionResult> GetPackageInfo([FromRoute] Guid packageId)
    {
        var result = await Mediator.Send(new GetPackageInfo.Query(packageId));
        if(result == null)
        {
            return Unauthorized();
        }

        return Ok(result);
    }
    
    [Authorize]
    [HttpGet("[action]")]
    public async Task<IActionResult> ListYourPackages()
    {
        return Ok(await Mediator.Send(new ListYourPackages.Query()));
    }
}