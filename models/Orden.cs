namespace Inventory.Models;

public class Orden
{
    public int Id { get; set; }
    public required string Descripcion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public string? Comentario { get; set; }
    public string NombreCliente{ get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public ICollection<OrdenProduct> OrdenProducts { get; set; } = new List<OrdenProduct>();
}