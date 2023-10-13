namespace Menu.Pizza.Database.Models;

public sealed class PizzaSize
{
    public const int NameMaxLength = 40;
    public const int SlicesMaxValue = 16;

    public int Id { get; private set; }

    public required string Name { get; set; }

    public required int Slices { get; set; }

    public List<PizzaPricing> PizzaPricings { get; init; } = [];
}
