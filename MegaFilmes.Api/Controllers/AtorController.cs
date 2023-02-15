using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.AtorDto;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AtorController : ControllerBase
{
    private readonly IAtorService _AtorService;

    public AtorController(IAtorService service)
    {
        _AtorService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateAtorDto AtorDto)
    {
        var resultado = await _AtorService.CreateAsync(AtorDto);
        if (resultado.Success)
            return CreatedAtAction(nameof(GetByIdAsync), new { id = resultado.Data.Id }, resultado.Data);
        if (resultado.Status == 409)
            return Conflict(new { resultado.Message });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateAtorDto atorDto)
    {
        var resultado = await _AtorService.UpdateAsync(id, atorDto);
        if (resultado.Success)
            return Ok(resultado.Data);
        if (resultado.Status == 404)
            return NotFound(new { resultado.Message });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var resultado = await _AtorService.DeleteAsync(id);
        if (resultado.Success)
            return NoContent();
        return NotFound(new { resultado.Message });
    }

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetByName(string nome)
    {
        var resultado = await _AtorService.GetByName(nome);
        return Ok(resultado.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var resultado = await _AtorService.GetAllAsync();
        return Ok(resultado.Data);
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var resultado = await _AtorService.GetByIdAsync(id);
        if (resultado.Success)
            return Ok(resultado.Data);
        return NotFound(new { resultado.Message });
    }
}
