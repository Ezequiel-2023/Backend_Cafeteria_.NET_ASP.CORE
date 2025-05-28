
namespace Inventory.Config;
using Microsoft.EntityFrameworkCore;

using Inventory.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<VentaOrden> VentaOrdenes { get; set; } = null!;    
    public DbSet<OrdenProduct> OrdenProducts { get; set; } = null!;
    public DbSet<Orden> Ordenes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Venta> Ventas { get; set; } = null!;
    public DbSet<Rol> Rol { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Configurar datetime(0) global para todas las propiedades DateTime
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        foreach (var property in entityType.GetProperties())
        {
            if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
            {
                property.SetColumnType("datetime(0)");
            }
        }
    }

    // Configurar claves compuestas (si tienes muchas-a-muchas)
    modelBuilder.Entity<OrdenProduct>().HasKey(op => new { op.OrdenId, op.ProductoId });
    modelBuilder.Entity<VentaOrden>().HasKey(vo => new { vo.VentaId, vo.OrdenId });
}

}