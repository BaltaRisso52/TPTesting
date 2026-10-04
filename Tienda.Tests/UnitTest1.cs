
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

        Assert.NotNull(resultado);
        Assert.Equal("Gaseosa", resultado.Nombre);
        Assert.Equal(2000m, resultado.Precio);
    }

    [Fact]
    public void BuscarProducto_Inexistente_DebeDevolverNull()
    {
        Tienda tienda = new();

        var resultado = tienda.BuscarProducto("Pizza");

        Assert.Null(resultado);
    }

    [Fact]
    public void EliminarProducto_Existente_DebeEliminarlo()
    {
        Tienda tienda = new();
        var producto = new Producto(
            "Papas", 3000m, "Comida");

        tienda.AgregarProducto(producto);

        bool eliminado = tienda.EliminarProducto("Papas");

        Assert.True(eliminado);
        Assert.Null(tienda.BuscarProducto("Papas"));
    }
}