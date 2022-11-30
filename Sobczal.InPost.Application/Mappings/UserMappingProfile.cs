using AutoMapper;
using Sobczal.InPost.Dtos.Dtos.Users;
using Sobczal.InPost.Models.Users;

namespace Sobczal.InPost.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<InPostUser, InPostUserDto>()
            .ReverseMap();
    }
}