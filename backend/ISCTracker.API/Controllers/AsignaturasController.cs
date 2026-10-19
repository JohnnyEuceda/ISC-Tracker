using Microsoft.AspNetCore.Mvc;
using ISCTracker.Application.Interfaces;
using ISCTracker.Domain.Entities;

namespace ISCTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsignaturasController : ControllerBase
{
    private readonly IAsignaturaRepository _repository;

    public AsignaturasController(IAsignaturaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsignaturas()
    {
        var asignaturas = await _repository.GetAllAsync();
        return Ok(asignaturas);
    }

    [HttpPost]
    public async Task<IActionResult> CrearAsignatura([FromBody] Asignatura asignatura)
    {
        if (string.IsNullOrWhiteSpace(asignatura.Nombre))
        {
            return BadRequest("El nombre de la asignatura es obligatorio.");
        }

        var nuevaAsignatura = await _repository.AddAsync(asignatura);

        return CreatedAtAction(
            nameof(GetAsignaturas),
            new { id = nuevaAsignatura.Id },
            nuevaAsignatura);
    }
}
