using BurgerApi.Burgers.Dto;
using BurgerApi.Burgers.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApi.Burgers.Controllers;

[ApiController]
[Route("combo")]
public class ComboController : ControllerBase {

    private readonly ComboService _service;
    public ComboController(ComboService service) {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> PostCombo([FromBody]ComboRequestDto requestDto, CancellationToken ctoken) {
        return Ok(await _service.AdicionarCombo(requestDto, ctoken));
    }

}