namespace Inventory.DTO;
public class Orden
{
    public int Id { get; set; }
    public required string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public string? Comentario { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
}