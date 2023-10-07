namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaIngredient
{
    public int Id { get; private set; }

    public required string Name { get; set; }

    public required PizzaIngredientType Type { get; set; }

    public List<PizzaIngredientPricing> Pricings { get; set; } = new();
}
