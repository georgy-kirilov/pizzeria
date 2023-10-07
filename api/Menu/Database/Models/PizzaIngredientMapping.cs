namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaIngredientMapping
{
    public int Id { get; private set; }

    public required Pizza Pizza { get; set; }

    public required PizzaIngredient Ingredient { get; set; }

    public required bool UseExtraAmount { get; set; }
}
