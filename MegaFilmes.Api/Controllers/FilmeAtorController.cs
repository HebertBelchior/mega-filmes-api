using MegaFilmes.Api.Services;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.FilmeAtorDto;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmeAtorController : ControllerBase
{
    private readonly IFilmeAtorService _filmeAtorService;

    public FilmeAtorController(IFilmeAtorService filmeAtorservice)
    {
        _filmeAtorService = filmeAtorservice;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateFilmeAtorDto filmeAtorDto)
    {
        var resultado = await _filmeAtorService.CreateAsync(filmeAtorDto);
        if (resultado.Success)
            return Created("", resultado.Data);
        if (resultado.Status == 409)
            return Conflict(new { resultado.Message });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateFilmeAtorDto filmeAtorDto)
    {
        var resultado = await _filmeAtorService.UpdateAsync(id, filmeAtorDto);
        if (resultado.Success)
            return Ok(resultado.Data);
        if (resultado.Status == 404)
            return NotFound(new { resultado.Message });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var resultado = await _filmeAtorService.DeleteAsync(id);
        if (resultado.Success)
            return NoContent();
        return NotFound(new { resultado.Message });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var resultado = await _filmeAtorService.GetAllAsync();
        return Ok(resultado.Data);
    }
}