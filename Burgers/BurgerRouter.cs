using BurgerApi.Data;

namespace BurgerApi.Burgers;

public static class BurgerRouter {
    public static void AddBurgerRoutes(this WebApplication app) {

    // var rotasBurgers = app.MapGroup("burgers");


        // POSTs
         app.MapPost("burger",
         async (AddBurgerRequest request, AppDbContext context) => {
            var newBurger = new Burger(request.Nome);
            await context.Burgers.AddAsync(newBurger);
            await context.SaveChangesAsync();
         });

        // GETs
        app.MapGet("burger",
         () => new Burger("Caio"));

    }
}