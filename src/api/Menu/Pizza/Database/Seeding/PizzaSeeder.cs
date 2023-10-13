using Bogus;
using Menu.Pizza.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Pizza.Database.Seeding;

public static class PizzaSeeder
{
    public static async Task Seed(PizzaDbContext db)
    {
        if (await db.PizzaDefinitions.AnyAsync())
        {
            return;
        }

        PizzaIngredientType cheese = new() { Name = "Cheese" };
        PizzaIngredientType sauce = new() { Name = "Sauce" };
        PizzaIngredientType meat = new() { Name = "Meat" };
        PizzaIngredientType veggies = new() { Name = "Veggies" };
        PizzaIngredientType spices = new() { Name = "Spices" };

        PizzaSize small = new() { Name = "Small", Slices = 6 };
        PizzaSize medium = new() { Name = "Medium", Slices = 8 };
        PizzaSize large = new() { Name = "Large", Slices = 10 };
        PizzaSize jumbo = new() { Name = "Jumbo", Slices = 12 };

        PizzaIngredient[] allPizzaIngredients =
        [
            new()
            {
                Name = "Mozzarella",
                Type = cheese,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.50m, PriceForExtra = 2.50m },
                    new() { PizzaSize = medium, RegularPrice = 2.00m, PriceForExtra = 3.00m },
                    new() { PizzaSize = large, RegularPrice = 2.50m, PriceForExtra = 4.50m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.00m, PriceForExtra = 5.00m },
                ]
            },
            new()
            {
                Name = "Cheddar",
                Type = cheese,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.60m, PriceForExtra = 2.40m },
                    new() { PizzaSize = medium, RegularPrice = 2.10m, PriceForExtra = 3.10m },
                    new() { PizzaSize = large, RegularPrice = 2.60m, PriceForExtra = 4.20m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.20m, PriceForExtra = 4.80m },
                ]
            },
            new()
            {
                Name = "Parmesan",
                Type = cheese,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.70m, PriceForExtra = 2.20m },
                    new() { PizzaSize = medium, RegularPrice = 2.15m, PriceForExtra = 3.20m },
                    new() { PizzaSize = large, RegularPrice = 2.75m, PriceForExtra = 4.30m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.25m, PriceForExtra = 5.10m },
                ]
            },
            new()
            {
                Name = "Feta",
                Type = cheese,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.55m, PriceForExtra = 2.45m },
                    new() { PizzaSize = medium, RegularPrice = 2.05m, PriceForExtra = 3.05m },
                    new() { PizzaSize = large, RegularPrice = 2.65m, PriceForExtra = 4.35m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.15m, PriceForExtra = 5.05m },
                ]
            },
            new()
            {
                Name = "Tomato",
                Type = sauce,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.50m, PriceForExtra = 0.75m },
                    new() { PizzaSize = medium, RegularPrice = 0.60m, PriceForExtra = 0.85m },
                    new() { PizzaSize = large, RegularPrice = 0.70m, PriceForExtra = 0.95m },
                    new() { PizzaSize = jumbo, RegularPrice = 0.80m, PriceForExtra = 1.05m },
                ]
            },
            new()
            {
                Name = "BBQ",
                Type = sauce,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.55m, PriceForExtra = 0.80m },
                    new() { PizzaSize = medium, RegularPrice = 0.65m, PriceForExtra = 0.90m },
                    new() { PizzaSize = large, RegularPrice = 0.75m, PriceForExtra = 1.00m },
                    new() { PizzaSize = jumbo, RegularPrice = 0.85m, PriceForExtra = 1.10m },
                ]
            },
            new()
            {
                Name = "Cream",
                Type = sauce,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.60m, PriceForExtra = 0.85m },
                    new() { PizzaSize = medium, RegularPrice = 0.70m, PriceForExtra = 0.95m },
                    new() { PizzaSize = large, RegularPrice = 0.80m, PriceForExtra = 1.05m },
                    new() { PizzaSize = jumbo, RegularPrice = 0.90m, PriceForExtra = 1.15m },
                ]
            },
            new()
            {
                Name = "Pepperoni",
                Type = meat,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.40m, PriceForExtra = 2.20m },
                    new() { PizzaSize = medium, RegularPrice = 1.90m, PriceForExtra = 2.90m },
                    new() { PizzaSize = large, RegularPrice = 2.40m, PriceForExtra = 3.60m },
                    new() { PizzaSize = jumbo, RegularPrice = 2.90m, PriceForExtra = 4.30m },
                ]
            },
            new()
            {
                Name = "Ventricina",
                Type = meat,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.50m, PriceForExtra = 2.30m },
                    new() { PizzaSize = medium, RegularPrice = 2.00m, PriceForExtra = 3.00m },
                    new() { PizzaSize = large, RegularPrice = 2.50m, PriceForExtra = 3.70m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.00m, PriceForExtra = 4.40m },
                ]
            },
            new()
            {
                Name = "Bacon",
                Type = meat,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.60m, PriceForExtra = 2.40m },
                    new() { PizzaSize = medium, RegularPrice = 2.10m, PriceForExtra = 3.10m },
                    new() { PizzaSize = large, RegularPrice = 2.60m, PriceForExtra = 3.80m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.10m, PriceForExtra = 4.50m },
                ]
            },
            new()
            {
                Name = "Buffalo Chicken",
                Type = meat,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.70m, PriceForExtra = 2.50m },
                    new() { PizzaSize = medium, RegularPrice = 2.20m, PriceForExtra = 3.20m },
                    new() { PizzaSize = large, RegularPrice = 2.70m, PriceForExtra = 3.90m },
                    new() { PizzaSize = jumbo, RegularPrice = 3.20m, PriceForExtra = 4.60m },
                ]
            },
            new()
            {
                Name = "Sausage",
                Type = meat,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.45m, PriceForExtra = 2.25m },
                    new() { PizzaSize = medium, RegularPrice = 1.95m, PriceForExtra = 2.95m },
                    new() { PizzaSize = large, RegularPrice = 2.45m, PriceForExtra = 3.65m },
                    new() { PizzaSize = jumbo, RegularPrice = 2.95m, PriceForExtra = 4.35m },
                ]
            },
            new()
            {
                Name = "Tomatos",
                Type = veggies,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.90m, PriceForExtra = 1.70m },
                    new() { PizzaSize = medium, RegularPrice = 1.20m, PriceForExtra = 2.20m },
                    new() { PizzaSize = large, RegularPrice = 1.50m, PriceForExtra = 2.70m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.80m, PriceForExtra = 3.20m },
                ]
            },
            new()
            {
                Name = "Onions",
                Type = veggies,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.85m, PriceForExtra = 1.65m },
                    new() { PizzaSize = medium, RegularPrice = 1.15m, PriceForExtra = 2.15m },
                    new() { PizzaSize = large, RegularPrice = 1.45m, PriceForExtra = 2.65m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.75m, PriceForExtra = 3.15m },
                ]
            },
            new()
            {
                Name = "Bell Peppers",
                Type = veggies,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.95m, PriceForExtra = 1.75m },
                    new() { PizzaSize = medium, RegularPrice = 1.25m, PriceForExtra = 2.25m },
                    new() { PizzaSize = large, RegularPrice = 1.55m, PriceForExtra = 2.75m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.85m, PriceForExtra = 3.25m },
                ]
            },
            new()
            {
                Name = "Mushrooms",
                Type = veggies,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 1.00m, PriceForExtra = 1.80m },
                    new() { PizzaSize = medium, RegularPrice = 1.30m, PriceForExtra = 2.30m },
                    new() { PizzaSize = large, RegularPrice = 1.60m, PriceForExtra = 2.80m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.90m, PriceForExtra = 3.30m },
                ]
            },
            new()
            {
                Name = "Olives",
                Type = veggies,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.80m, PriceForExtra = 1.60m },
                    new() { PizzaSize = medium, RegularPrice = 1.10m, PriceForExtra = 2.10m },
                    new() { PizzaSize = large, RegularPrice = 1.40m, PriceForExtra = 2.60m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.70m, PriceForExtra = 3.10m },
                ]
            },
            new()
            {
                Name = "Spinach",
                Type = veggies,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.75m, PriceForExtra = 1.55m },
                    new() { PizzaSize = medium, RegularPrice = 1.05m, PriceForExtra = 2.05m },
                    new() { PizzaSize = large, RegularPrice = 1.35m, PriceForExtra = 2.55m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.65m, PriceForExtra = 3.05m },
                ]
            },
            new()
            {
                Name = "Oregano",
                Type = spices,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.50m, PriceForExtra = 0.90m },
                    new() { PizzaSize = medium, RegularPrice = 0.70m, PriceForExtra = 1.10m },
                    new() { PizzaSize = large, RegularPrice = 0.90m, PriceForExtra = 1.30m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.10m, PriceForExtra = 1.50m },
                ]
            },
            new()
            {
                Name = "Rosemary",
                Type = spices,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.55m, PriceForExtra = 0.95m },
                    new() { PizzaSize = medium, RegularPrice = 0.75m, PriceForExtra = 1.15m },
                    new() { PizzaSize = large, RegularPrice = 0.95m, PriceForExtra = 1.35m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.15m, PriceForExtra = 1.55m },
                ]
            },
            new()
            {
                Name = "Basil",
                Type = spices,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.60m, PriceForExtra = 1.00m },
                    new() { PizzaSize = medium, RegularPrice = 0.80m, PriceForExtra = 1.20m },
                    new() { PizzaSize = large, RegularPrice = 1.00m, PriceForExtra = 1.40m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.20m, PriceForExtra = 1.60m },
                ]
            },
            new()
            {
                Name = "Thyme",
                Type = spices,
                Pricings =
                [
                    new() { PizzaSize = small, RegularPrice = 0.65m, PriceForExtra = 1.05m },
                    new() { PizzaSize = medium, RegularPrice = 0.85m, PriceForExtra = 1.25m },
                    new() { PizzaSize = large, RegularPrice = 1.05m, PriceForExtra = 1.45m },
                    new() { PizzaSize = jumbo, RegularPrice = 1.25m, PriceForExtra = 1.65m },
                ]
            }
        ];

        PizzaIngredientType[] allPizzaIngredientTypes =
        [
            cheese,
            sauce,
            meat,
            veggies,
            spices,
        ];

        PizzaSize[] allPizzaSizes =
        [
            small,
            medium,
            large,
            jumbo,
        ];

        PizzaDough[] allPizzaDoughs =
        [
            new() { Name = "Traditional", Price = 0 },
            new() { Name = "Italian", Price = 0 },
            new() { Name = "Gluten-Free", Price = 1.60m },
            new() { Name = "Thin", Price = 0 },
            new() { Name = "Philadelphia", Price = 2.50m },
            new() { Name = "Vegan", Price = 1.00m },
        ];

        await db.PizzaIngredientTypes.AddRangeAsync(allPizzaIngredientTypes);
        await db.PizzaIngredients.AddRangeAsync(allPizzaIngredients);
        await db.PizzaSizes.AddRangeAsync(allPizzaSizes);
        await db.PizzaDoughs.AddRangeAsync(allPizzaDoughs);

        int minIngredientsOnPizza = 2;
        int maxIngredientsOnPizza = 12;
        int minBasePizzaPrice = 10;
        int maxBasePizzaPrice = 20;

        HashSet<string> pizzaNamesToSeed =
        [
            "Margherita",
            "Pepperoni",
            "Sicilian",
            "Calzone",
            "Neapolitan",
            "BBQ Chicken",
            "Hawaiian",
            "Quattro Formaggi",
            "Meat Lover's",
            "Veggie Supreme",
        ];

        Faker faker = new();

        foreach (var pizzaName in pizzaNamesToSeed)
        {
            PizzaDefinition pizza = new() { Name = pizzaName };

            var ingredientsCount = faker.Random.Number(minIngredientsOnPizza, maxIngredientsOnPizza);

            var ingredients = faker
                .PickRandom(allPizzaIngredients, ingredientsCount)
                .Select(ingredient => new PizzaIngredientMapping
                {
                    Ingredient = ingredient,
                    Pizza = pizza,
                    UseExtraAmount = faker.Random.Bool(0.2f)
                });

            pizza.Ingredients.AddRange(ingredients);

            var pizzaPricingsCount = faker.Random.Number(1, allPizzaSizes.Length);

            var pizzaPricings = faker
                .PickRandom(allPizzaSizes, pizzaPricingsCount)
                .Select(size => new PizzaPricing
                {
                    Size = size,
                    Pizza = pizza,
                    Price = faker.Random.Decimal(minBasePizzaPrice, maxBasePizzaPrice),
                    Doughs = faker.PickRandom(allPizzaDoughs, faker.Random.Number(1, allPizzaDoughs.Length)).ToList()
                });

            pizza.Pricings.AddRange(pizzaPricings);

            await db.PizzaDefinitions.AddAsync(pizza);
        }

        await db.SaveChangesAsync();
    }
}
