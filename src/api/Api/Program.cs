using FluentValidation;
using Menu;
using Menu.Pizza.Database;
using Menu.Pizza.Database.Seeding;
using Menu.Pizza.Features;
using Menu.Pizza.Features.PizzaIngredients;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Sources.Clear();

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(s => s.FullName!.Replace('+', '.')));

builder.Services.AddAuthorization();
builder.Services.AddCors();

builder.Services.AddMenuModule();

ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await using var scope = app.Services.CreateAsyncScope();
    using var db = scope.ServiceProvider.GetRequiredService<PizzaDbContext>();
    await db.Database.EnsureCreatedAsync();
    await PizzaSeeder.Seed(db);
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app
    .MapGroup("/api")
    .RequireAuthorization()
    .MapPizzaEndpoints()
    .MapPizzaIngredientEndpoints();

app.Run();
