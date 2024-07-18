using BurgerApi.Burgers.Dto;
using BurgerApi.Burgers.Models;
using BurgerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BurgerApi.Burgers.Services;

public class ComboService {

    public AppDbContext _context;
    public ComboService(AppDbContext context){
        _context = context;
    }

    public async Task<Combo> AdicionarCombo(ComboRequestDto requestDto, CancellationToken ctoken){
        var burgers = await _context.Burgers
        .Where(burger => requestDto.burgerIds.Contains(burger.Id))
        .ToListAsync(ctoken);
        
        var combo = new Combo(
            requestDto.nome,
            requestDto.preco
        );
        foreach (var burger in burgers)
        {
            combo.AdicionarBurger(burger);
        }

        await _context.AddAsync(combo);
        return combo;
    }

}