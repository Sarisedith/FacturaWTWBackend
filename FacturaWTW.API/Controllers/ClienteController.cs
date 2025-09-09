using FacturaWTW.Application.DTOs;
using FacturaWTW.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FacturaWTW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IValidator<ClienteCreateDTO> _createValidator;
        private readonly IValidator<ClienteUpdateDTO> _updateValidator;

        public ClienteController(
            IClienteService service,
            IValidator<ClienteCreateDTO> createValidator,
            IValidator<ClienteUpdateDTO> updateValidator)
        {
            _service = service;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _service.BuscarClientes();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.BuscarClientesPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteCreateDTO dto)
        {
            var result = await _createValidator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var id = await _service.CrearClienteAsync(dto);
            return Ok(new { ClienteId = id });
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCliente([FromBody] ClienteUpdateDTO dto)
        {
            var result = await _updateValidator.ValidateAsync(dto);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var updated = await _service.ActualizarClienteAsync(dto);
            if (!updated) return NotFound();

            return Ok(new { Success = true });
        }
    }
}

