using BurgerApi.Burgers.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApi.Burgers.Controllers;

[ApiController]
[Route("burgers")]
public class BurgerController : ControllerBase {

    private readonly BurgerService _service;

    public BurgerController(BurgerService service) {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBurger([FromBody] BurgerRequestDto requestDto, CancellationToken ctoken) {
        return Ok(await _service.CriarBurger(requestDto, ctoken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBurgerById(Guid id, CancellationToken ctoken) {
        var burger = await _service.BuscarPorId(id, ctoken);

        if (burger == null) {
            return NotFound("Objeto não encontrado");
        }

        return Ok(burger);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ctoken) {
        return Ok(await _service.BuscarTodos(ctoken));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateName(BurgerRequestDto requestDto, Guid id, CancellationToken ctoken) {
        var update = await _service.Atualizar(requestDto, id, ctoken);
        if (update == null) return NotFound("Objeto não encontrado");
        return Ok(update);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ctoken) {
        return Ok(await _service.Desativar(id, ctoken));
    }

}