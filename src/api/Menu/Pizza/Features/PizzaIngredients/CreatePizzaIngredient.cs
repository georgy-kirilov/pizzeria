using FluentValidation;
using Menu.Pizza.Database;
using Menu.Pizza.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.Validation;

namespace Menu.Pizza.Features.PizzaIngredients;

public static class CreatePizzaIngredient
{
    public static async Task<IResult> Handle(
        Request request,
        PizzaDbContext db,
        IValidator<Request> validator)
    {
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var ingredient = new PizzaIngredient
        {
            Name = request.IngredientName.Trim(),
            TypeId = request.IngredientTypeId,
            Pricings = request.Pricings.Select(p => new PizzaIngredientPricing
            {
                RegularPrice = p.RegularPrice,
                PizzaSizeId = p.PizzaSizeId,
                PriceForExtra = p.PriceForExtra
            })
            .ToList()
        };

        await db.PizzaIngredients.AddAsync(ingredient);
        await db.SaveChangesAsync();

        return Results.Ok();
    }

    public record Request
    (
        string IngredientName,
        int IngredientTypeId,
        PizzaIngredientPricingModel[] Pricings
    );

    public record PizzaIngredientPricingModel
    (
        decimal RegularPrice,
        decimal PriceForExtra,
        int PizzaSizeId
    );

    public class Validator : AbstractValidator<Request>
    {
        public Validator(PizzaDbContext db)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.IngredientName)
                .NotEmpty()
                .MaximumLength(PizzaIngredient.NameMaxLength)
                .MustAsync((name, token) => db.PizzaIngredients.AllAsync(i => i.Name != name, token))
                .WithAlreadyExistsError();

            RuleFor(x => x.IngredientTypeId)
                .NotEmpty()
                .MustAsync((typeId, token) => db.PizzaIngredientTypes.AnyAsync(t => t.Id == typeId, token))
                .WithDoesNotExistError();

            RuleFor(x => x.Pricings)
                .NotEmpty()
                .ForEach(p => p.SetValidator(new PizzaIngredientPricingModelValidator(db)));
        }
    }

    public class PizzaIngredientPricingModelValidator : AbstractValidator<PizzaIngredientPricingModel>
    {
        public PizzaIngredientPricingModelValidator(PizzaDbContext db)
        {
            RuleFor(x => x.RegularPrice)
                .NotEmpty()
                .GreaterThanOrEqualTo(PizzaIngredientPricing.RegularPriceMinValue);

            RuleFor(x => x.PriceForExtra)
                .NotEmpty()
                .GreaterThanOrEqualTo(PizzaIngredientPricing.PriceForExtraMinValue);

            RuleFor(x => x.PizzaSizeId)
                .NotEmpty()
                .MustAsync((sizeId, token) => db.PizzaSizes.AnyAsync(x => x.Id == sizeId, token))
                .WithDoesNotExistError();
        }
    }
}
