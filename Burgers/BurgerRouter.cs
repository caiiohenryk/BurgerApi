using BurgerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Burgers;

public static class BurgerRouter {
    public static void AddBurgerRoutes(this WebApplication app) {

    var rotasBurgers = app.MapGroup("burgers");


        // POSTs
         rotasBurgers.MapPost("",
        //  o CancellationToken é uma boa prática que garante o bom funcionamento do banco de dados em caso de
        // fechamento indevido da aplicação enquanto ainda houver persistência do BD;
         async (BurgerRequestDto request, AppDbContext context, CancellationToken ctoken) => {
            var jaExiste = await context.Burgers
            .AnyAsync(Burger => Burger.Nome == request.Nome, ctoken);

            if (jaExiste)
            return Results.Conflict("Objeto já existe.");

            var newBurger = new Burger(request.Nome);
            await context.Burgers.AddAsync(newBurger, ctoken);
            await context.SaveChangesAsync(ctoken);

            return Results.Ok(newBurger);
         });

        

        // GETs
        rotasBurgers.MapGet("", async (AppDbContext context, CancellationToken ctoken) => {
            var burgers = await context
            .Burgers
            .Where(burgers => burgers.Ativo == true)
            .Select(burger => new BurgerResponseDto(burger.Id, burger.Nome))
            .ToListAsync(ctoken);
            return burgers;
        });

        rotasBurgers.MapGet("{id}",
        async (Guid id, AppDbContext context, CancellationToken ctoken) => 
        {
            var burger = await context.Burgers
            .SingleOrDefaultAsync(burger => burger.Id == id);

            if (burger == null) return Results.NotFound("Objeto não encontrado");
            if (!burger.Ativo) return Results.Conflict("Objeto desativado.");

            return Results.Ok(new BurgerResponseDto(burger.Id, burger.Nome));
        });
        

        // PUTs
        rotasBurgers.MapPut("{id}",
        async (BurgerUpdateDto request, AppDbContext context, Guid id, CancellationToken ctoken) => {
            var burger = await context.Burgers
            .SingleOrDefaultAsync(burger => burger.Id == id, ctoken);

            if (burger == null) return Results.NotFound("Objeto não encontrado");

            burger.atualizarNome(request.nome);

            await context.SaveChangesAsync(ctoken);
            return Results.Ok(new BurgerResponseDto(burger.Id, burger.Nome));
        });

        // DELETEs
        rotasBurgers.MapDelete("{id}",
        async (Guid id, AppDbContext context, CancellationToken ctoken) =>
        {
            var burger = await context.Burgers
            .SingleOrDefaultAsync(burger => burger.Id == id, ctoken);

            if (burger == null) return Results.NotFound("Objeto não encontrado");
            if (burger.Ativo == false) return Results.Conflict("Objeto já desativado");

            burger.desativar();

            await context.SaveChangesAsync(ctoken);
            return Results.Ok();

        });

    }
}