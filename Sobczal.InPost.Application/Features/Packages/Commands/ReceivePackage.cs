using MediatR;
using Sobczal.InPost.Application.Dtos.Packages;

namespace Sobczal.InPost.Application.Features.Packages;

public class ReceivePackage
{
    public record Command(Guid PackageId) : IRequest<PackageDto>;
    
    public class Handler : IRequestHandler<Command, PackageDto>
    {
        public Task<PackageDto> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}