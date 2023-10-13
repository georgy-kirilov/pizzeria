namespace Menu.Pizza.Database.Models;

public sealed class PizzaDough
{
    public const int NameMaxLength = 40;

    public int Id { get; private set; }

    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public List<PizzaPricing> PizzaPricings { get; init; } = [];
}
