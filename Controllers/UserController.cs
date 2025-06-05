using Inventory.DTO;
using Inventory.Service;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.Registrar(userDto);
            if (user == null)
                return Conflict("El email ya está registrado.");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var ruta = await _userService.Autenticar(loginDto.Email, loginDto.Password);
            if (ruta == null)
                return Unauthorized("Credenciales inválidas.");

            return Ok(new { redirect = ruta });
        }

        // obtener todos los usuarios mas roll  
        [HttpGet("list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.ObtenerTodos();
            if (users == null || !users.Any())
                return NotFound("No se encontraron usuarios.");

            return Ok(users);
        }
    }
}
