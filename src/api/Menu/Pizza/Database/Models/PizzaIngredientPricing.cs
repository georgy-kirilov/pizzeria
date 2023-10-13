namespace Menu.Pizza.Database.Models;

public sealed class PizzaIngredientPricing
{
    public const decimal RegularPriceMinValue = 0.01m;
    public const decimal RegularPriceMaxValue = 20.00m;

    public const decimal PriceForExtraMinValue = 0.01m;
    public const decimal PriceForExtraMaxValue = 15.00m;

    public int Id { get; private set; }

    public required decimal RegularPrice { get; set; }

    public required decimal PriceForExtra { get; set; }

    public int PizzaSizeId { get; set; }

    public PizzaSize PizzaSize { get; set; } = null!;
}
