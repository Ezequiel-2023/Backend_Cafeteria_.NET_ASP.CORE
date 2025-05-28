using Inventory.Config;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Service
{
    public class ProductService
    {
        private readonly TodoContext _context;

        public ProductService(TodoContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        public async Task<IEnumerable<Product>> ObtenerTodos()
        {
            return await _context.Product.ToListAsync();
        }

        // Obtener un producto por ID
        public async Task<Product?> ObtenerPorId(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        // Agregar un nuevo producto usando ProductDTO
        public async Task<Product> Agregar(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Actualizar un producto existente
        public async Task<bool> Actualizar(int id, ProductDTO productActualizado)
        {
            var product = await ObtenerPorId(id);
            if (product == null) return false;

            product.Name = productActualizado.Name;
            product.Description = productActualizado.Description;
            product.Price = productActualizado.Price;
            product.Quantity = productActualizado.Quantity;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un producto
        public async Task<bool> Eliminar(int id)
        {
            var product = await ObtenerPorId(id);
            if (product == null) return false;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
