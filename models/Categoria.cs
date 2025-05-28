namespace Inventory.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}