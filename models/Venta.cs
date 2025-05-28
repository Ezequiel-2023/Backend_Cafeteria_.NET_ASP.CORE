namespace Inventory.Models;

public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public string? Description { get; set; }   

    public ICollection<VentaOrden> Ordenes { get; set; } = new List<VentaOrden>();    
}