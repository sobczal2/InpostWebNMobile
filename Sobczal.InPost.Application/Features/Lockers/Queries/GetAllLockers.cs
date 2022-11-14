using AutoMapper;
using MediatR;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Application.Features.Lockers.Queries;

public class GetAllLockers
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
            var lockers = await _lockerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LockerDto>>(lockers);
        }
    }
}