using Inventory.Config;
using Inventory.DTO;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Service
{
    public class RolService
    {
        private readonly TodoContext _context;

        public RolService(TodoContext context)
        {
            _context = context;
        }

        // Obtener todos los roles
        public async Task<IEnumerable<Rol>> ObtenerTodos()
        {
            return await _context.Rol.ToListAsync();
        }

        // Obtener un rol por ID
        public async Task<Rol?> ObtenerPorId(int id)
        {
            return await _context.Rol.FindAsync(id);
        }

        // Agregar un nuevo rol usando RolDTO
        public async Task<Rol> Agregar(RolDTO rolDto)
        {
            var rol = new Rol
            {
                Name = rolDto.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Rol.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        // Actualizar un rol existente
        public async Task<bool> Actualizar(int id, RolDTO rolActualizado)
        {
            var rol = await ObtenerPorId(id);
            if (rol == null) return false;

            rol.Name = rolActualizado.Name;
            rol.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
        // Eliminar un rol por ID
        public async Task<bool> Eliminar(int id)
        {
            var rol = await ObtenerPorId(id);
            if (rol == null) return false;

            _context.Rol.Remove(rol);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}