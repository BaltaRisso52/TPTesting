namespace Tienda;

public class Tienda
{
    private List<Producto> inventario = new();

    public void AgregarProducto(Producto producto)
    {
        inventario.Add(producto);
    }

    public Producto BuscarProducto(string nombre)
    {
        foreach (Producto producto in inventario)
        {
            if (producto.Nombre == nombre)
            {
                return producto;
            }
        }

        throw new KeyNotFoundException(
            $"No se encontró el producto: {nombre}");
    }

    public void EliminarProducto(string nombre)
    {
        Producto? productoEncontrado = inventario.Find(
            p => p.Nombre == nombre);

        if (productoEncontrado == null)
        {
            throw new KeyNotFoundException(
                $"No se encontró el producto: {nombre}");
        }

        inventario.Remove(productoEncontrado);
    }
}