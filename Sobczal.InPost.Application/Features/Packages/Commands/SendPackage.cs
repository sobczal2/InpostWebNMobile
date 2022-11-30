using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Application.Exceptions;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Application.Features.Packages;

public class SendPackage
{
    public record Command(SendPackageDto SendPackageDto) : IRequest<PackageDto>;
    
    public class Handler : IRequestHandler<Command, PackageDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Package, Guid> _packageRepository;
        private readonly IGenericRepository<Locker, Guid> _lockerRepository;
        private readonly IGenericRepository<InPostUser, string> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public Handler(
            IUnitOfWork unitOfWork,
            IGenericRepository<Package, Guid> packageRepository,
            IGenericRepository<Locker, Guid> lockerRepository,
            IGenericRepository<InPostUser, string> userRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _packageRepository = packageRepository;
            _lockerRepository = lockerRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        public async Task<PackageDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                throw new UnauthorizedException("User is not authorized");
            if(await _userRepository.GetByIdAsync(userId) == null)
                throw new NotFoundException("User not found");
            if(await  _userRepository.GetByIdAsync(request.SendPackageDto.ToUser) == null)
                throw new NotFoundException("User not found");
            if(await _lockerRepository.GetByIdAsync(request.SendPackageDto.FromLocker) == null)
                throw new NotFoundException("Locker not found");
            if(await _lockerRepository.GetByIdAsync(request.SendPackageDto.ToLocker) == null)
                throw new NotFoundException("Locker not found");

            var package = new Package()
            {
                DestinationId = request.SendPackageDto.ToLocker,
                SourceId = request.SendPackageDto.FromLocker,
                ToId = request.SendPackageDto.ToUser,
                FromId = userId,
                SentAt = DateTime.UtcNow,
                CanBePickedUp = false,
                PackageSteps = new List<PackageStep>()
                {
                    new()
                    {
                        At = DateTime.UtcNow,
                        Type = PackageStepType.SentAtBox
                    }
                }
            };
            
            await _packageRepository.AddAsync(package);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PackageDto>(package);
        }
    }
}