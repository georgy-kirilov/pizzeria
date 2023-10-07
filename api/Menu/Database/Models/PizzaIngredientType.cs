namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaIngredientType
{
    public int Id { get; private set; }

    public required string Name { get; set; }

    public List<PizzaIngredient> Ingredients { get; init; } = new();
}
