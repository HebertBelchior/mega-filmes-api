using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.FilmeDto;
using Microsoft.AspNetCore.Mvc;

namespace MegaFilmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateFilmeDto filmeDto)
    {
        var resultado = await _filmeService.CreateAsync(filmeDto);
        if (resultado.Success)
            return CreatedAtAction(nameof(GetByIdAsync), new {id = resultado.Data.Id}, resultado.Data);
        if (resultado.Status == 409)
            return Conflict(new { resultado.Message});
        return BadRequest(new { resultado.Message, resultado.Errors });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateFilmeDto filmeDto)
    {
        var resultado = await _filmeService.UpdateAsync(id, filmeDto);
        if (resultado.Success)
            return Ok(resultado.Data);
        if(resultado.Status == 404)
            return NotFound(new {resultado.Message});
        return BadRequest(new { resultado.Message, resultado.Errors});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var resultado = await _filmeService.DeleteAsync(id);
        if (resultado.Success)
            return NoContent();
        return NotFound(new { resultado.Message });
    }

    [HttpGet("Genero")]
    public async Task<IActionResult> GetByGender(string genero)
    {
        var resultado = await _filmeService.GetByGender(genero);
        return Ok(resultado.Data);
    }

    [HttpGet("Diretor")]
    public async Task<IActionResult> GetByDirector(string diretor)
    {
        var resultado = await _filmeService.GetByDirector(diretor);
        return Ok(resultado.Data);
    }

    [HttpGet("Nome")]
    public async Task<IActionResult> GetByName(string nome)
    {
        var resultado = await _filmeService.GetByName(nome);
        return Ok(resultado.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var resultado = await _filmeService.GetAllAsync();
        return Ok(resultado.Data);
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var resultado = await _filmeService.GetByIdAsync(id);
        if(resultado.Success)
            return Ok(resultado.Data);
        return NotFound(new { resultado.Message });
    }
}
