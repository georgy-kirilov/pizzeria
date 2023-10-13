using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menu.Pizza.Database.Configurations;

public sealed class PizzaSizeConfiguration : IEntityTypeConfiguration<PizzaSize>
{
    public void Configure(EntityTypeBuilder<PizzaSize> builder)
    {
        builder.ToTable("pizza_size");
    }
}
