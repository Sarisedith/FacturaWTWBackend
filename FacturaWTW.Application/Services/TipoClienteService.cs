using AutoMapper;
using FacturaWTW.Application.DTOs;
using FacturaWTW.Application.Services;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;

namespace FacturaWTW.Appliion.Services
{
    public class TipoClienteService : ITipoClienteService
    {
        private readonly ITipoClienteRepository _repo;
        private readonly IMapper _mapper;

        public TipoClienteService(ITipoClienteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoClienteDTO>> ObtenerTodosAsync()
        {
            var entities = await _repo.ObtenerTodosAsync();
            return _mapper.Map<IEnumerable<TipoClienteDTO>>(entities);
        }

        public async Task<TipoClienteDTO?> ObtenerPorIdAsync(int id)
        {
            var entity = await _repo.ObtenerPorIdAsync(id);
            return _mapper.Map<TipoClienteDTO?>(entity);
        }

        public async Task<int> CrearAsync(TipoClienteCrearDTO dto)
        {
            var entity = _mapper.Map<CatTipoCliente>(dto);
            return await _repo.CrearAsync(entity);
        }

        public async Task<bool> ActualizarAsync(TipoClienteActualizarDTO dto)
        {
            var entity = _mapper.Map<CatTipoCliente>(dto);
            return await _repo.ActualizarAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id) => await _repo.EliminarAsync(id);
    }
}
