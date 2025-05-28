namespace Inventory.Models;

public class VentaOrden
{
    public int VentaId { get; set; }
    public Venta Venta { get; set; } = null!;

    public int OrdenId { get; set; }
    public Orden Orden { get; set; } = null!;
}
