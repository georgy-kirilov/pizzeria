using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaPricingConfiguration : IEntityTypeConfiguration<PizzaPricing>
{
    public void Configure(EntityTypeBuilder<PizzaPricing> builder)
    {
        builder.ToTable("pizza_pricing");

        builder.Property(x => x.Price).HasPrecision(14, 2);
    }
}
