using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.AvaliacaoDto;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoService _avaliacaoService;

    public AvaliacaoController(IAvaliacaoService avaliacaoService)
    {
        _avaliacaoService = avaliacaoService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAvaliacaoDto avaliacaoDto)
    {
        var resultado = await _avaliacaoService.CreateAsync(avaliacaoDto);
        if (resultado.Success)
            return Created($"https://localhost:7030/api/avaliacao/{resultado.Data.Id}", resultado.Data);
        if(resultado.Status == 404)
            return NotFound(new { resultado.Message });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }
}
