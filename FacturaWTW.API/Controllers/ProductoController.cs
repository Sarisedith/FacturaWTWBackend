using FacturaWTW.Application.DTOs;
using FacturaWTW.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWTW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;
        private readonly IValidator<ProductoCrearDTO> _crearValidator;
        private readonly IValidator<ProductoActualizarDTO> _actualizarValidator;

        public ProductoController(
            IProductoService service,
            IValidator<ProductoCrearDTO> crearValidator,
            IValidator<ProductoActualizarDTO> actualizarValidator)
        {
            _service = service;
            _crearValidator = crearValidator;
            _actualizarValidator = actualizarValidator;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var productos = await _service.ObtenerTodosAsync();
            return Ok(productos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _service.ObtenerPorIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductoCrearDTO dto)
        {
            var result = await _crearValidator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var id = await _service.CrearAsync(dto);
            return Ok(new { ProductoId = id });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ProductoActualizarDTO dto)
        {
            var result = await _actualizarValidator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var actualizado = await _service.ActualizarAsync(dto);
            if (!actualizado) return NotFound();

            return Ok(new { Success = true });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.EliminarAsync(id);
            if (!eliminado) return NotFound();
            return Ok(new { Success = true });
        }
    }
}
