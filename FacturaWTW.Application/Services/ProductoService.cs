using AutoMapper;
using FacturaWTW.Application.DTOs;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;
namespace FacturaWTW.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repo;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDTO>> ObtenerTodosAsync()
        {
            var entities = await _repo.ObtenerTodosAsync();
            return _mapper.Map<IEnumerable<ProductoDTO>>(entities);
        }

        public async Task<ProductoDTO?> ObtenerPorIdAsync(int id)
        {
            var entity = await _repo.ObtenerPorIdAsync(id);
            return _mapper.Map<ProductoDTO?>(entity);
        }

        public async Task<int> CrearAsync(ProductoCrearDTO dto)
        {
            var entity = _mapper.Map<CatProducto>(dto);
            return await _repo.CrearAsync(entity);
        }

        public async Task<bool> ActualizarAsync(ProductoActualizarDTO dto)
        {
            var entity = _mapper.Map<CatProducto>(dto);
            return await _repo.ActualizarAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id) => await _repo.EliminarAsync(id);
    }
}
