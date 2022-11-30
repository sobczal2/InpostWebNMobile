using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Application.Features.Packages.Queries;

public class ListYourPackages
{
    public record Query : IRequest<IEnumerable<PackageDto>>;

    public class Handler : IRequestHandler<Query, IEnumerable<PackageDto>>
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
        public async Task<IEnumerable<PackageDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _packageRepository.Query
                .Where(x => x.FromId == userId || x.ToId == userId).ProjectTo<PackageDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}