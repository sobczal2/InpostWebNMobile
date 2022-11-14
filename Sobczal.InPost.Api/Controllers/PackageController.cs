using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Application.Features.Packages;
using Sobczal.InPost.Application.Results;

namespace Sobczal.InPost.Api.Controllers;

public class PackageController : BaseInPostController
{
    public PackageController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<InPostResult<PackageDto>> SendPackage([FromBody] SendPackageDto sendPackageDto)
    {
        var result = await Mediator.Send(new SendPackage.Command(sendPackageDto));
        return new InPostResult<PackageDto>(result);
    }
}