using Microsoft.AspNetCore.Mvc;
using Services.TareaService;
using webapi.Models;

namespace Controllers.TareaController;

[ApiController]
[Route("api/[controller]")]
public class TareaController: ControllerBase
{
    private ITareaService service;
    public TareaController(ITareaService tareaService)
    {
        service = tareaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        var resultado = service.Save(tarea);
        if(resultado)
        {
            return Ok("Tarea Insertada");
        }

        return BadRequest("Error al Insertar la Tarea");
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        var resultado = service.Update(id, tarea);
        if (resultado)
        {
            return Ok("Tarea Actualizada");
        }
        return BadRequest("Error al Actualizar la Tarea");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var resultado = service.Delete(id);
        if(resultado)
        {
            return Ok("Tarea Eliminada");
        }
        return BadRequest("Error al Eliminar la Tarea");
    }
}