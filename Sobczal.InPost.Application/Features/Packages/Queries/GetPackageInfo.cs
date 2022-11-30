using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Application.Features.Packages.Queries;

public class GetPackageInfo
{
    public record Query(Guid PackageId) : IRequest<PackageDto?>;

    public class Handler : IRequestHandler<Query, PackageDto?>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<Package, Guid> _packageRepository;
        private readonly IMapper _mapper;

        public Handler(
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<Package, Guid> packageRepository,
            IMapper mapper
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<PackageDto?> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var package = await _packageRepository.Query.ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.PackageId, cancellationToken);
            return package;
        }
    }
}