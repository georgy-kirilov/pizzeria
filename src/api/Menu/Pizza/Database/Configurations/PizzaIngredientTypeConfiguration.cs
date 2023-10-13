using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaIngredientTypeConfiguration : IEntityTypeConfiguration<PizzaIngredientType>
{
    public void Configure(EntityTypeBuilder<PizzaIngredientType> builder)
    {
        builder.ToTable("pizza_ingredient_type");
    }
}
