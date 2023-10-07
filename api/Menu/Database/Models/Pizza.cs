namespace Pizzeria.Api.Menu.Database.Models;

public sealed class Pizza
{
    public int Id { get; private set; }

    public required string Name { get; set; }

    public List<PizzaPricing> Pricings { get; init; } = new();

    public List<PizzaIngredientMapping> Ingredients { get; init; } = new();
}
