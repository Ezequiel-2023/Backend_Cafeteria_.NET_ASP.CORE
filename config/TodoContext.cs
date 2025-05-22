
namespace Inventory.Config;
using Microsoft.EntityFrameworkCore;

using Inventory.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Product> TodoItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products");
         modelBuilder.Entity<Product>()
        .Property(p => p.CreatedAt)
        .HasColumnType("datetime(0)"); 
    
        modelBuilder.Entity<Product>()
        .Property(p => p.UpdatedAt)
        .HasColumnType("datetime(0)");
    }
}