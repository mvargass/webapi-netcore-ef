
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webapi.Models;

public class Tarea 
{
    public Guid TareaId {get; set;}
    public Guid CategoriaId {get; set;}
    public string Titulo {get; set;}
    public string? Descripcion {get; set;}
    public Prioridad PrioridadTarea {get; set;}
    public Estatus Estatus { get; set; }
    public DateTime FechaCreacion {get; set;}
    [ValidateNever]
    public virtual Categoria Categoria {get; set;}
    [ValidateNever]
    public string Resumen {get; set;}
}

public enum Prioridad
{
    Baja, 
    Media,
    Alta
}

public enum Estatus
{
    Pendiente,
    EnProceso,
    Realizada
}