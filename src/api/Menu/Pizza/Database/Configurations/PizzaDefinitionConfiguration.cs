using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaDefinitionConfiguration : IEntityTypeConfiguration<PizzaDefinition>
{
    public void Configure(EntityTypeBuilder<PizzaDefinition> builder)
    {
        builder.ToTable("pizza_definition");

        builder
            .Property(x => x.Name)
            .HasMaxLength(PizzaDefinition.NameMaxLength)
            .IsUnicode();

        builder
            .HasMany(x => x.Pricings)
            .WithOne(x => x.Pizza)
            .HasForeignKey(x => x.PizzaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Ingredients)
            .WithOne(x => x.Pizza)
            .HasForeignKey(x => x.IngredientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
