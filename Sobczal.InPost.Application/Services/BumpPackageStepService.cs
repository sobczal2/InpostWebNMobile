using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sobczal.InPost.Infrastructure.Core;
using Sobczal.InPost.Models.Packages;

namespace Sobczal.InPost.Application.Services;

public class BumpPackageStepService : IBumpPackageStepService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BumpPackageStepService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    public async Task BumpPackageStep(double chance)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var packageRepository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Package, Guid>>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var packages = await packageRepository.Query.Include(x => x.PackageSteps).ToListAsync();
        foreach (var package in packages.Where(package => Random.Shared.NextDouble() < chance).ToList())
        {
            package.BumpStep();
        }
        
        await unitOfWork.SaveChangesAsync();
    }
}