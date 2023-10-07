using Microsoft.EntityFrameworkCore;
using Pizzeria.Api.Menu.Database.Models;

namespace Pizzeria.Api.Menu.Database;

public sealed class MenuDbContext(DbContextOptions<MenuDbContext> options)
    : DbContext(options)
{
    public DbSet<Pizza> Pizzas => Set<Pizza>();

    public DbSet<PizzaDough> PizzaDoughs => Set<PizzaDough>();

    public DbSet<PizzaIngredient> PizzaIngredients => Set<PizzaIngredient>();

    public DbSet<PizzaIngredientMapping> PizzaIngredientMappings => Set<PizzaIngredientMapping>();

    public DbSet<PizzaIngredientPricing> PizzaIngredientPricings => Set<PizzaIngredientPricing>();

    public DbSet<PizzaIngredientType> PizzaIngredientTypes => Set<PizzaIngredientType>();

    public DbSet<PizzaPricing> PizzaPricings => Set<PizzaPricing>();

    public DbSet<PizzaSize> PizzaSizes => Set<PizzaSize>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaDough>().Property(x => x.Price).HasPrecision(14, 2);
        modelBuilder.Entity<PizzaIngredientPricing>().Property(x => x.RegularPrice).HasPrecision(14, 2);
        modelBuilder.Entity<PizzaIngredientPricing>().Property(x => x.PriceForExtra).HasPrecision(14, 2);
        modelBuilder.Entity<PizzaPricing>().Property(x => x.Price).HasPrecision(14, 2);
    }
}
