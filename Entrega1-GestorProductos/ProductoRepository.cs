namespace GestorProductos;

public class ProductoRepository : IProductoRepository
{
    private readonly List<Producto> _productos;

    public ProductoRepository()
    {
        _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Teclado mecánico", Precio = 45000m, Categoria = "Periféricos", Activo = true },
            new Producto { Id = 2, Nombre = "Mouse inalámbrico", Precio = 18500m, Categoria = "Periféricos", Activo = true },
            new Producto { Id = 3, Nombre = "Monitor 24 pulgadas", Precio = 210000m, Categoria = "Monitores", Activo = true },
            new Producto { Id = 4, Nombre = "Auriculares viejos", Precio = 9000m, Categoria = "Audio", Activo = false }
        };
    }

    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return _productos;
    }

    public Producto ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public List<Producto> BuscarPorCategoria(string categoria)
    {
        return _productos
            .Where(p => p.Categoria.ToLower() == categoria.ToLower())
            .ToList();
    }
}
