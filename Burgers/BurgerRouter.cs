using BurgerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Burgers;

public static class BurgerRouter {
    public static void AddBurgerRoutes(this WebApplication app) {

    var rotasBurgers = app.MapGroup("burgers");


        // POSTs
         rotasBurgers.MapPost("burgers",
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
        rotasBurgers.MapGet("", async (AppDbContext appDbContext) => {
            var burgers = await appDbContext
            .Burgers
            .Where(burgers => burgers.Ativo == true)
            .Select(burger => new BurgerResponseDto(burger.Id, burger.Nome))
            .ToListAsync();
            return burgers;
        });

        // PUTs
        rotasBurgers.MapPut("{id}",
        async (UpdateBurgerRequest request, AppDbContext context, Guid id) => {
            var burger = await context.Burgers
            .SingleOrDefaultAsync(burger => burger.Id == id);

            if (burger == null) return Results.NotFound("Objeto não encontrado");

            burger.atualizarNome(request.nome);

            await context.SaveChangesAsync();
            return Results.Ok(new BurgerResponseDto(burger.Id, burger.Nome));
        });

        // DELETEs
        rotasBurgers.MapDelete("{id}",
        async (Guid id, AppDbContext context) =>
        {
            var burger = await context.Burgers
            .SingleOrDefaultAsync(burger => burger.Id == id);

            if (burger == null) return Results.NotFound("Objeto não encontrado");
            if (burger.Ativo == false) return Results.Conflict("Objeto já desativado");

            burger.desativar();

            await context.SaveChangesAsync();
            return Results.Ok();

        });

    }
}