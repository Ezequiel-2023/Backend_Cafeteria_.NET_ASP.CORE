using Inventory.Config;
using Inventory.DTO;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Inventory.Service
{
    public class UserService
    {
        private readonly TodoContext _context;

        public UserService(TodoContext context)
        {
            _context = context;
        }

        public async Task<User?> ObtenerPorEmail(string email)
        {
            return await _context.Users.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserDTO?> Registrar(UserDTO userDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
                return null;

            var user = new User
            {
                Name = userDto.Name,
                Apellido = userDto.Apellido,
                Email = userDto.Email,
                Password = EncriptarContraseña(userDto.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                RolId = ObtenerRolIdPorNombre("cliente") // Asigna el rol "cliente" por defecto
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Apellido = user.Apellido,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public async Task<string?> Autenticar(string email, string password)
        {
            var user = await ObtenerPorEmail(email);
            if (user == null || user.Password != EncriptarContraseña(password))
                return null;

            return user.RolId switch
            {
                1 => "./app/admin",
                2 => "./app/ventas",
                3 => "./app/producto",
                _ => null
            };
        }

        private string EncriptarContraseña(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private int ObtenerRolIdPorNombre(string nombreRol)
        {
            var rol = _context.Rol.FirstOrDefault(r => r.Name.ToLower() == nombreRol.ToLower());
            return rol?.Id ?? 3; // Por defecto cliente (Id = 3)
        }

        public async Task<List<UserDTO>> ObtenerTodos()
        {
            return await _context.Users
                .Include(u => u.Rol)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Apellido = u.Apellido,
                    Email = u.Email,
                    Rol = u.Rol.Name
                })
                .ToListAsync();
        }

        
    }
}
