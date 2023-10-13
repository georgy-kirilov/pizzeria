using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Menu.Pizza.Features.PizzaIngredients;

public static class PizzaIngredientEndpoints
{
    public static IEndpointRouteBuilder MapPizzaIngredientEndpoints(this IEndpointRouteBuilder builder)
    {
        var ingredients = builder
            .MapGroup("/pizza-ingredients")
            .RequireAuthorization()
            .WithTags("Pizza Ingredients");

        ingredients.MapPost("/create", CreatePizzaIngredient.Handle).AllowAnonymous();

        return builder;
    }
}
