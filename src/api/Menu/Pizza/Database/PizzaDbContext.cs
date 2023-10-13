using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Database;

namespace Menu.Pizza.Database;

public sealed class PizzaDbContext(DbContextOptions<PizzaDbContext> options)
    : BaseDbContext(options, Schema)
{
    public const string Schema = "pizza";

    public DbSet<PizzaDefinition> PizzaDefinitions => Set<PizzaDefinition>();

    public DbSet<PizzaDough> PizzaDoughs => Set<PizzaDough>();

    public DbSet<PizzaIngredient> PizzaIngredients => Set<PizzaIngredient>();

    public DbSet<PizzaIngredientMapping> PizzaIngredientMappings => Set<PizzaIngredientMapping>();

    public DbSet<PizzaIngredientPricing> PizzaIngredientPricings => Set<PizzaIngredientPricing>();

    public DbSet<PizzaIngredientType> PizzaIngredientTypes => Set<PizzaIngredientType>();

    public DbSet<PizzaPricing> PizzaPricings => Set<PizzaPricing>();

    public DbSet<PizzaSize> PizzaSizes => Set<PizzaSize>();
}
