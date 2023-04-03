using webapi;
using webapi.Models;

namespace Services.CategoriaService;
public class CategoriaService : ICategoriaService
{
    private TareasContext context;
    public CategoriaService(TareasContext _context)
    {
        this.context = _context;
    }

    public bool Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual != null)
        {
            context.Categorias.Remove(categoriaActual);
            return context.SaveChanges() > 0;
        }
        return false;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual != null)
        {
            context.Categorias.Remove(categoriaActual);
            return await context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public bool Save(Categoria categoria)
    {
        context.Categorias.Add(categoria);
        return context.SaveChanges() > 0;
    }
    public async Task<bool> SaveAsync(Categoria categoria)
    {
        context.Categorias.Add(categoria);
        return await context.SaveChangesAsync() > 0;
    }

    public bool Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
            context.Update(categoriaActual);
            return context.SaveChanges() > 0;
        }
        return false;
    }
    public async Task<bool> UpdateAsync(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
            context.Update(categoriaActual);
            return await context.SaveChangesAsync() > 0;
        }

        return false;
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    bool Save(Categoria categoria);
    Task<bool> SaveAsync(Categoria categoria);
    bool Update(Guid id, Categoria categoria);
    Task<bool> UpdateAsync(Guid id, Categoria categoria);
    bool Delete(Guid id);
    Task<bool> DeleteAsync(Guid id);
}