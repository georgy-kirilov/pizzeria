namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaDough
{
    public int Id { get; private set; }

    public required string Name { get; set; }

    public required decimal Price {  get; set; }

    public List<PizzaPricing> PizzaPricings { get; init; } = new();
}
