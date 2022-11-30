using AutoMapper;
using MediatR;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Application.Features.Lockers.Queries;

public class ListLockers
{
    public record Query : IRequest<IEnumerable<LockerDto>>;

    public class Handller : IRequestHandler<Query, IEnumerable<LockerDto>>
    {
        private readonly IGenericRepository<Locker, Guid> _lockerRepository;
        private readonly IMapper _mapper;

        public Handller(IGenericRepository<Locker, Guid> lockerRepository, IMapper mapper)
        {
            _lockerRepository = lockerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LockerDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<LockerDto>>(await _lockerRepository
                .GetAllAsync());
        }
    }
}