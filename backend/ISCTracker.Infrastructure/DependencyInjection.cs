using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISCTracker.Application.Interfaces;
using ISCTracker.Infrastructure.Data;
using ISCTracker.Infrastructure.Repositories;

namespace ISCTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ISCTrackerDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IAsignaturaRepository, AsignaturaRepository>();

        return services;
    }
}
