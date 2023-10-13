using Menu.Pizza.Database;
using Microsoft.EntityFrameworkCore;

namespace Menu.Pizza.Features;

public class GetPizzasList
{
    public static async Task<Response> Handle(PizzaDbContext db, CancellationToken cancellationToken)
    {
        var pizzas = await db.PizzaDefinitions
            .AsNoTracking()
            .Select(p => new PizzaListingModel(p.Id, p.Name))
            .ToArrayAsync(cancellationToken);

        return new Response(pizzas);
    }

    public record Response(PizzaListingModel[] Pizzas);

    public record PizzaListingModel(int Id, string Name);
}
