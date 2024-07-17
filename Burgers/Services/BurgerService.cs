using BurgerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Burgers.Services;

public class BurgerService {
    public readonly AppDbContext _context;
    public BurgerService(AppDbContext context) {
        _context = context;
    }

    public async Task<Burger> CriarBurger(BurgerRequestDto burger, CancellationToken ctoken) {
        var newBurger = new Burger(burger.Nome);
        await _context.AddAsync(newBurger, ctoken);
        await _context.SaveChangesAsync(ctoken);

        return newBurger;
    }

    public async Task<BurgerResponseDto> BuscarPorId(Guid id, CancellationToken ctoken) {
        var burger = await _context.Burgers
        .FindAsync(id, ctoken);

        if (burger == null) return null;

        return new BurgerResponseDto(burger.Id, burger.Nome);
    }

    public async Task<List<BurgerResponseDto>> BuscarTodos(CancellationToken ctoken) {
        var burgers = await _context.Burgers
        .Where(burgers => burgers.Ativo)
        .Select(burger => new BurgerResponseDto(burger.Id, burger.Nome))
        .ToListAsync(ctoken);

        return burgers;
    }

    public async Task<BurgerResponseDto> Atualizar(BurgerRequestDto requestDto, Guid id, CancellationToken ctoken) {
        var updateBurger = await _context.Burgers
        .SingleOrDefaultAsync(updateBurger => updateBurger.Id == id, ctoken);
        if (updateBurger == null) return null;
        updateBurger.atualizarNome(requestDto.Nome);
        await _context.SaveChangesAsync(ctoken);

        return new BurgerResponseDto(updateBurger.Id, updateBurger.Nome);
    }

    public async Task<bool> Desativar(Guid id, CancellationToken ctoken) {
        var burger = await _context.Burgers.FindAsync(id, ctoken);
        if (burger == null) return false;
        burger.desativar();
        await _context.SaveChangesAsync(ctoken);

        return true;
    }
}