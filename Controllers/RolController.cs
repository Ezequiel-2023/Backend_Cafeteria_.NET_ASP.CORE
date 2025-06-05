using Microsoft.AspNetCore.Mvc;
using Inventory.Service;
using Inventory.DTO;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController(RolService rolService) : ControllerBase
    {
        private readonly RolService _rolService = rolService;

        // GET: api/Rol
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolService.ObtenerTodos();
            return Ok(roles);
        }

        // GET: api/Rol/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolService.ObtenerPorId(id);
            if (rol == null)
                return NotFound();
            return Ok(rol);
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolDTO rolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdRol = await _rolService.Agregar(rolDto);
            return CreatedAtAction(nameof(GetById), new { id = createdRol.Id }, createdRol);
        }

        // PUT: api/Rol/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolDTO rolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _rolService.Actualizar(id, rolDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Rol/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _rolService.Eliminar(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}