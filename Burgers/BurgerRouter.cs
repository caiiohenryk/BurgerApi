using BurgerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Burgers;

public static class BurgerRouter {
    public static void AddBurgerRoutes(this WebApplication app) {

    var rotasBurgers = app.MapGroup("burgers");


        // POSTs
         app.MapPost("burgers",
         async (AddBurgerRequest request, AppDbContext context) => {
            var jaExiste = await context.Burgers
            .AnyAsync(Burger => Burger.Nome == request.Nome);

            if (jaExiste)
            return Results.Conflict("Estudante já existe.");

            var newBurger = new Burger(request.Nome);
            await context.Burgers.AddAsync(newBurger);
            await context.SaveChangesAsync();

            return Results.Ok(newBurger);
         });

        

        // GETs
        app.MapGet("burger",
         () => new Burger("Caio"));

    }
}