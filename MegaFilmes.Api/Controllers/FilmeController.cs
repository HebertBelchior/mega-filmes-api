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
            return Created("", resultado.Data);
        if (resultado.Status == 409)
            return Conflict(new { resultado.Message, resultado.Errors });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateFilmeDto filmeDto)
    {
        var resultado = await _filmeService.CreateAsync(filmeDto);
        if (resultado.Success)
            return Created("", resultado.Data);
        if(resultado.Status == 404)
            return Conflict(new {resultado.Message, resultado.Errors});
        return BadRequest(new { resultado.Message, resultado.Errors});
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var resultado = await _filmeService.DeleteAsync(id);
        if(resultado.Status == 404)
            return Conflict(new {resultado.Message, resultado.Errors});
        return BadRequest(new {resultado.Message, resultado.Errors});
    }

    [HttpGet("/Gender")]
    public async Task<IActionResult> GetByGender(string nome)
    {
        var resultado = await _filmeService.GetByGender(nome);
        return Ok(resultado);
    }

    [HttpGet("/Director")]
    public async Task<IActionResult> GetByDirector(string diretor)
    {
        var resultado = await _filmeService.GetByGender(diretor);
        return Ok(resultado);
    }

    [HttpGet("/Name")]
    public async Task<IActionResult> GetByName(string nome)
    {
        var resultado = await _filmeService.GetByName(nome);
        return Ok(resultado);
    }

    [HttpGet("/Films")]
    public async Task<IActionResult> GetAllAsync()
    {
        var resultado = await _filmeService.GetAllAsync();
        return Ok(resultado);
    }

    [HttpGet("/Film")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var resultado = await _filmeService.GetByIdAsync(id);
        if(resultado.Status == 404)
            return Conflict(new { resultado.Message, resultado.Errors });
        return BadRequest(new { resultado.Message, resultado.Errors });
    }
}
