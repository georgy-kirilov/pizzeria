using FluentValidation;
using Menu.Pizza.Database;
using Menu.Salads;
using Microsoft.Extensions.DependencyInjection;
using Shared.Database;

namespace Menu;

public static class ServiceRegistration
{
    public static IServiceCollection AddMenuModule(this IServiceCollection services)
    {
        const string connectionName = "Menu";

        services.AddValidatorsFromAssemblyContaining<PizzaDbContext>();

        services.AddDatabase<PizzaDbContext>(connectionName, PizzaDbContext.Schema);

        services.AddDatabase<SaladsDbContext>(connectionName, SaladsDbContext.Schema);

        return services;
    }
}
