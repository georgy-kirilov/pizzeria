using Microsoft.EntityFrameworkCore;
using Pizzeria.Api.Menu.Database;

namespace Pizzeria.Api.Menu.Features;

public static class GetPizzasList
{
    public static async Task<Response> Handle(MenuDbContext db, CancellationToken cancellationToken)
    {
        var pizzas = await db.Pizzas
            .AsNoTracking()
            .Select(p => new PizzaListingModel
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToArrayAsync(cancellationToken);

        return new Response { Pizzas = pizzas };
    }

    public sealed class Response
    {
        public required PizzaListingModel[] Pizzas { get; init; }
    }

    public sealed class PizzaListingModel
    {
        public required int Id { get; init; }

        public required string Name { get; init; }
    }
}
