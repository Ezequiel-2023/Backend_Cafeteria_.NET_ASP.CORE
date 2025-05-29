using Inventory.Models;

namespace Inventory.DTO;

public class VentaOrdenDTO
{
    public int VentaId { get; set; }
    public Venta Venta { get; set; } = null!;
    public int OrdenId { get; set; }
    public Orden Orden { get; set; } = null!;
    
}