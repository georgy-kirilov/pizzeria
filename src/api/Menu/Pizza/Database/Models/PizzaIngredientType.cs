namespace Menu.Pizza.Database.Models;

public sealed class PizzaIngredientType
{
    public const int NameMaxLength = 40;

    public int Id { get; private set; }

    public required string Name { get; set; }

    public List<PizzaIngredient> Ingredients { get; init; } = [];
}
