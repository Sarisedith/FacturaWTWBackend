using FacturaWTW.Application.DTOs;
using FacturaWTW.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWTW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoClienteController : ControllerBase
    {
        private readonly ITipoClienteService _service;

        public TipoClienteController(ITipoClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var tipos = await _service.ObtenerTodosAsync();
            return Ok(tipos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var tipo = await _service.ObtenerPorIdAsync(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] TipoClienteCrearDTO dto)
        {
            var id = await _service.CrearAsync(dto);
            return Ok(new { TipoClienteId = id });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] TipoClienteActualizarDTO dto)
        {
            var updated = await _service.ActualizarAsync(dto);
            if (!updated) return NotFound();
            return Ok(new { Success = true });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var deleted = await _service.EliminarAsync(id);
            if (!deleted) return NotFound();
            return Ok(new { Success = true });
        }
    }
}
