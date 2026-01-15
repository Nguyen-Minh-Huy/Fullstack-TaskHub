using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskHub.Application.Interfaces;
using TaskHub.Domain.Interfaces;
using TaskHub.Infrastructure.Data;
using TaskHub.Infrastructure.Repositories;
using TaskHub.Infrastructure.Services;
using TaskHub.Infrastructure.Settings;

namespace TaskHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // Add Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IBlacklistTokenRepository, BlacklistTokenRepository>();

        // Add Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Add Services
        services.AddScoped<IJwtService, JwtService>();

        // Add JwtSettings
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        return services;
    }
}