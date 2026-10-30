using ProductosApi.DTOs;
using ProductosApi.Models;
using ProductosApi.Repositories;

namespace ProductosApi.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public List<ProductoDto> ObtenerTodos()
    {
        return _repository.ObtenerTodos()
            .Select(p => ADto(p))
            .ToList();
    }

    public ProductoDto ObtenerPorId(int id)
    {
        var producto = _repository.ObtenerPorId(id);
        if (producto == null)
        {
            return null;
        }

        return ADto(producto);
    }

    public ProductoDto Crear(CreateProductoDto dto)
    {
        var producto = new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio.Value,
            Categoria = dto.Categoria,
            Activo = true
        };

        var creado = _repository.Agregar(producto);
        return ADto(creado);
    }

    public ProductoDto Actualizar(int id, CreateProductoDto dto)
    {
        var producto = new Producto
        {
            Id = id,
            Nombre = dto.Nombre,
            Precio = dto.Precio.Value,
            Categoria = dto.Categoria,
            Activo = true
        };

        var actualizado = _repository.Actualizar(producto);
        if (actualizado == null)
        {
            return null;
        }

        return ADto(actualizado);
    }

    public bool Eliminar(int id)
    {
        return _repository.Eliminar(id);
    }

    private static ProductoDto ADto(Producto producto)
    {
        return new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Categoria = producto.Categoria,
            Activo = producto.Activo
        };
    }
}
