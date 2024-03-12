using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prohelika.Domain.Repositories;
using Prohelika.Infrastructure.Data;
using Prohelika.Infrastructure.Repositories;

namespace Prohelika.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

        services.AddScoped(typeof(ICrudRepository<,>), typeof(CrudRepository<,>));        
        return services;
        
    }
}