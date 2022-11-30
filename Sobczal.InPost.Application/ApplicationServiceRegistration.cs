using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sobczal.InPost.Application.Features.Packages;
using Sobczal.InPost.Application.Services;

namespace Sobczal.InPost.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);
        services.AddMediatR(typeof(SendPackage).Assembly);
        services.AddHttpContextAccessor();

        services.AddSingleton<IBumpPackageStepService, BumpPackageStepService>();

        return services;
    }
}