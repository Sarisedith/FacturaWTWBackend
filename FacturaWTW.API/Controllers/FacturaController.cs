using FacturaWTW.Application.DTOs;
using FacturaWTW.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWTW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;
        private readonly IValidator<FacturaCreateDTO> _validator;

        public FacturaController(IFacturaService service, IValidator<FacturaCreateDTO> validator)
        {
            _service = service; _validator = validator;
        }

        [HttpPost("crearfactura")]
        public async Task<IActionResult> CrearFactura([FromBody] FacturaCreateDTO dto)
        {
            var validation = await _validator.ValidateAsync(dto);
            if (!validation.IsValid) return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            var id = await _service.CrearFacturaAsync(dto);
            return Ok(new { FacturaId = id });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarFacturaById(int id)
        {
            var factura = await _service.BuscarFacturaByIdAsync(id);
            if (factura == null) return NotFound();
            return Ok(factura);
        }
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarFacturas([FromQuery] int? clienteId, [FromQuery] int? facturaId)
        {
            var facturas = await _service.BuscarFacturasAsync(clienteId, facturaId);
            if (facturas == null) return NotFound();
            return Ok(facturas);
        }
    }
}
