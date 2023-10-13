using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaIngredientConfiguration : IEntityTypeConfiguration<PizzaIngredient>
{
    public void Configure(EntityTypeBuilder<PizzaIngredient> builder)
    {
        builder.ToTable("pizza_ingredient");
    }
}
