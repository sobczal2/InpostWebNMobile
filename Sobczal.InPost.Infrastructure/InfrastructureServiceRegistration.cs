using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sobczal.InPost.Infrastructure.Core;

namespace Sobczal.InPost.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<InPostDbContext>(opt => { opt.UseNpgsql(configuration.GetConnectionString("Default")); });

        return services;
    }
}