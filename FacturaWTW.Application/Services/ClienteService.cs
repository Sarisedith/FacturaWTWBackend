using AutoMapper;
using FacturaWTW.Application.DTOs;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;
namespace FacturaWTW.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> BuscarClientes()
        {
            var clientes = await _repo.BuscarClientes();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO?> BuscarClientesPorId(int id)
        {
            var cliente = await _repo.BuscarClientesPorId(id);
            return _mapper.Map<ClienteDTO?>(cliente);
        }

        public async Task<int> CrearClienteAsync(ClienteCreateDTO dto)
        {
            var entity = _mapper.Map<Cliente>(dto);
            return await _repo.CrearClienteAsync(entity);
        }

        public async Task<bool> ActualizarClienteAsync(ClienteUpdateDTO dto)
        {
            var entity = _mapper.Map<Cliente>(dto);
            return await _repo.ActualizarClienteAsync(entity);
        }
    }
}
