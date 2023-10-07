namespace Pizzeria.Api.Menu.Database.Models;

public sealed class PizzaIngredientPricing
{
    public int Id { get; private set; }

    public required decimal RegularPrice { get; set; }

    public required decimal PriceForExtra {  get; set; }

    public required PizzaSize PizzaSize { get; set; }
}
