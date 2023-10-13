using Menu.Pizza.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Menu.Pizza.Features;

public class GetFullPizzaInfo
{
    public static async Task<IResult> Handle(int id, PizzaDbContext db, CancellationToken cancellationToken)
    {
        var pizza = await db.PizzaDefinitions
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(pi => new Response
            {
                PizzaId = pi.Id,

                PizzaName = pi.Name,

                Ingredients = pi.Ingredients.Select(i => new IngredientModel
                {
                    Id = i.Ingredient.Id,
                    Name = i.Ingredient.Name,
                    UseExtraAmount = i.UseExtraAmount
                })
                .ToArray(),

                AvailableSizes = pi.Pricings.OrderBy(pr => pr.Size.Slices).Select(pr => new PizzaSizeModel
                {
                    Id = pr.Size.Id,
                    Name = pr.Size.Name,
                    Slices = pr.Size.Slices,
                    AvailableDoughs = pr.Doughs.Select(d => new PizzaDoughModel
                    {
                        Id = d.Id,
                        Name = d.Name,
                        AdditionalPrice = d.Price
                    })
                    .ToArray()
                })
                .ToArray()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (pizza is null)
        {
            return Results.BadRequest("Pizza not found");
        }

        return Results.Ok(pizza);
    }

    public sealed class Response
    {
        public required int PizzaId { get; init; }

        public required string PizzaName { get; init; }

        public required IngredientModel[] Ingredients { get; init; }

        public required PizzaSizeModel[] AvailableSizes { get; init; }
    }

    public sealed class IngredientModel
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required bool UseExtraAmount { get; init; }
    }

    public sealed class PizzaSizeModel
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required int Slices { get; init; }

        public required PizzaDoughModel[] AvailableDoughs { get; init; }
    }

    public sealed class PizzaDoughModel
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required decimal AdditionalPrice { get; init; }
    }
}
