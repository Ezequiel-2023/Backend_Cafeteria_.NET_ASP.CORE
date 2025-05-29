namespace  Inventory.DTO;

public class VentaDTO
{
    public int Id { get; set; } 
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public string? Descripcion { get; set; }
    
}