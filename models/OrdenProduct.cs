namespace Inventory.Models;

public class OrdenProduct
{
    public int OrdenId { get; set; }
    public Orden Orden { get; set; } = null!;

    public int ProductoId { get; set; }
    public Product Product { get; set; } = null!;

    public int Cantidad { get; set; }
}