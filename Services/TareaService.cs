using webapi;
using webapi.Models;

namespace Services.TareaService;
public class TareaService : ITareaService
{
    private TareasContext context;
    public TareaService(TareasContext _context)
    {
        this.context = _context;
    }

    public bool Delete(Guid id)
    {
        var tareaEliminar = context.Tareas.Find(id);
        if(tareaEliminar != null)
        {
            context.Tareas.Remove(tareaEliminar);
            return context.SaveChanges() > 0;
        }
        return false;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public bool Save(Tarea tarea)
    {
        tarea.FechaCreacion = DateTime.Now;
        context.Tareas.Add(tarea);
        return context.SaveChanges() > 0;
    }

    public bool Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual != null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.Estatus = tarea.Estatus;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Titulo = tarea.Titulo;
            context.Tareas.Update(tareaActual);
            return context.SaveChanges() > 0;
        }
        return false;
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    bool Save(Tarea tarea);
    bool Update(Guid id, Tarea tarea);
    bool Delete(Guid id);
}