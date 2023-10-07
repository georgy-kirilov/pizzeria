using Microsoft.EntityFrameworkCore;
using Pizzeria.Api.Menu.Database;
using Pizzeria.Api.Menu.Database.Seeding;
using Pizzeria.Api.Menu.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-DNGOEFR\\SQLEXPRESS;Database=Pizzeria;Trusted_Connection=True;TrustServerCertificate=True"));

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetRequiredService<MenuDbContext>();
await db.Database.EnsureCreatedAsync();
await PizzaDataSeeder.Seed(db);

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/api/pizzas/list", GetPizzasList.Handle);

app.MapGet("/api/pizzas/info/{id:int}", GetFullPizzaInfo.Handle);

app.Run();
