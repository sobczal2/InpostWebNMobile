using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Application.Exceptions;
using Sobczal.InPost.Dtos.Dtos.Users;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Application.Features.Users.Queries;

public class EnsureNewUserExists
{
    public record Command(string Username) : IRequest<Unit>;

    public class Handller : IRequestHandler<Command, Unit>
    {
        private readonly IGenericRepository<InPostUser, string> _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public Handller(
            IGenericRepository<InPostUser, string> userRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new UnauthorizedException("User is not logged in");
            }

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                user = new InPostUser
                {
                    Id = userId,
                    Username = request.Username
                };
                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}