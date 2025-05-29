namespace Inventory.DTO;
public class CategoriaDTO
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // No es necesario incluir la colección de productos aquí, ya que no se usa en las operaciones básicas
}