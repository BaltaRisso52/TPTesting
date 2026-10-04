
namespace Tienda;

public class Producto
{
    public string Nombre { get; set; }
    public virtual decimal Precio { get; private set; }
    public string Categoria { get; set; }

    public Producto(string nombre, decimal precio, string categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
    }

    public virtual void ActualizarPrecio(decimal nuevoPrecio)
    {
        if (nuevoPrecio < 0)
        {
            throw new ArgumentException(
                "El precio no puede ser negativo.");
        }

        Precio = nuevoPrecio;
    }
}