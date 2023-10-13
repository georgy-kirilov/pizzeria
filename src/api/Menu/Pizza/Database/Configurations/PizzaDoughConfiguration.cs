using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaDoughConfiguration : IEntityTypeConfiguration<PizzaDough>
{
    public void Configure(EntityTypeBuilder<PizzaDough> builder)
    {
        builder.ToTable("pizza_dough");

        builder
            .Property(x => x.Name)
            .HasMaxLength(PizzaDough.NameMaxLength)
            .IsUnicode();

        builder.Property(x => x.Price).HasPrecision(14, 2);
    }
}
