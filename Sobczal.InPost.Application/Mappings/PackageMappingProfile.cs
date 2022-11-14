using AutoMapper;
using Sobczal.InPost.Application.Dtos.Packages;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Application.Mappings;

public class PackageMappingProfile : Profile
{
    public PackageMappingProfile()
    {
        CreateMap<Package, PackageDto>().ReverseMap();
        CreateMap<Locker, LockerDto>().ReverseMap();
        CreateMap<PackageStep, PackageStepDto>().ReverseMap();
    }
}