using AutoMapper;
using MediatR;
using Sobczal.InPost.Dtos.Dtos.Users;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Application.Features.Users.Queries;

public class ListUsers
{
    public record Query : IRequest<IEnumerable<InPostUserDto>>;
    
    public class Handler : IRequestHandler<Query, IEnumerable<InPostUserDto>>
    {
        private readonly IGenericRepository<InPostUser, string> _userRepository;
        private readonly IMapper _mapper;

        public Handler(IGenericRepository<InPostUser, string> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InPostUserDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<InPostUserDto>>(await _userRepository
                .GetAllAsync());
        }
    }
}