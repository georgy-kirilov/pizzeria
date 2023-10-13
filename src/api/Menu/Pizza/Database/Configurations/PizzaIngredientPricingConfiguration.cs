using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaIngredientPricingConfiguration : IEntityTypeConfiguration<PizzaIngredientPricing>
{
    public void Configure(EntityTypeBuilder<PizzaIngredientPricing> builder)
    {
        builder.ToTable("pizza_ingredient_pricing");

        builder.Property(x => x.RegularPrice).HasPrecision(14, 2);

        builder.Property(x => x.PriceForExtra).HasPrecision(14, 2);
    }
}
