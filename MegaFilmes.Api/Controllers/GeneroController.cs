using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.GeneroDto;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IGeneroService _generoService;

    public GeneroController(IGeneroService generoService)
    {
        _generoService = generoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var resultado = await _generoService.GetAllAsync();
        return Ok(resultado.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateGeneroDto genroDto)
    {
        var resultado = await _generoService.CreateAsync(genroDto);
        if (resultado.Success)
            return Created($"https://localhost:7030/api/genro/{resultado.Data.Id}", resultado.Data);
        if (resultado.Status == 409)
            return Conflict(new { resultado.Message });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }
}
