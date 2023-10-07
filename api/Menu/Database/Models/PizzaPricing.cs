namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaPricing
{
    public int Id { get; private set; }

    public required decimal Price { get; set; }

    public required Pizza Pizza { get; set; }

    public required PizzaSize Size { get; set; }

    public List<PizzaDough> Doughs { get; init; } = new();
}
