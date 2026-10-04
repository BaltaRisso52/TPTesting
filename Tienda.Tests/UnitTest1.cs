
using Xunit;
using Tienda;

namespace Tienda.Tests;

public class UnitTest1
{
    [Fact]
    public void AgregarProducto_DebeAgregarloAlInventario()
    {
        // Arrange: preparar los objetos
        Tienda tienda = new();
        var producto = new Producto(
            "Hamburguesa", 8000m, "Comida");

        // Act: ejecutar la operación
        tienda.AgregarProducto(producto);

        // Assert: comprobar el resultado
        var resultado = tienda.BuscarProducto("Hamburguesa");

        Assert.Same(producto, resultado);
    }

    [Fact]
    public void BuscarProducto_Existente_DebeDevolverlo()
    {
        Tienda tienda = new();
        var producto = new Producto(
            "Gaseosa", 2000m, "Bebida");

        tienda.AgregarProducto(producto);

        var resultado = tienda.BuscarProducto("Gaseosa");

        Assert.Same(producto, resultado);
    }

    [Fact]
    public void BuscarProducto_Inexistente_DebeLanzarExcepcion()
    {
        Tienda tienda = new();

        Assert.Throws<KeyNotFoundException>(
            () => tienda.BuscarProducto("Pizza"));
    }

    [Fact]
    public void EliminarProducto_Existente_DebeEliminarlo()
    {
        Tienda tienda = new();
        var producto = new Producto(
            "Papas", 3000m, "Comida");

        tienda.AgregarProducto(producto);

        tienda.EliminarProducto("Papas");

        Assert.Throws<KeyNotFoundException>(
            () => tienda.BuscarProducto("Papas"));
    }

    [Fact]
    public void EliminarProducto_Inexistente_DebeLanzarExcepcion()
    {
        Tienda tienda = new();

        Assert.Throws<KeyNotFoundException>(
            () => tienda.EliminarProducto("Pizza"));
    }

    [Fact]
    public void ActualizarPrecio_Valido_DebeModificarPrecio()
    {
        var producto = new Producto(
            "Hamburguesa", 8000m, "Comida");

        producto.ActualizarPrecio(9000m);

        Assert.Equal(9000m, producto.Precio);
    }

    [Fact]
    public void ActualizarPrecio_Negativo_DebeLanzarExcepcion()
    {
        var producto = new Producto(
            "Hamburguesa", 8000m, "Comida");

        Assert.Throws<ArgumentException>(
            () => producto.ActualizarPrecio(-100m));

        Assert.Equal(8000m, producto.Precio);
    }
}