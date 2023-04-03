using Microsoft.AspNetCore.Mvc;
using Services.CategoriaService;
using webapi;
using webapi.Models;

namespace Controllers.CategoriaController;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController:ControllerBase
{
    private ICategoriaService service;
    private TareasContext context;
    public CategoriaController(ICategoriaService categoriaService, TareasContext db)
    {
        service = categoriaService;
        context = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        var resultado = service.Save(categoria);
        if (resultado){
            return Ok("Categoria Insertada");
        }

        return BadRequest("Error al Insertar la Categoria");
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        var resultado = service.Update(id, categoria);
        if (resultado)
        {
            return Ok("Categoria Actualizada");
        }
        return BadRequest("Error al Actualizar la Categoria");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var resultado = service.Delete(id);
        if(resultado)
        {
            return Ok("Categoria Eliminada");
        }
        return BadRequest("Error al Eliminar la Categoria");
    }
}