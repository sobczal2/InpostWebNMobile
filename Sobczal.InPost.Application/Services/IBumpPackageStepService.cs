namespace Sobczal.InPost.Application.Services;

public interface IBumpPackageStepService
{
    public Task BumpPackageStep(double chance);
}