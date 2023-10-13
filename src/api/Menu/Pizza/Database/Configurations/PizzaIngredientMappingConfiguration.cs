using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaIngredientMappingConfiguration : IEntityTypeConfiguration<PizzaIngredientMapping>
{
    public void Configure(EntityTypeBuilder<PizzaIngredientMapping> builder)
    {
        builder.ToTable("pizza_ingredient_mapping");
    }
}
