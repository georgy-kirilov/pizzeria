using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Menu.Pizza.Features;

public static class PizzaEndpoints
{
    public static IEndpointRouteBuilder MapPizzaEndpoints(this IEndpointRouteBuilder builder)
    {
        var pizzas = builder
            .MapGroup("/pizza")
            .RequireAuthorization()
            .WithTags("Pizza");

        pizzas.MapGet("/list", GetPizzasList.Handle)
            .AllowAnonymous()
            .Produces<GetPizzasList.Response>();

        pizzas.MapGet("/info/{id:int}", GetFullPizzaInfo.Handle)
            .AllowAnonymous()
            .Produces<GetFullPizzaInfo.Response>()
            .Produces(StatusCodes.Status400BadRequest);

        return builder;
    }
}
