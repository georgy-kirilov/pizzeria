namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaSize
{
    public int Id { get; private set; }

    public required string Name { get; set; }

    public required int Slices { get; set; }

    public List<PizzaPricing> PizzaPricings { get; init; } = new();
}
