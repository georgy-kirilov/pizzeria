namespace Menu.Pizza.Database.Models;

public sealed class PizzaIngredient
{
    public const int NameMaxLength = 40;

    public int Id { get; private set; }

    public required string Name { get; set; }

    public int TypeId { get; set; }

    public PizzaIngredientType Type { get; set; } = null!;

    public List<PizzaIngredientPricing> Pricings { get; init; } = [];
}
