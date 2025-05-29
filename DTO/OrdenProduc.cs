namespace Inventory.DTO;

public class OrdenProduct
{
    public int OrdenId { get; set; }
    public required string Orden { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int ProductoId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


}