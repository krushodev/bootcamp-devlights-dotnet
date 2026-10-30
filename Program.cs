using GestorProductos;

IProductoRepository repo = new ProductoRepository();

Console.WriteLine("=== Todos los productos ===");
foreach (var producto in repo.ObtenerTodos())
{
    Console.WriteLine($"{producto.Id} - {producto.Nombre} - ${producto.Precio} - {producto.Categoria} - Activo: {producto.Activo}");
}

Console.WriteLine();
Console.WriteLine("=== Buscar producto por Id (2) ===");
var encontrado = repo.ObtenerPorId(2);
if (encontrado != null)
{
    Console.WriteLine($"{encontrado.Id} - {encontrado.Nombre} - ${encontrado.Precio}");
}
else
{
    Console.WriteLine("No se encontró el producto.");
}

Console.WriteLine();
Console.WriteLine("=== Filtrar por categoría (Periféricos) ===");
foreach (var producto in repo.BuscarPorCategoria("Periféricos"))
{
    Console.WriteLine($"{producto.Id} - {producto.Nombre} - ${producto.Precio}");
}

Console.WriteLine();
Console.WriteLine("=== Agregar un producto nuevo ===");
repo.Agregar(new Producto
{
    Id = 5,
    Nombre = "Webcam Full HD",
    Precio = 32000m,
    Categoria = "Periféricos",
    Activo = true
});

foreach (var producto in repo.ObtenerTodos())
{
    Console.WriteLine($"{producto.Id} - {producto.Nombre} - ${producto.Precio} - {producto.Categoria} - Activo: {producto.Activo}");
}
