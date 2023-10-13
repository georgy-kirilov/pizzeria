using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase<TContext>(
        this IServiceCollection services,
        string connectionName,
        string schema)
        where TContext : BaseDbContext
    {
        services.AddDbContext<TContext>(options =>
        {
            options.UseNpgsql($"name={connectionName}", migrations =>
            {
                migrations
                    .MigrationsHistoryTable(HistoryRepository.DefaultTableName, schema)
                    .MigrationsAssembly(typeof(TContext).Assembly.FullName);
            })  
            .UseSnakeCaseNamingConvention();
        });
            
        return services;
    }
}
