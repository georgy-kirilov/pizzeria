namespace Menu.Pizza.Database.Models;

public sealed class PizzaPricing
{
    public int Id { get; private set; }

    public required decimal Price { get; set; }

    public int PizzaId { get; set; }

    public PizzaDefinition Pizza { get; set; } = null!;

    public int SizeId { get; set; }

    public PizzaSize Size { get; set; } = null!;

    public List<PizzaDough> Doughs { get; init; } = [];
}
