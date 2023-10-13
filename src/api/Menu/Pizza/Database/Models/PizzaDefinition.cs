namespace Menu.Pizza.Database.Models;

public sealed class PizzaDefinition
{
    public const int NameMaxLength = 50;

    public int Id { get; private set; }

    public required string Name { get; set; }

    public List<PizzaPricing> Pricings { get; init; } = [];

    public List<PizzaIngredientMapping> Ingredients { get; init; } = [];
}
