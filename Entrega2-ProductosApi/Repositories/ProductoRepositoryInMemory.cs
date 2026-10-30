using ProductosApi.Models;

namespace ProductosApi.Repositories;

public class ProductoRepositoryInMemory : IProductoRepository
{
    // Son static porque el repositorio es Scoped (se crea uno nuevo por request).
    // Sin static, la lista se reiniciaría en cada llamada y se perderían los cambios.
    private static readonly List<Producto> _productos = new List<Producto>
    {
        new Producto { Id = 1, Nombre = "Teclado mecánico", Precio = 45000m, Categoria = "Periféricos", Activo = true },
        new Producto { Id = 2, Nombre = "Mouse inalámbrico", Precio = 18500m, Categoria = "Periféricos", Activo = true },
        new Producto { Id = 3, Nombre = "Monitor 24 pulgadas", Precio = 210000m, Categoria = "Monitores", Activo = true },
        new Producto { Id = 4, Nombre = "Auriculares viejos", Precio = 9000m, Categoria = "Audio", Activo = false }
    };
    private static int _proximoId = 5;

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public Producto Agregar(Producto producto)
    {
        producto.Id = _proximoId++;
        _productos.Add(producto);
        return producto;
    }

    public Producto Actualizar(Producto producto)
    {
        var existente = _productos.FirstOrDefault(p => p.Id == producto.Id);
        if (existente == null)
        {
            return null;
        }

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Categoria = producto.Categoria;
        existente.Activo = producto.Activo;
        return existente;
    }

    public bool Eliminar(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
        {
            return false;
        }

        _productos.Remove(producto);
        return true;
    }
}
