namespace Menu.Pizza.Database.Models;

public sealed class PizzaIngredientMapping
{
    public int Id { get; private set; }

    public required bool UseExtraAmount { get; set; }

    public int PizzaId { get; set; }

    public PizzaDefinition Pizza { get; set; } = null!;

    public int IngredientId { get; set; }

    public PizzaIngredient Ingredient { get; set; } = null!;
}
