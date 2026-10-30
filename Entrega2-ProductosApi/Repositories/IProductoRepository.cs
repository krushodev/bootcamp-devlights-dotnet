using ProductosApi.Models;

namespace ProductosApi.Repositories;

public interface IProductoRepository
{
    List<Producto> ObtenerTodos();
    Producto ObtenerPorId(int id);
    Producto Agregar(Producto producto);
    Producto Actualizar(Producto producto);
    bool Eliminar(int id);
}
