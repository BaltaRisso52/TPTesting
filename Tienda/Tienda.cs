namespace Tienda;

public class Tienda
{
    private List<Producto> inventario = new();

    public void AgregarProducto(Producto producto)
    {
        inventario.Add(producto);
    }

    public Producto? BuscarProducto(string nombre)
    {
        foreach (Producto producto in inventario)
        {
            if (producto.Nombre == nombre)
            {
                return producto;
            }
        }

        return null;
    }

    public bool EliminarProducto(string nombre)
    {
        foreach (Producto producto in inventario)
        {
            if (producto.Nombre == nombre)
            {
                inventario.Remove(producto);
                return true;
            }
        }

        return false;
    }
}